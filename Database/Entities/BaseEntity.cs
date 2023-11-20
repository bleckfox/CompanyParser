using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
