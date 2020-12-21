using System;
using System.Linq;
using WebApplication.Services.Abstract;

namespace WebApplication.Services.Concrete
{
    public class StringService: IStringService
    {
        public bool IsPalindrome(string value)
        {
            return value == String.Join("", value.Reverse());
        }

        public string ReverseWords(string value)
        {
            return String.Join(" ", value.Split(' ').Reverse());
        }
    }
}
