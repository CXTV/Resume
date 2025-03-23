using ResumenManagement.Application.Responses;
using System.Text.Json.Serialization;

namespace ResumenManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandResponse : BaseResponse
    {

        public CreateCompanyCommandResponse() : base()
        {

        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CreateCompanyDto? Company { get; set; }

    }
}
