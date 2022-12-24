using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Errors
{
    public class ErrorDto
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<ValidationErrorDto> validationErrors { get; set; }
        public string details { get; set; }
    }
}
