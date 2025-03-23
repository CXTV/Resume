using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumenManagement.Application.Features.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery : IRequest<GetCompanyByIdQueryResponse>
    {
        public Guid ID { get; set; }
    }
}
