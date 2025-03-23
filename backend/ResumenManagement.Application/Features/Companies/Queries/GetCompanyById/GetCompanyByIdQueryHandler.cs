using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ResumeManagement.Domain.Entities;
using ResumenManagement.Application.Contracts.Persistance;
using ResumenManagement.Application.Features.Companies.Commands.CreateCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ResumenManagement.Application.Features.Companies.Queries
//{
//    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdQueryResponse>
//    {

//        private readonly IAsyncRepository<Company> _companyRepository;
//        private readonly IMapper _mapper;
//        private readonly ILogger<CreateCompanyCommandHandler> _logger;

//        //public async Task<GetCompanyByIdQueryResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
//        //{



//        //    return GetCompanyByIdQueryResponse;
//        //}
//    }

//}
