

namespace ResumeManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;  

    }

}
