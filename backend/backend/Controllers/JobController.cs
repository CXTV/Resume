using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;
using ResumenManagement.Application.Features.Jobs.Commands.CreateJob;
using ResumenManagement.Application.Features.Jobs.Queries.GetAllJob;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Job> _jobRepository;


        public JobController(IMediator mediator, IMapper mapper, IAsyncRepository<Job> jobRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _jobRepository = jobRepository;
        }

        [HttpPost(Name = "CreateJob")]
        public async Task<ActionResult> CreateJob([FromBody] CreateJobDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);

            await _jobRepository.AddAsync(newJob);

            return Ok("job Created Successfully");
            //return CreatedAtRoute("GetCompanyById", new { id = response.Company.CompanyID }, response);
        }

        [HttpGet(Name = "GetAllJob")]
        public async Task<ActionResult<List<GetAllJobVm>>> GetAllJob()
        {
            var jobs = await _jobRepository.ListAllAsync(j=>j.Company);
            var allJobs = _mapper.Map<List<GetAllJobVm>>(jobs);
            return Ok(allJobs);
            //return CreatedAtRoute("GetCompanyById", new { id = response.Company.CompanyID }, response);
        }
    }
}
