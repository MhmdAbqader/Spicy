using Microsoft.AspNetCore.Identity;

namespace spice.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

        public string Streataddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public string State { get; set; }
    }
}
