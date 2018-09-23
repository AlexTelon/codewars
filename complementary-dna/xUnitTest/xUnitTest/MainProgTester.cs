using Kata;
using System;
using Xunit;

namespace TDD
{
    public class MainProgTester
    {
        //A-T
        //C-G
        [Fact]
        public void Complement_A()
        {
            Assert.Equal("T", Program.MakeComplement("A"));
        }
        [Fact]
        public void Complement_T()
        {
            Assert.Equal("A", Program.MakeComplement("T"));
        }
        [Fact]
        public void Complement_C()
        {
            Assert.Equal("C", Program.MakeComplement("G"));
        }
        [Fact]
        public void Complement_G()
        {
            Assert.Equal("G", Program.MakeComplement("C"));
        }

        [Fact]
        public void AA()
        {
            Assert.Equal("TT", Program.MakeComplement("AA"));
        }
        [Fact]
        public void TT()
        {
            Assert.Equal("AA", Program.MakeComplement("TT"));
        }
        [Fact]
        public void GG()
        {
            Assert.Equal("CC", Program.MakeComplement("GG"));
        }
        [Fact]
        public void CC()
        {
            Assert.Equal("GG", Program.MakeComplement("CC"));
        }

        [Fact]
        public void GC()
        {
            Assert.Equal("CG", Program.MakeComplement("GC"));
        }
        [Fact]
        public void AGC()
        {
            Assert.Equal("TCG", Program.MakeComplement("AGC"));
        }

        [Fact]
        public void ATTGC()
        {
            Assert.Equal("TAACG", Program.MakeComplement("ATTGC"));
        }

        [Fact]
        public void GTAT()
        {
            Assert.Equal("CATA", Program.MakeComplement("GTAT"));
        }

    }
}
