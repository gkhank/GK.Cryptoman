using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.Cryptoman.Model.Response
{
    public class SimplifiedExceptionResponse
    {
        public SimplifiedExceptionResponse(string[] messages, int customErrorCode)
        {
            Messages = messages;
            CustomErrorCode = customErrorCode;
        }

        public string[] Messages { get; set; }
        public int CustomErrorCode { get; set; }
    }
}
