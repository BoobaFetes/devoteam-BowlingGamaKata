namespace BowlingGameKata
{
    public class BowlingGame
    {
        private readonly List<int[]> rolls = [];
        public BowlingGame() { }

        public int AddRolls(IEnumerable<int[]> list)
        {
            foreach (int[] roll in list) AddRoll(roll);
            return rolls.Count;
        }
        public int AddRoll(int[] roll)
        {
            if (IsGameInProgress() || IsSpareGameBonus() || IsStrikeGameBonus())
            {
                int[] entry = roll.Length >= 2 ? roll.Take(2).ToArray() : [roll[0], 0];
                rolls.Add(entry);
            }

            return rolls.Count;
        }
        private bool IsGameInProgress() => rolls.Count < 10;
        private bool IsSpareGameBonus()
        {
            return rolls.Count == 10 && IsSpare(rolls[9]);
        }
        private bool IsStrikeGameBonus()
        {
            return 10 <= rolls.Count && rolls.Count < 12 && IsStrike(rolls[9]);
        }
        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < rolls.Count; i++)
            {
                if (i >= 10) break;
                int[] roll = rolls[i];

                score += roll.Sum();

                // Check for spare
                score = ComputeSpare(score, i, roll);
                score = ComputeStrike(score, i, roll);
            }
            return score;
        }

        private int ComputeSpare(int score, int i, int[] roll)
        {
            if (IsSpare(roll) && i + 1 < rolls.Count)
            {
                score += rolls[i + 1][0]; // Add the next roll's first pin as bonus
            }

            return score;
        }

        private int ComputeStrike(int score, int i, int[] roll)
        {
            if (IsStrike(roll) && i + 1 < rolls.Count)
            {
                score += rolls
                    .Skip(i + 1)
                    .SelectMany(roll => roll)
                    .Where(roll => roll > 0)
                    .Take(2)
                    .Sum();
            }

            return score;
        }

        private bool IsSpare(int[] roll) => roll[0] < 10 && roll.Sum() == 10;
        private bool IsStrike(int[] roll) => roll[0] == 10;
    }
}
