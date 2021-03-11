namespace _2d.Engine.Utils
{
    /// <summary>
    /// Game score class.
    /// </summary>
    public static class Score
    {
        public static int CurrentScore { get; set; }

        public const int MaxScore = 10;

        public static void IncreaseScore()
        {
            CurrentScore++;
            if (CurrentScore >= MaxScore)
            {
                CurrentScore = MaxScore;
                // todo: game ends.
            }
        }

        public static void DecreaseScore()
        {
            CurrentScore--;
        }
    }
}
