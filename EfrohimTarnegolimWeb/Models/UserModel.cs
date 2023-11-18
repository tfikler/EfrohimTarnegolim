namespace EfrohimTarnegolimWeb.Models
{
    public class UserModel
    {
        public required int IDNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FullName { get; set; }
        public required string YearOfStudies { get; set; }

    }
}
