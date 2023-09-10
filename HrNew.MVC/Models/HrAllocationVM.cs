namespace HrNew.MVC.Models
{
    public class HrAllocationVM : CreateHrAllocationVM
    {
        public int Id { get; set; }
    }

    public class CreateHrAllocationVM
    {
        [Required]
        public string Warehouse { get; set; }

        [Required]
        public string Section { get; set; }
    }
}
