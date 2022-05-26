using System;
using System.Text;
using NUnit.Framework;
 
namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("\"abc\"", 0, "abc", 5)]
        [TestCase("b \"a'\"", 2, "a'", 4)]
        [TestCase(@"'a'b", 0, "a", 3)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }
 
    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            var sb = new StringBuilder();
            var isChange = false;
            var currentIndex = startIndex;
            var charFirst = line[currentIndex++];
            while (currentIndex < line.Length)
            {
                var currentChar = line[currentIndex++];
                if (currentChar == '\\')
                {
                    isChange = ChangeNewChar(sb, currentChar, isChange);
                }
                else if (currentChar == charFirst)
                {
                    if (!isChange)
                    {
                        break;
                    }
 
                    isChange = ChangeNewChar(sb, currentChar, isChange);
                }
                else sb.Append(currentChar);
            }
            return new Token(sb.ToString(), startIndex, currentIndex - startIndex);
        }
 
        private static bool ChangeNewChar(StringBuilder builder, char currentChar, bool isChange)
        {
            if (isChange)
            {
                builder.Append(currentChar);
                return false;
            }
            return true;
        }
    }
}
