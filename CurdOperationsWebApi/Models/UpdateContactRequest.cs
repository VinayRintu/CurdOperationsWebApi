namespace CurdOperationsWebApi.Models
{
    public class UpdateContactRequest
    {
        public String? FullName { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }
        public string? Address { get; set; }
    }
}
