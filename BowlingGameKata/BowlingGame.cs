namespace BowlingGameKata
{
    public class BowlingGame
    {
        private readonly List<int[]> rolls = [];

        public int AddRolls(IEnumerable<int[]> list)
        {
            foreach (int[] roll in list) AddRoll(roll);
            return rolls.Count;
        }
        public int AddRoll(int[] roll)
        {
            // checks constraints
            var shouldAdd = IsGameInProgress() || IsSpareGameBonus() || IsStrikeGameBonus();
            if (!shouldAdd) return rolls.Count;

            // Act
            int[] entry = roll.Length >= 2 ? roll.Take(2).ToArray() : [roll[0], 0];
            rolls.Add(entry);

            return rolls.Count;
        }
        #region AddRoll helpers
        private bool IsGameInProgress() => rolls.Count < 10;
        private bool IsSpareGameBonus() => rolls.Count == 10 && IsSpare(rolls[9]);
        private bool IsStrikeGameBonus() => 10 <= rolls.Count && rolls.Count < 12 && IsStrike(rolls[9]);
        #endregion

        public int GetScore()
        {
            int score = 0;
            for (int i = 0; i < rolls.Count; i++)
            {
                // checks constraints
                if (i >= 10) break;

                // Act
                int[] roll = rolls[i];

                // Add the current roll's score
                score += roll.Sum();

                // compute special scores
                score = ComputeSpareScore(score, i, roll);
                score = ComputeStrikeScore(score, i, roll);
            }
            return score;
        }
        private int ComputeSpareScore(int score, int i, int[] roll)
        {
            // checks constraints
            var shouldCompute = IsSpare(roll) && i + 1 < rolls.Count;
            if (!shouldCompute) return score;

            // Act
            score += rolls[i + 1][0]; // Add the next roll's first pin as bonus            

            return score;
        }
        private int ComputeStrikeScore(int score, int i, int[] roll)
        {
            // checks constraints
            var shouldCompute = IsStrike(roll) && i + 1 < rolls.Count;
            if (!shouldCompute) return score;

            // Act
            score += rolls
                .Skip(i + 1)
                .SelectMany(roll => roll)
                .Where(roll => roll > 0)
                .Take(2)
                .Sum();

            return score;
        }
        #region GetScore helpers
        private bool IsSpare(int[] roll) => roll[0] < 10 && roll.Sum() == 10;
        private bool IsStrike(int[] roll) => roll[0] == 10;
        #endregion
    }
}
