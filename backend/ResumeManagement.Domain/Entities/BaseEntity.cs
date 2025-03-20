using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;  

    }

}
