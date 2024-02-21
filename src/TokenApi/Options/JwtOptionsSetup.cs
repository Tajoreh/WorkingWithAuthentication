﻿using Jwt_token_Generator;
using Microsoft.Extensions.Options;

namespace TokenApi.Options;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection(nameof(JwtOptions)).Bind(options);
    }
}