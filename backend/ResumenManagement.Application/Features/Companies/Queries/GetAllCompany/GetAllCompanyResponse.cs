using ResumenManagement.Application.Features.Companies.Commands.CreateCompany;
using ResumenManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Companies.Queries.GetAllCompany
{
    public class GetAllCompanyResponse:BaseResponse
    {
        public GetAllCompanyResponse():base() { }

        public List<GetAllCompanyVm> Company { get; set; }

    }
}
