using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyABC.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(25)]
        public string Address { get; set; }

        [StringLength(25)]
        public string City { get; set; }
        [StringLength(25)]
        public string PostalCode { get; set; }
        [StringLength(25)]
        public string Password { get; set; }
        [StringLength(25)]
        public string Role { get; set; }
    }
}
