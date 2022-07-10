using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public interface IBirthdateable
    {
        public string Birthdate { get; }

        bool ValidateDate(string date);
    }
}
