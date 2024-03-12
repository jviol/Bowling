using BowlingApplication.Model;

namespace BowlingApplication;

public static class CliGame {
    public static void Main(string[] args) {
        Game game = new Game();
        for (int i = 1; i <= 10; i++) {
            do {
                Console.Write($"Frame {i}, first roll:");
            } while (!TryReadRoll(game));

            if (game.CurrentFrame!.IsComplete()) {
                Console.WriteLine("Strike!");
            } else {
                do {
                    Console.Write($"Frame {i}, second roll:");
                } while (!TryReadRoll(game));
            }
            PrintScoreSheet(game);
        }
        // if the last frame is a strike or spare, ask for bonus rolls
        while (!game.IsComplete()) {
            do {
                Console.Write("Bonus roll:");
            } while (!TryReadRoll(game));
            PrintScoreSheet(game);
        }
        Console.WriteLine("Game over!");
    }

    
    /**
     * Tries to read a roll from the console.
     * If the input is invalid, prints an error message and returns false.
     * If the input is valid, sets the second roll of the frame and returns true.
     */
    private static bool TryReadRoll(Game game) {
        try {
            int rollValue = Convert.ToInt32(Console.ReadLine());
            game.AddRoll(rollValue);
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