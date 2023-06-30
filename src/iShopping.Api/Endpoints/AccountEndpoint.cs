using iShopping.Api.BusinessLogic;
using iShopping.Api.Infrastructure;
using iShopping.Dto;
using iShopping.Dto.Account;
using iShopping.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace iShopping.Api.Endpoints
{
    public class AccountEndpoint : IEndpointDefinition
    {
        /// <summary>
        /// Define Endpoint
        /// </summary>
        /// <param name="app"></param>
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/api/v1/account", Users)
                .RequireAuthorization()
                .WithName("Users")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest);

            app.MapPost("/api/v1/account/login", Login)
                .WithName("Login")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest);

            app.MapPost("/api/v1/account/register", Register)
                .WithName("Register")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest);
        }

        private async Task<IResult> Login(IAccountBusinessLogic accountBusinessLogic, LoginDto loginDto)
        {
            return await accountBusinessLogic.LoginAsync(loginDto);
        }

        private async Task<IResult> Register(IAccountBusinessLogic accountBusinessLogic, UserCreateDto user)
        {
            return await accountBusinessLogic.RegisterAsync(user);
        }
        private async Task<IResult> Users(IAccountBusinessLogic accountBusinessLogic)
        {
            var users = await accountBusinessLogic.GetUsersAsync();
            return Results.Ok(users);
        }

        private async Task<IResult> AccountByAccountId(string accountId)
        {
            await Task.CompletedTask;
            return Results.Ok();
        }

        private async Task<IResult> RegisterUser()
        {
            await Task.CompletedTask;
            return Results.Ok();
        }

        public void DefineServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountBusinessLogic, AccountBusinessLogic>();
        }
    }
}
