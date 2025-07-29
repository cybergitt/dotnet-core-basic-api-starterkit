using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAS.Domain.Entities
{
    public partial class TodoTask
    {
        public long Id => TaskId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskId { get; set; }
        public string Description { get; set; } = null!;
        public bool Completed { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
