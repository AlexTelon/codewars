using Kata;
using System;
using Xunit;

namespace TDD
{
    // Complete the method/function so that it converts dash/underscore delimited words into camel casing. 
    // The first word within the output should be capitalized only if the original word was capitalized.
    public class MainProgTester
    {
        [Fact]
        public void EmptyString()
        {
            Assert.Equal("", Program.ToCamelCase(""));
        }

        [Fact]
        public void OnlyDashesAndUnderscores()
        {
            Assert.Equal("", Program.ToCamelCase("---__--_"));
        }

        [Fact]
        public void OneDash()
        {
            Assert.Equal("", Program.ToCamelCase("-"));
        }

        [Fact]
        public void OneUnderscore()
        {
            Assert.Equal("", Program.ToCamelCase("_"));
        }

        [Fact]
        public void JustAWord()
        {
            Assert.Equal("A", Program.ToCamelCase("A"));
        }

        [Fact]
        public void Word_word()
        {
            Assert.Equal("WordWord", Program.ToCamelCase("Word_word"));
        }

        [Fact]
        public void LowerCaseStart_Word_word()
        {
            Assert.Equal("wordWord", Program.ToCamelCase("word_word"));
        }

        [Fact]
        public void Dash()
        {
            Assert.Equal("WordWord", Program.ToCamelCase("Word-word"));
        }

        [Fact]
        public void Trailing_dash()
        {
            Assert.Equal("WordWord", Program.ToCamelCase("Word-word-"));
        }

        [Fact]
        public void LoweCaseStart_theStealthWarrior()
        {
            Assert.Equal("theStealthWarrior", Program.ToCamelCase("the-stealth-warrior"));
        }

        [Fact]
        public void TheStealthWarrior()
        {
            Assert.Equal("TheStealthWarrior", Program.ToCamelCase("The-Stealth-Warrior"));
        }

        [Fact]
        public void Long_Input_test()
        {
            //Ten_TheStealthWarrior
            Assert.Equal("TheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarriorTheStealthWarrior",
                Program.ToCamelCase("The-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-WarriorThe-Stealth-Warrior"));
        }

        [Fact]
        public void NullInput()
        {
            Assert.Throws<ArgumentNullException>(() => Program.ToCamelCase(null));
        }

    }
}
