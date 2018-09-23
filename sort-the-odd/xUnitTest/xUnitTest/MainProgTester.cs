using System;
using Kata;
using Xunit;

namespace TDD
{
    //You have an array of numbers.
    //Your task is to sort ascending odd numbers but even numbers must be on their places.

    //Zero isn't an odd number and you don't need to move it.If you have an empty array, you need to return it.
    public class MainProgTester
    {
        [Fact]
        public void EmptyArray() => Assert.Equal(new int[] { }, Program.SortArray(new int[] { }));

        [Fact]
        public void NullInput() => Assert.Throws<ArgumentNullException>(() => Program.SortArray(null));

        [Fact]
        public void SortedArray() => Assert.Equal(new int[] { 0, 1, 2, 3 }, Program.SortArray(new int[] { 0, 1, 2, 3 }));

        [Fact]
        public void DontMoveDueToEven() => Assert.Equal(new int[] { 3, 2 }, Program.SortArray(new int[] { 3, 2 }));

        [Fact]
        public void DontModeTheEvenOne() => Assert.Equal(new int[] { 1, 2, 3 }, Program.SortArray(new int[] { 3, 2, 1 }));

        [Fact]
        public void CodeWars_Sample() => Assert.Equal(new int[] { 1, 3, 2, 8, 5, 4 }, Program.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));

        [Fact]
        public void ZeroIsEven() => Assert.Equal(new int[] { 1, 0, 3 }, Program.SortArray(new int[] { 3, 0, 1 }));

        [Fact]
        public void OnlyOdd() => Assert.Equal(new int[] { 1, 3, 5 }, Program.SortArray(new int[] { 3, 5, 1 }));


        [Fact]
        public void OnlyEven() => Assert.Equal(new int[] { 14, 8, 0 }, Program.SortArray(new int[] { 14, 8, 0 }));

        [Fact]
        public void OneEven() => Assert.Equal(new int[] { 0 }, Program.SortArray(new int[] { 0 }));
        [Fact]
        public void OneOdd() => Assert.Equal(new int[] { 15 }, Program.SortArray(new int[] { 15 }));


    }
}
