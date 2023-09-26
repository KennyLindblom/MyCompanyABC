using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyABC.Models
{
    public class ProjectList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectListId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        [ForeignKey("Employees")]
        public int FK_EmployeeId { get; set; }
        public Employee Employees { get; set; }//Navigering
        [ForeignKey("Projects")]
        public int FK_ProjectId { get; set; }
        public Project Projects { get; set; }
    }
}
