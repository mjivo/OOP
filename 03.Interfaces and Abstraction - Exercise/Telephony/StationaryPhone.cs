using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    //aaaaaaaaaa aaaaaaaaaa
    public class StationaryPhone : IStationaryPhone
    {
        //StationaryPhone
        //private string _number;
        //public StationaryPhone()
        //{

        //}
        //public StationaryPhone(string number)
        //{
        //    this.Number = number;
        //}
        //public string Number
        //{
        //    get => this._number;
        //    private set
        //    {
        //        if (!this.IsAllCharactersDigits(value))
        //        {
        //            throw new ArgumentException("Invalid number!");
        //        }
        //        this._number = value;
        //    }
        //}

        public string Call(string number)
        {
            if (!this.IsAllCharactersDigits(number))
            {
                //throw new ArgumentException("Invalid number!");
                return "Invalid number!";
            }
            else
            {
                return $"Dialing... {number}";
            }
            //this.Number = number;
        }
        private bool IsAllCharactersDigits(string value)
        {
            foreach (char ch in value)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
