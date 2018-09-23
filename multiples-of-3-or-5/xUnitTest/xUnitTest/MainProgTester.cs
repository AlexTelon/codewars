using System;
using Kata;
using Xunit;

namespace TDD
{
    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    // Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
    // Note: If the number is a multiple of both 3 and 5, only count it once.
    public class MainProgTester
    {
        public static void TestEquality(int expectedOutput, int input) => Assert.Equal(expectedOutput, Program.Solution(input));

        [Fact]
        public void ZeroTest() => TestEquality(0, 0);
        [Fact]
        public void OneTest() => TestEquality(0, 1);
        [Fact]
        public void TwoTest() => TestEquality(0, 2);

        [Fact]
        public void EqualShouldNotCount3() => TestEquality(0, 3);

        [Fact]
        public void EqualShouldNotCount5() => TestEquality(3, 5);

        [Fact]
        public void GreaterThan3() => TestEquality(3, 4);

        [Fact]
        public void GreaterThan5() => TestEquality(8, 6);

        [Fact]
        public void derp() => TestEquality(45, 15);

        [Fact]
        public void DontDoubleCount() => TestEquality(60, 16);

        //3
        //6
        //9
        //12
        //15

        //5
        //10


    }
}
