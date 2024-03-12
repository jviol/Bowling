using BowlingApplication.Model;
using JetBrains.Annotations;
using Xunit;

namespace BowlingApplication.Tests.model;

[TestSubject(typeof(Game))]
public class GameTest {

    [Fact]
    public void ExampleGame() {
        Game game = new Game();
        game.AddFrame(1).SetSecondRoll(4);
        game.AddFrame(4).SetSecondRoll(5);
        game.AddFrame(6).SetSecondRoll(4);
        game.AddFrame(5).SetSecondRoll(5);
        game.AddFrame(10);
        game.AddFrame(0).SetSecondRoll(1);
        game.AddFrame(7).SetSecondRoll(3);
        game.AddFrame(6).SetSecondRoll(4);
        game.AddFrame(10);
        Frame lastFrame = game.AddFrame(2);
        lastFrame.SetSecondRoll(8);
        lastFrame.NextFrame = new Frame(6);
        Assert.Equal(133, game.Score());
    }
}