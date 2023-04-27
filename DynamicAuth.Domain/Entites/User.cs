using Microsoft.AspNetCore.Identity;

namespace DynamicAuth.Domain.Entites
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string RegionId { get; set; }
        public bool IsDeleted { get; set; }
        public string BanksCardsNumber { get; set; }
        public User(string userName, string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, string nationalId ,string regionId)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Id = Guid.NewGuid().ToString();
            DateOfBirth = dateOfBirth;
            NationalId = nationalId;
            RegionId = regionId;
 


        }
    }
}
