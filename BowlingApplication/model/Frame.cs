namespace BowlingApplication.Model;

public class Frame {
    public Frame? NextFrame { get; set; }
    public int FirstRoll { get; }
    private int? _secondRoll;

    public Frame(int firstRoll) {
        CheckRollValue(firstRoll);
        FirstRoll = firstRoll;
    }

    public int? SecondRoll {
        get => _secondRoll;
        set {
            CheckRollValue(value);
            if (FirstRoll + value > 10) {
                throw new ArgumentException(
                    "Second roll cannot exceed the number of pins left standing after the first roll");
            }

            _secondRoll = value;
        }
    }

    private static void CheckRollValue(int? value) {
        if (value is null or < 0 or > 10) {
            throw new ArgumentException("value must be a number between 0 and 10");
        }
    }

    public int? Score() {
        if (FirstRoll == 10) { // strike
            int? nextRoll = NextFrame?.FirstRoll;
            int? secondNextRoll = nextRoll == 10
                ? NextFrame!.NextFrame?.FirstRoll
                : NextFrame?.SecondRoll;

            return 10 + nextRoll + secondNextRoll;
        }

        if (FirstRoll + SecondRoll == 10) { // spare
            int? nextRoll = NextFrame?.FirstRoll;
            return 10 + nextRoll;
        }

        return FirstRoll + SecondRoll;
    }
    
    public override string ToString() {
        if (FirstRoll == 10) {
            return "X -";
        }
        if (FirstRoll + SecondRoll == 10) {
            return $"{FirstRoll} /";
        }
        return $"{FirstRoll} {SecondRoll}";
    }
}