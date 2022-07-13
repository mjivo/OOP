using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        //public string Number { get; }

        public string Call(string number);
    }
}
