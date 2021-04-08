using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //ona gore constructordan istifade eleyerikki programci oz basina is gormesin
        // result.isSuccess cirt pirt yazmasin
        // :this (success) resultun tek parametreli olan conscturctoruna successi yolla
        // 1ci Result 2ci   Resultuda kapsiyir men :this(success) deyende 1ci Result calisan
        // zaman ikincisi de calissin deyirem
       

        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        //overloading
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
