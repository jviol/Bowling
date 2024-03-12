namespace BowlingApplication.Model;

public class Game {
    public readonly List<Frame> Frames = new(10);
    private Frame? _previousFrame;
    
    public Frame AddFrame(int firstRoll) {
        Frame frame = new Frame(firstRoll);
        Frames.Add(frame);
        if (_previousFrame != null) {
            _previousFrame.NextFrame = frame;
        }
        _previousFrame = frame;
        return frame;
    }
    
    public int Score() {
        return Frames.Sum(frame => frame.Score() ?? 0);
    }
    
    // public bool IsComplete() {
    //     return Frames.Count == 10 && Frames.All(frame => frame.Score() is not null);
    // }
    //
    // public void AddRoll(int rollValue) {
    //     if (IsComplete())
    //         throw new Exception("Game is already complete");
    //     
    // }
}