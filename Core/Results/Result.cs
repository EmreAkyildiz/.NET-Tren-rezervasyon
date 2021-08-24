using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class Result:IResult
    {

        public Result(bool succes, string message) : this(succes)
        {
            Message = message;
        }
        public Result(bool succes)
        {
            RezervasyonYapilabilir = succes;
        }
        public bool RezervasyonYapilabilir { get; }

        public string Message { get; }
    }
}
