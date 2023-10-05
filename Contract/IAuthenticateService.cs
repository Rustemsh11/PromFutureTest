using Entity;

namespace Contract
{
    public interface IAuthenticateService
    {
        Task<User> Authenticate(AuthenticateModel authenticateModel); 
    }
}
