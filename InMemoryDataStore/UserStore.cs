using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace InMemoryDataStore
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>
    {
        private List<User> _users = new List<User>
        {
            new User
            {
            Id = Guid.NewGuid ().ToString ("N"),
            Email = "adminuser@somedomain.com",
            NormalizedEmail = "ADMINUSER@SOMEDOMAIN.COM",
            AssignedClaims = new List<Claim>
            {
            new Claim ("Role", "ADMIN")
            },
            NormalizedUserName = "USER1",
            RolesByName = new List<string> { "ADMIN" },
            Password = "password",
            UserName = "User1"
            }
        };

        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync (User user, CancellationToken cancellationToken)
        {
            if (!_users.Any (u => (u.Id == user.Id) || (u.Email == user.Email) || (u.UserName == user.UserName)))
            {
                _users.Add (user);
                Task.FromResult (IdentityResult.Success);
            }
            return Task.FromResult (IdentityResult.Failed (
                new IdentityError {  Description = "A user like that already exists" }
            ));
        }

        public Task<IdentityResult> DeleteAsync (User user, CancellationToken cancellationToken)
        {
            if (_users.Any (u => u.Id == user.Id))
            {
                _users.Remove (user);
                Task.FromResult (IdentityResult.Success);
            }
            return Task.FromResult (IdentityResult.Failed (
                new IdentityError {  Description = "User does not exist" }
            ));
        }

        public void Dispose ()
        {

        }

        public Task<User> FindByIdAsync (string userId, CancellationToken cancellationToken)
        {
            var user = _users.SingleOrDefault (u => u.Id == userId);
            return Task.FromResult (user);
        }

        public Task<User> FindByNameAsync (string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _users.SingleOrDefault(u => u.NormalizedEmail == normalizedUserName );
            return Task.FromResult(user);
        }

        public Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync (User user, CancellationToken cancellationToken)
        {
            return Task.FromResult (user.UserName.ToUpper ());
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync (User user, CancellationToken cancellationToken)
        {
            return Task.FromResult (user.Id);
        }

        public Task<string> GetUserNameAsync (User user, CancellationToken cancellationToken)
        {
            return Task.FromResult (user.UserName);
        }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync (User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.UserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync (User user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync (User user, CancellationToken cancellationToken)
        {
            return Task.FromResult (IdentityResult.Success);
        }

    }
}