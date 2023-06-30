using AutoMapper;
using AutoMapper.QueryableExtensions;
using iShopping.Api.Services;
using iShopping.Dto;
using iShopping.Dto.Account;
using iShopping.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace iShopping.Api.BusinessLogic
{
    public class AccountBusinessLogic : IAccountBusinessLogic
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountBusinessLogic(UserManager<User> userManager, SignInManager<User> signManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signManager = signManager ?? throw new ArgumentNullException(nameof(signManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }


        public async ValueTask<IResult> GetUsersAsync()
        {
            var users = await _userManager.Users.ProjectTo<UserReadDto>(_mapper.ConfigurationProvider).ToListAsync();
            return Results.Ok(users);
        }

        public async ValueTask<IResult> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if(user != null)
            {
                var isSuccess = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                var token = await _tokenService.CreateTokenAsync(user);
                var userReadDto = _mapper.Map<UserReadDto>(user);
                userReadDto.Token = token;
                return Results.Ok(userReadDto);
            }
            return Results.Unauthorized();
        }
        public async ValueTask<IResult> RegisterAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            var result = await _userManager.CreateAsync(user,userCreateDto.Password);
            if(result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                if(!roleResult.Succeeded)
                {
                    return Results.BadRequest(roleResult.Errors);
                }

                return Results.Ok(result);
            }
            return Results.BadRequest(result.Errors);
        }
    }
}
