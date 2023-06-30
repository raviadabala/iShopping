using iShopping.Dto;
using iShopping.Dto.Account;
using iShopping.Entities;

namespace iShopping.Api.BusinessLogic
{
    public interface IAccountBusinessLogic
    {
        ValueTask<IResult> GetUsersAsync();
        ValueTask<IResult> LoginAsync(LoginDto loginDto);
        ValueTask<IResult> RegisterAsync(UserCreateDto userCreateDto);
    }
}
