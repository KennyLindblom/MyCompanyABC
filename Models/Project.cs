using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyABC.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        [StringLength(50)]
        public string ProjectName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(35)]
        public string Status { get; set; }
    }
}
