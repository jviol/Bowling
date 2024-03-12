namespace BowlingApplication.Model;

public class Frame {
    public Frame? NextFrame { get; set; }
    private readonly int _firstRoll;
    private int? _secondRoll;

    public Frame(int firstRoll) {
        CheckRollValue(firstRoll);
        _firstRoll = firstRoll;
    }

    public void SetSecondRoll(int value) {
        CheckRollValue(value);
        if (_firstRoll + value > 10) {
            throw new ArgumentException(
                "Second roll cannot exceed the number of pins left standing after the first roll");
        }

        _secondRoll = value;
    }

    private static void CheckRollValue(int? value) {
        if (value is null or < 0 or > 10) {
            throw new ArgumentException("value must be a number between 0 and 10");
        }
    }

    public int? Score() {
        if (_firstRoll == 10) { // strike
            int? nextRoll = NextFrame?._firstRoll;
            int? secondNextRoll = nextRoll == 10
                ? NextFrame!.NextFrame?._firstRoll
                : NextFrame?._secondRoll;

            return 10 + nextRoll + secondNextRoll;
        }

        if (_firstRoll + _secondRoll == 10) { // spare
            int? nextRoll = NextFrame?._firstRoll;
            return 10 + nextRoll;
        }

        return _firstRoll + _secondRoll;
    }
    
    public bool IsComplete() {
        return _firstRoll == 10 || _secondRoll != null;
    }
    
    public override string ToString() {
        if (_firstRoll == 10) {
            return "X -";
        }
        if (_firstRoll + _secondRoll == 10) {
            return $"{_firstRoll} /";
        }
        return $"{_firstRoll} {_secondRoll}";
    }
}