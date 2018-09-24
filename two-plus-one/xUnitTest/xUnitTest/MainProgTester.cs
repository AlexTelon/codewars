using System;
using Kata;
using Xunit;

namespace TDD
{
    public class MainProgTester
    {
        [Fact]
        public void ApplyDiscountsAndComputeTotal()
        {
            var basket = new[] { 26.14m, 20.94m, 0.71m, 4.3m, 37.55m, 26.04m, 19.88m, 43.49m, 17.89m, 36.8m, 30.71m, 18.83m, 33.88m, 9.7m, 16.78m };
            var result = Program.Compute(basket);
            Assert.Equal<decimal>(243.33m, result);
        }

        [Fact]
        public void ThreeTotal()
        {
            var basket = new[] { 1m, 2m, 3m };
            var result = Program.Compute(basket);
            Assert.Equal<decimal>(5m, result);
        }

        [Fact]
        public void SixTotalMultipleSameValue()
        {
            var basket = new[] { 1m, 2m, 3m, 3m, 3m, 3m };
            var result = Program.Compute(basket);
            Assert.Equal<decimal>(11m, result);
        }

        [Fact]
        public void ThreeAllSameValue()
        {
            var basket = new[] { 0m, 0m, 0m };
            var result = Program.Compute(basket);
            Assert.Equal<decimal>(0m, result);
        }

        [Fact]
        public void ThreeAllZero()
        {
            var basket = new[] { 0m, 0m, 0m };
            var result = Program.Compute(basket);
            Assert.Equal<decimal>(0m, result);
        }

        [Fact]
        public void DecimalMaxValueTest()
        {
            var basket = new[] { decimal.MaxValue, 0m, 0m };
            var result = Program.Compute(basket);
            Assert.Equal<decimal>(decimal.MaxValue, result);
        }

        [Fact]
        public void OverflowTest()
        {
            var basket = new[] { decimal.MaxValue, 1m, 0m };
            Assert.Throws<OverflowException>(() => Program.Compute(basket));
        }

        [Fact]
        public void NegativeValueTest()
        {
            var basket = new[] { -1m, -1m, 0m };
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.Compute(basket));
        }

        [Fact]
        public void NonThreeMultiple()
        {
            var basket = new[] {1m, 2m };
            Assert.ThrowsAny<ArgumentException>(() => Program.Compute(basket));
        }


        [Fact]
        public void NullTest()
        {
            Assert.Throws<ArgumentNullException>(() => Program.Compute(null));
        }
    }
}
