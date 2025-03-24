using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;
using ResumenManagement.Application.Features.Candidates.Commands;
using ResumenManagement.Application.Features.Candidates.Queires;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Candidate> _candidateRepository;


        public CandidateController(IMediator mediator, IMapper mapper, IAsyncRepository<Candidate> candidateRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _candidateRepository = candidateRepository;
        }



        [HttpPost(Name = "CreateCandidate")]
        public async Task<ActionResult> CreateCandidate([FromForm] CreateCandidateDto dto,IFormFile pdfFile)
        {

            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("File is not valid");                
            }

            var pdfFileName = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","uploads",pdfFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeUrl = pdfFileName;

            await _candidateRepository.AddAsync(newCandidate);
            return Ok("Candidate Created Successfully");
        }


        [HttpGet(Name = "GetAllCandidate")]
        public async Task<ActionResult<List<GetAllCandidateVm>>> GetAllCandidate()
        {
            var candidates = await _candidateRepository.ListAllAsync(c => c.Job);
            var allCandidates = _mapper.Map<List<GetAllCandidateVm>>(candidates);
            return Ok(allCandidates);
        }


        [HttpGet("{id}/resume", Name = "DownloadCandidateResume")]
        public IActionResult DownloadCandidateResume(Guid id)
        {

            var candidate = _candidateRepository.GetByIdAsync(id).Result;
            if (candidate == null || string.IsNullOrEmpty(candidate.ResumeUrl))
            {
                return NotFound("Resume not found");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", candidate.ResumeUrl);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", candidate.ResumeUrl);

        }

    }
}
