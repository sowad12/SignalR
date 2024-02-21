using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.Model.Interface;

namespace Library.Model.Entities
{
    public class BaseEntity: IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public long? CreatedBy { get; set; }

        public long? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual void OnCreate()
        {
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public virtual void OnUpdate()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public virtual void OnDelete()
        {
            UpdatedAt = DateTime.UtcNow;
            IsDeleted = true;
        }
    }
}
