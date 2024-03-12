using System;
using BowlingApplication.Model;
using JetBrains.Annotations;
using Xunit;

namespace BowlingApplication.Tests.model;

[TestSubject(typeof(Frame))]
public class FrameTest {

    [Fact]
    public void IllegalFirstRoll() {
        Assert.Throws<ArgumentException>(() => new Frame(11));
        Assert.Throws<ArgumentException>(() => new Frame(-1));
    }
    
    [Fact]
    public void IllegalSecondRoll() {
        Frame frame = new Frame(1);
        Assert.Throws<ArgumentException>(() => frame.SetSecondRoll(10));
        Assert.Throws<ArgumentException>(() => frame.SetSecondRoll(-1));
    }
}