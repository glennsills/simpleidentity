SimpleIdentity - Replacing the user store for Identity Server 4
============

I was unable to find the best way to replace the user store in IdentityServer4. After a bit of research I noticed that
there _was_ documentation on how to create a custom store for Asp.NET Core Identity and it was documented pretty well. Since
IdentityServer4 has an Asp.NET Identity Core integration I thought I'd try to plug a custom Identity server user store to
see what happens. It works. The code here is pretty rough, I might come back and clean it up later. Specificially I haven't deleted all the ununused stuff out of my test Identity Server webapp.

## Implementing an In Memory Provider

Take a look at the InMemoryDataStore project. I am implementing minimum interfaces necessary to get things runing.

- `IPasswordHasher<TUser>` - strictly speaking this isn't required if you want can just use Microsofts preferred hashing algorithm. I need to change mine so I implemented a clear text hasher (contradiction of terms) for simplicity in ClearTextPasswordHasher.cs. There is a good explaination of Microsoft password hasher here: 
[Exploring the ASP.NET Core Identity PasswordHasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/)

- `IUserClaimsPrincipalFactory<User>` - this is implemented in InMemoryClaimsPrincipalFactory. It doesn't seem to be needed by a plain old MVC app with -auth Individual set, but it is used by IdentityServer4.

- `IUserStore<User>, IUserPasswordStore<User>` - these are implemented in UserStore.cs.  There are five or six other interfaces defined for Asp.NET Identity, but there implementation is optional.

## Configuring Identity Server 4 to Use the In Memory Provider

- Create an IdentityServer that uses Asp.NET Identity Server using the documentation on [Welcome to IdentityServer4](https://identityserver4.readthedocs.io/en/latest).

- Modify the `Startup.ConfigureServices` so that it looks like the code below:


`

            services.AddScoped<SignInManager<User>, SignInManager<User>> ();
            services.AddDefaultIdentity<User> ().AddDefaultTokenProviders ();
            services.AddTransient<IUserStore<User>, UserStore> ();
            services.AddScoped<IPasswordHasher<User>, ClearTextPasswordHasher<User>> ();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            `

- Replace `ApplicationUser` with `User` in QuickStart\Account\AccountController

## That's Pretty Much It. 
Obviously in most cases you will want to inject data access into the UserDataStore but I wanted to keep things as simple
as possible. For more information on customizing Asp.NET Identity see [Custom storage providers for Asp.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-2.2)