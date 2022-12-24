using AdminSSO.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Users
{
    public class CreateUserResponseDto
    {
        public int Id { get; set; } = 0;
        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorDto errors { get; set; }
    }
}
