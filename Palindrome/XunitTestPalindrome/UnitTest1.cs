using System;
using Xunit;
using PalindromeLib;

namespace XUnitTestPalindrome
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Palindrome pal = new Palindrome("doggone");
            bool test1 = pal.IsPalindrome();
            Assert.False(test1);

            Palindrome pal2 = new Palindrome("doggod");
            bool test2 = pal2.IsPalindrome();
            Assert.True(test2);

            Palindrome empty = new Palindrome("");
            bool test3 = empty.IsPalindrome();
            Assert.True(test3);

            Palindrome onechar = new Palindrome("b");
            bool test4 = onechar.IsPalindrome();
            Assert.True(test4);

            Palindrome oneCapital = new Palindrome("doGgod");
            bool test5 = oneCapital.IsPalindrome();
            Assert.False(test5);

            Palindrome allCaps = new Palindrome("DOGGOD");
            bool test6 = allCaps.IsPalindrome();
            Assert.True(test6);

            Palindrome odd = new Palindrome("refer");
            bool test7 = odd.IsPalindrome();
            Assert.True(test7);
        }

        [Fact]
        public void test2()
        {
            Palindrome pal = new Palindrome("doggone");
            pal.input = "refer";
            bool test1 = pal.IsPalindrome();
            Assert.True(test1);
            Assert.Equal("refer",pal.input);
            Palindrome pal2 = new Palindrome("test");
            Assert.Equal("test", pal.input);
        }

    }
}
