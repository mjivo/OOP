using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : ISmartPhone
    {
        //public string Number => throw new NotImplementedException();

        //public string URL => throw new NotImplementedException();

        //private string _number;
        //private string _url;
        //private const string URLStarts = "https://";
        //public Smartphone()
        //{

        //}
        //public Smartphone(string number, string url)
        //{
        //    this.Number = number;
        //    this.URL = url;
        //}
        //public string Number
        //{
        //    get => this._number;
        //    protected set
        //    {
        //        if (!this.IsAllCharactersDigits(value))
        //        {
        //            throw new ArgumentException("Invalid number");
        //        }
        //        this._number = value;
        //    }
        //}
        //public string URL
        //{
        //    get => this._url;
        //    private set
        //    {
        //        if (!IsURLValid(value))
        //        {
        //            throw new ArgumentException("Invalid URL!");
        //        }
        //        this._url = value;
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
                return $"Calling... {number}";
            }
            //this.Number = number;
        }
        public string Browse(string url)
        {
            //this.URL = url;
            if (!IsURLValid(url))
            {
                //throw new ArgumentException("Invalid URL!");
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }
        private bool IsURLValid(string value)
        {
            //if (Regex.Match(value, @"^http:\/\/[a-z]+\.[a-z]*$").Success)
            //{
            //    return true;
            //}
            //return false;
            foreach (char ch in value)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
            //return value.StartsWith(URLStarts);
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
