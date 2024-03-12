namespace BowlingApplication.Model;

public class Game {
    public readonly List<Frame> Frames = new(10);
    public Frame? CurrentFrame { get; private set; }

    private Frame AddFrame(int firstRoll) {
        Frame frame = new Frame(firstRoll);
        Frames.Add(frame);
        if (CurrentFrame != null) {
            CurrentFrame.NextFrame = frame;
        }
        CurrentFrame = frame;
        return frame;
    }
    
    public int Score() {
        return Frames.Sum(frame => frame.Score() ?? 0);
    }
    
    public bool IsComplete() {
        return Frames.Count == 10 && Frames.All(frame => frame.Score() is not null);
    }
    
    public void AddRoll(int rollValue) {
        if (IsComplete()) {
            throw new Exception("Game is already complete");
        }
        if (CurrentFrame == null) {
            AddFrame(rollValue);
        } else if (CurrentFrame.IsComplete()) {
            if (Frames.Count == 10) {
                CurrentFrame.NextFrame = new Frame(rollValue);
                CurrentFrame = CurrentFrame.NextFrame;
            } else {
                AddFrame(rollValue);
            }
        } else {
            CurrentFrame.SetSecondRoll(rollValue);
        }
    }
}