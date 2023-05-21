using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Enums
{
    public enum StatusCodeShared
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        Error = 500,
    }
}
