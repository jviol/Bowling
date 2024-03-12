using System;
using BowlingApplication.Model;
using JetBrains.Annotations;
using Xunit;

namespace BowlingApplication.Tests.model;

[TestSubject(typeof(Game))]
public class GameTest {

    [Fact]
    public void ExampleGame() {
        Game game = new Game();
        game.AddRoll(1); game.AddRoll(4);
        game.AddRoll(4); game.AddRoll(5);
        game.AddRoll(6); game.AddRoll(4);
        game.AddRoll(5); game.AddRoll(5);
        game.AddRoll(10);
        game.AddRoll(0); game.AddRoll(1);
        game.AddRoll(7); game.AddRoll(3);
        game.AddRoll(6); game.AddRoll(4);
        game.AddRoll(10);
        game.AddRoll(2); game.AddRoll(8); 
        game.AddRoll(6);
        Assert.Equal(133, game.Score());
        Assert.True(game.IsComplete());
        Assert.Throws<Exception>(() => game.AddRoll(10));
    }
    
    [Fact]
    public void PerfectGame() {
        Game game = new Game();
        for (int i = 0; i < 10; i++) {
            game.AddRoll(10);
        }
        game.AddRoll(10);
        game.AddRoll(10);
        Assert.Equal(300, game.Score());
        Assert.True(game.IsComplete());
    }
}