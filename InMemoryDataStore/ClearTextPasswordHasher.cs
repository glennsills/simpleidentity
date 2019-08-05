using Microsoft.AspNetCore.Identity;

namespace InMemoryDataStore
{
public class ClearTextPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
    {     
        public string HashPassword(TUser user, string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == providedPassword)
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}