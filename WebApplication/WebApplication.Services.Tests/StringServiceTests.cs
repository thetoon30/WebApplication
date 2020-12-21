using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WebApplication.Services.Abstract;
using WebApplication.Services.Concrete;

namespace WebApplication.Services.Tests
{
    public class StringServiceTests
    {
        private IStringService _stringService;
        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<IStringService, StringService>();

            var serviceProvider = services.BuildServiceProvider();

            _stringService = serviceProvider.GetService<IStringService>();
        }

        //todo: fix test
        [TestCase("madam",true)]
        [TestCase("step on no pets",true)]
        [TestCase("book",false)]
        [TestCase("12321", true)]
        [TestCase("123456", false)]
        public void CanIdentifyPalindromes(string value, bool expected)
        {
            var isPalindrome = _stringService.IsPalindrome(value);
            Assert.AreEqual(isPalindrome,expected);
        }

        //todo: fix test
        [TestCase("welcome to control expert", "expert control to welcome")]
        [TestCase("robot a that's", "that's a robot")]
        public void ReverseWordsInSentence(string value, string expected)
        {
            var isPalindrome = _stringService.ReverseWords(value);
            Assert.AreEqual(isPalindrome,expected);
        }
    }
}