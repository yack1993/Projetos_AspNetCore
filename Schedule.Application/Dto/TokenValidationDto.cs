using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Application.Dto
{
    public sealed class TokenValidationDto
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Claims { get; set; }
        public int Expires { get; set; }
        public string SigningCredentials { get; set; }
        public string[] WithOrigins { get; set; }


        public TokenValidationDto() { }

        public TokenValidationDto(TokenValidationDto tokenValidation)
        {
            Issuer = tokenValidation.Issuer;
            Audience = tokenValidation.Audience;
            Claims = tokenValidation.Claims;
            Expires = tokenValidation.Expires;
            SigningCredentials = tokenValidation.SigningCredentials;
            WithOrigins = tokenValidation.WithOrigins;
        }
    }
}
