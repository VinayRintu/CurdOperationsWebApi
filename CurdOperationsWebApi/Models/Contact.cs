namespace CurdOperationsWebApi.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public String? FullName { get; set; }
        public string? Email { get; set; } 
        public long Phone { get; set; }
        public string? Address { get; set; }       
    }
}
