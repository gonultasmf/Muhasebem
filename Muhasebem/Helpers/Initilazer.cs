namespace Muhasebem.Helpers;

public class Initilazer
{
    public Initilazer(IUserRepository userRepo)
    {
        if (userRepo.Count() <= 0)
            userRepo.Add(new User
            {
                Email = "mg",
                Password = "00",
                FirstName = "Mustafa",
                LastName = "Gönültaş",
                Age = 40,
                Gender = Gender.Male,
                PhoneNumber = "1234567890"
            });
    }
}
