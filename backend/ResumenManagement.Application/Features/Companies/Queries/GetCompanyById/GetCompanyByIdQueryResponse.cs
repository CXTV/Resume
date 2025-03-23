using ResumenManagement.Application.Features.Companies.Commands;
using ResumenManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Companies.Queries
{
    public class GetCompanyByIdQueryResponse:BaseResponse
    {
        public GetCompanyByIdQueryResponse() : base()
        {

        }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public GetCompanyDto? Company { get; set; }
    }
}
