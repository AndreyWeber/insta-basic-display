using System;
using System.Threading.Tasks;

using InstaBasicDisplayConsole.Data;
using InstaBasicDisplayConsole.Services;

namespace InstaBasicDisplayConsole.Repositories
{
    public class UserRepository : RepositoryBase
    {
        private const String uriTemplate = "https://graph.instagram.com/{0}?" +
            "fields=account_type,id,media_count,username&access_token={1}";

        public UserRepository(InstragramService instragramService) :
            base(instragramService) {}

        public async Task<User> GetUser(AccessToken accessToken)
        {
            if (accessToken is null)
            {
                throw new ArgumentNullException(nameof(accessToken), "Argument cannot be null");
            }

            return await instragramService.GetEntity<User>(
                String.Format(uriTemplate, accessToken.UserId, accessToken.Token)
            );
        }
    }
}