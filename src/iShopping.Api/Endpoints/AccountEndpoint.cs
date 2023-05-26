using iShopping.Api.Infrastructure;

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
            app.MapPost("/api/v1/account/register/", RegisterUser)
                .WithName("Register")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest);

            app.MapGet("/api/v1/account/{accountId}", AccountByAccountId)
                .WithName("AccountByAccountId")
                .Produces(StatusCodes.Status200OK)
                .ProducesValidationProblem(StatusCodes.Status400BadRequest);
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
            
        }
    }
}
