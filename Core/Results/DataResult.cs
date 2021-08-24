using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, bool succes, string message) : base(succes, message)
        {
            YerlesimAyrinti = data;

        }
        public DataResult(T data, bool succes) : base(succes)
        {
            YerlesimAyrinti = data;
        }

        public T YerlesimAyrinti { get; }


    }
}
