using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.Cryptoman.Model.Response
{
    public class SimplifiedExceptionResponse
    {
        public SimplifiedExceptionResponse(string message, int customErrorCode)
        {
            Message = message;
            CustomErrorCode = customErrorCode;
        }

        public string Message { get; set; }
        public int CustomErrorCode { get; set; }
    }
}
