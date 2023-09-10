namespace HrNew.MVC.Models
{
    public class HrTypeVM : CreateHrTypeVM
    {
        public int Id { get; set; }
    }

    public class CreateHrTypeVM
    {
        [Required]
        public string Name { get; set; }
    }
}
