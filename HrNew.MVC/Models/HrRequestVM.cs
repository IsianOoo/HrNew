using System.ComponentModel.DataAnnotations;

namespace HrNew.MVC.Models
{
    public class HrRequestVM : CreateHrRequestVM
    {
        public int Id { get; set; }
    }

    public class CreateHrRequestVM
    {
        [Required]
        public int HrTypeId { get; set; }

        [Required]
        public int HrAllocationId { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        public HrAllocationVM HrAllocation { get; set; }

        public HrTypeVM HrType { get; set; }

    }
}
