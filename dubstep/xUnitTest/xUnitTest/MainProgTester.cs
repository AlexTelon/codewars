using System;
using Xunit;
using Kata;

namespace TDD
{
    //WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB
    // WUB 1.. between each word in original
    // WUB 0.. before first word
    // WUB 0.. after last word

    public class MainProgTester
    {
        //[Fact]
        //public void CodeWars_SampleQuestion()
        //{
        //    Assert.Equal("WE ARE THE CHAMPIONS MY FRIEND", Program.SongDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB"));
        //}

        [Fact]
        public void WUB_Start() => Assert.Equal("", Program.SongDecoder("WUB"));

        [Fact]
        public void OneWord_NoWub() => Assert.Equal("HURT", Program.SongDecoder("HURT"));

        [Fact]
        public void Word_Wub_Word() => Assert.Equal("NEVER HURT", Program.SongDecoder("NEVERWUBHURT"));

        [Fact]
        public void Wub_Word_Wub() => Assert.Equal("NEVER", Program.SongDecoder("WUBNEVERWUB"));

        [Fact]
        public void Wub_Word_Wub_Word() => Assert.Equal("NEVER HURT", Program.SongDecoder("WUBNEVERWUBHURT"));

        [Fact]
        public void MultiWub_Word() => Assert.Equal("NEVER", Program.SongDecoder("WUBWUBNEVER"));

        [Fact]
        public void MultiWub_Word_MultiWub_Word() => Assert.Equal("NEVER HURT", Program.SongDecoder("WUBWUBNEVERWUBWUBWUBHURT"));

        [Fact]
        public void MultiWub_Word_MultiWub_Word_MultiWub() => Assert.Equal("NEVER HURT", Program.SongDecoder("WUBWUBNEVERWUBWUBWUBHURTWUBWUBWUBWUB"));

        [Fact]
        public void LotsOfWords_WithSingleWubs() => Assert.Equal("I WOULD NEVER HURT YOU", Program.SongDecoder("IWUBWOULDWUBNEVERWUBHURTWUBYOU"));



    }
}
