namespace BowlingApplication.Model;

public class Game {
    public readonly List<Frame> Frames = new(12);
    public Frame? CurrentFrame { get; private set; }

    private void AddFrame(int firstRoll) {
        Frame frame = new Frame(firstRoll);
        Frames.Add(frame);
        if (CurrentFrame != null) {
            CurrentFrame.NextFrame = frame;
        }
        CurrentFrame = frame;
    }
    
    public int Score() {
        return Frames.Take(10).Sum(frame => frame.Score() ?? 0);
    }
    
    public bool IsComplete() {
        return Frames.Count >= 10 && Frames.Take(10).All(frame => frame.Score() is not null);
    }
    
    public void AddRoll(int rollValue) {
        if (IsComplete()) {
            throw new Exception("Game is already complete");
        }
        if (CurrentFrame == null || CurrentFrame.IsComplete()) {
            AddFrame(rollValue);
        } else {
            CurrentFrame.SetSecondRoll(rollValue);
        }
    }
}