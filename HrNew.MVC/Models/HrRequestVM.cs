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
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string RequestComments { get; set; }
    }
}
