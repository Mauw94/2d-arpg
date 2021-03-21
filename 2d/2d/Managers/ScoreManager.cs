using _2d.Sprites;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace _2d.Managers
{
    public class ScoreManager
    {
        private static string _fileName = "scores.xml";

        public List<Score> HighScores { get; set; }

        private List<Score> Scores { get; set; }

        public ScoreManager()
            : this(new List<Score>())
        {

        }

        public ScoreManager(List<Score> scores)
        {
            Scores = scores;

            UpdateHighScores();
        }

        public static ScoreManager Load()
        {
            if (!File.Exists(_fileName))
                return new ScoreManager();

            using var reader = new StreamReader(new FileStream(_fileName, FileMode.Open));
            var serializer = new XmlSerializer(typeof(List<Score>));

            var scores = (List<Score>)serializer.Deserialize(reader);

            return new ScoreManager(scores);
        }

        public static void Save(ScoreManager scoreManager)
        {
            using var reader = new StreamWriter(new FileStream(_fileName, FileMode.Create));
            var serializer = new XmlSerializer(typeof(List<Score>));

            serializer.Serialize(reader, scoreManager.Scores);
        }

        public void AddScore(Score score)
        {
            Scores.Add(score);

            Scores = Scores.OrderByDescending(c => c.Value).ToList();

            UpdateHighScores();
        }

        void UpdateHighScores()
        {
            HighScores = Scores.Take(5).ToList();
        }
    }
}
