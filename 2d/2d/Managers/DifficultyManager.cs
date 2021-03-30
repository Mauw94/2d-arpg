namespace _2d.Managers
{
    public class DifficultyManager
    {
        private const int _difficultyIncrease = 10;

        public DifficultyManager()
        {
        }

        public static int GetSpawnRate(int score)
        {
            return score / _difficultyIncrease == 0 ? 1 : score / _difficultyIncrease;
        }
    }
}
