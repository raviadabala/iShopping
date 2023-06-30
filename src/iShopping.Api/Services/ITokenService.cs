using iShopping.Entities;

namespace iShopping.Api.Services
{
    public interface ITokenService
    {
        ValueTask<string> CreateTokenAsync(User user);
    }
}
