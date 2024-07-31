namespace QLSV_SE06201.Models
{
    public class Account
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int IdUser { get; set; }
    }
}
