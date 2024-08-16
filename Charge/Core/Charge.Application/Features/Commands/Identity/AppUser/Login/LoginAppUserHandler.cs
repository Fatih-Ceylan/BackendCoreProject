﻿using AutoMapper;
using GCharge.Application.Abstractions.Identity;
using GCharge.Application.DTOs.Identity.Auth;
using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Login
{
    public class LoginAppUserHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {
        readonly IAuthService _authService;
        readonly IMapper _mapper;

        public LoginAppUserHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {
            var loginRequestDto = _mapper.Map<LoginRequestDTO>(request);

            var loginResponseDto = await _authService.LoginAsync(loginRequestDto);

            return _mapper.Map<LoginAppUserResponse>(loginResponseDto);
        }
    }
}