using BowlingApplication.Model;

namespace BowlingApplication;

public static class CliGame {
    public static void Main(string[] args) {
        Game game = new Game();
        for (int i = 1; i <= 10; i++) {
            Frame? frame = null;
            while (frame == null) {
                Console.Write($"Frame {i}, first roll:");
                frame = TryReadFirstRoll(game);
            }

            if (frame.IsComplete()) {
                Console.WriteLine("Strike!");
            } else {
                do {
                    Console.Write($"Frame {i}, second roll:");
                } while (!TryReadSecondRoll(frame));
            }
            PrintScoreSheet(game);
        }

        Frame lastFrame = game.Frames.Last();
        // TODO: move this logic to the Game class
        if (lastFrame.FirstRoll == 10 || lastFrame.FirstRoll + lastFrame.SecondRoll == 10) {
            while (lastFrame.NextFrame == null) {
                Console.Write("Bonus roll:");
                lastFrame.NextFrame = TryReadFirstRoll(game);
            }
            if (lastFrame.FirstRoll == 10) {
                if (lastFrame.NextFrame.FirstRoll == 10) {
                    while (lastFrame.NextFrame.NextFrame == null) {
                        Console.Write("Bonus roll:");
                        lastFrame.NextFrame.NextFrame = TryReadFirstRoll(game);
                    }
                } else {
                    do {
                        Console.Write("Bonus roll:");
                    } while (!TryReadSecondRoll(lastFrame.NextFrame));
                }
            }
            PrintScoreSheet(game);
        }
        Console.WriteLine("Game over!");
    }

    /**
     * Tries to read the first roll of a frame from the console.
     * If the input is invalid, prints an error message and returns null.
     * If the input is valid, returns the frame.
     */
    private static Frame? TryReadFirstRoll(Game game) {
        try {
            int firstRoll = Convert.ToInt32(Console.ReadLine());
            Frame frame = game.AddFrame(firstRoll);
            return frame;
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            return null;
        }
    }
    
    /**
     * Tries to read the second roll of a frame from the console.
     * If the input is invalid, prints an error message and returns false.
     * If the input is valid, sets the second roll of the frame and returns true.
     */
    private static bool TryReadSecondRoll(Frame frame) {
        try {
            int secondRoll = Convert.ToInt32(Console.ReadLine());
            frame.SetSecondRoll(secondRoll);
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    private static void PrintScoreSheet(Game game) {
        Console.WriteLine(new string('-', 81));
        Console.WriteLine("Frame\t" + string.Join('\t', Enumerable.Range(1, 10)));
        Console.WriteLine("Rolls\t" + string.Join('\t', game.Frames.Select(frame => frame.ToString())));
        Console.WriteLine("Score\t" + string.Join('\t', game.Frames.Select(frame => frame.Score())));
        Console.WriteLine("Total\t" + game.Score());
    }
}