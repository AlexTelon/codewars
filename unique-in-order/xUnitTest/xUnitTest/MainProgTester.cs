using Kata;
using System;
using System.Collections.Generic;
using Xunit;

namespace TDD
{
    public class MainProgTester
    {
        [Fact]
        public void EmptyTest() => Assert.Equal("", Program.UniqueInOrder(""));

        [Fact]
        public void SingleChar() => Assert.Equal("A", Program.UniqueInOrder("A"));

        [Fact]
        public void AA() => Assert.Equal("A", Program.UniqueInOrder("AA"));

        [Fact]
        public void ABA() => Assert.Equal("ABA", Program.UniqueInOrder("ABA"));

        [Fact]
        public void ABAa() => Assert.Equal("ABAa", Program.UniqueInOrder("ABAa"));

        [Fact]
        public void AABBAA() => Assert.Equal("ABA", Program.UniqueInOrder("AABBAA"));

        [Fact]
        public void AAAABBBCCDAABBB() => Assert.Equal("ABCDAB", Program.UniqueInOrder("AAAABBBCCDAABBB"));

        [Fact]
        public void ABBCcAD() => Assert.Equal("ABCcAD", Program.UniqueInOrder("ABBCcAD"));

        [Fact]
        public void NumbersTest() => Assert.Equal(new List<int>() { 1, 2, 3 }, Program.UniqueInOrder(new List<int>() { 1, 2, 2, 3, 3 }));

        [Fact]
        public void EmptyList() => Assert.Equal(new List<int>(), Program.UniqueInOrder(new List<int>()));

        [Fact]
        public void NullTest() => Assert.ThrowsAny<ArgumentException>(() => Program.UniqueInOrder((IEnumerable<object>)null));

        [Fact]
        public void ListWithNullItemTest() => Assert.Equal(new List<object>() { null }, Program.UniqueInOrder(new List<object>() { null }));


        [Fact]
        public void ListThatStartsWithDefaultValue() => Assert.Equal(new List<int>() { 0, 1, 2 }, Program.UniqueInOrder(new List<int>() { 0, 1, 2 }));


        [Fact]
        public void StringThatStartsWithDefaultValue() => Assert.Equal("\0ab", Program.UniqueInOrder("\0ab"));

    }
}
