

namespace ResumeManagement.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T ID { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;  

    }

}
