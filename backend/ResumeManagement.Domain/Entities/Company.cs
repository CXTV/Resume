using ResumeManagement.Domain.Enums;


namespace ResumeManagement.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }

        //relations 一对多
        public ICollection<Job> Jobs { get; set; }
    }
}
