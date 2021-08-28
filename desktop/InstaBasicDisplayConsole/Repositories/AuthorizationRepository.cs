using System;
using System.Threading.Tasks;

using InstaBasicDisplayConsole.Data;
using InstaBasicDisplayConsole.Services;

namespace InstaBasicDisplayConsole.Repositories
{
    public class AuthorizationRepository : RepositoryBase
    {
        private const String uri = "https://api.instagram.com/oauth/access_token";

        public AuthorizationRepository(InstragramService instragramService) :
            base(instragramService) {}

        public async Task<AccessToken> GetAccessTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}