﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResumenManagement.Application.Features.Companies.Commands;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController:ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateCampany")]
        public async Task<ActionResult<CreateCompanyCommandResponse>> CreateCompany([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var response = await _mediator.Send(createCompanyCommand);

            return Ok(response);

            //return CreatedAtRoute("GetCompanyById", new { id = response.Company.CompanyID }, response);
        }
    }
}
