using System.ComponentModel.DataAnnotations;

namespace HrNew.MVC.Models
{
    public class HrAllocationVM : CreateHrAllocationVM
    {
        public int Id { get; set; }
    }

    public class CreateHrAllocationVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
