using BowlingApplication.Model;

namespace BowlingApplication;

public static class CliGame {
    public static void Main(string[] args) {
        Game game = new Game();
        for (int i = 1; i <= 10; i++) {
            Console.Write($"Frame {i}, first roll:");
            int firstRoll = Convert.ToInt32(Console.ReadLine());
            Frame frame = game.AddFrame(firstRoll);

            if (firstRoll == 10) {
                Console.WriteLine("Strike!");
            } else {
                Console.Write($"Frame {i}, second roll:");
                int secondRoll = Convert.ToInt32(Console.ReadLine());
                frame.SecondRoll = secondRoll;
            }
            PrintScoreSheet(game);
        }

        Frame lastFrame = game.Frames.Last();
        if (lastFrame.FirstRoll == 10 || lastFrame.FirstRoll + lastFrame.SecondRoll == 10) {
            Console.Write("Bonus roll:");
            lastFrame.NextFrame = new Frame(Convert.ToInt32(Console.ReadLine()));
            if (lastFrame.FirstRoll == 10) {
                Console.Write("Bonus roll:");
                lastFrame.NextFrame.SecondRoll = Convert.ToInt32(Console.ReadLine());
            }
            PrintScoreSheet(game);
        }
        Console.WriteLine("Game over!");
    }

    private static void PrintScoreSheet(Game game) {
        Console.WriteLine(new string('-', 81));
        Console.WriteLine("Frame\t" + string.Join('\t', Enumerable.Range(1, 10)));
        Console.WriteLine("Rolls\t" + string.Join('\t', game.Frames.Select(frame => frame.ToString())));
        Console.WriteLine("Score\t" + string.Join('\t', game.Frames.Select(frame => frame.Score())));
        Console.WriteLine("Total\t" + game.Score());
    }
}
