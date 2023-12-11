using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PROG7312_UI.Core
{
    public class CallNumberAcheivements
    {
        private static readonly CallNumberAcheivements _instance = new CallNumberAcheivements();
        private ObservableCollection<ScoreModel> callNumberScore = new ObservableCollection<ScoreModel>();
        int attemptNum = 0;
        int scoreNum = 0;


        public CallNumberAcheivements()
        {
            callNumberScore.Add(new ScoreModel(1, "Score Gate 01", 10, "Locked"));
            callNumberScore.Add(new ScoreModel(2, "Score Gate 02", 15, "Locked"));
            callNumberScore.Add(new ScoreModel(3, "Score Gate 03", 25, "Locked"));
            callNumberScore.Add(new ScoreModel(4, "Score Gate 04", 30, "Locked"));
            callNumberScore.Add(new ScoreModel(5, "Score Gate 05", 35, "Locked"));
        }

        /// <summary>
        /// Returns this class instance
        /// </summary>
        /// <returns></returns>
        public static CallNumberAcheivements GetCallNumberAcheivements()
        {
            return _instance;
        }

        /// <summary>
        /// Sets the attempt number
        /// </summary>
        /// <param name="num"></param>
        public void SetAttemptNum(int num)
        {
            attemptNum += num;
        }

        /// <summary>
        /// Returns the attempt method
        /// </summary>
        /// <returns>attemptNum</returns>
        public int GetAttemptNum()
        {
            return attemptNum;
        }

        /// <summary>
        /// Sets the score 
        /// </summary>
        /// <param name="num"></param>
        public void SetScoreNum(int num)
        {
            scoreNum += num;
            if (scoreNum < 0)
            {
                scoreNum = 0;
            }
        }


        /// <summary>
        /// Returns the score
        /// </summary>
        /// <returns></returns>
        public int GetScoreNum()
        {
            return scoreNum;
        }

        /// <summary>
        /// Returns the call number score
        /// </summary>
        /// <returns>callNumberScore</returns>
        public ObservableCollection<ScoreModel> getScoreList()
        {
            return callNumberScore;
        }

        /// <summary>
        /// Checks to see the score that has been unlocked
        /// </summary>
        public void checkScore()
        {
            foreach (ScoreModel x in callNumberScore)
            {
                if (x.ScoreStatus == "Locked" &&
                    x.ScorePoints <= scoreNum)
                {
                    x.ScoreStatus = "Unlocked";
                    MessageBox.Show($"Congradulation!!! You unlocked Achievement: {x.ScoreName}");
                }
            }
        }
    }

    public class ScoreModel : INotifyPropertyChanged
    {
        private int scoreId;
        private string scoreName;
        private int scorePoints;
        private string scoreStatus;
        public int ScoreId
        {
            get
            {
                return scoreId;
            }
            set
            {
                scoreId = value;
                OnPropertyChanged(nameof(ScoreId));
            }
        }

        public string ScoreName
        {
            get
            {
                return scoreName;
            }
            set
            {
                scoreName = value;
                OnPropertyChanged(nameof(ScoreName));
            }
        }


        public int ScorePoints
        {
            get
            {
                return scorePoints;
            }
            set
            {
                scorePoints = value;
                OnPropertyChanged(nameof(ScorePoints));
            }
        }

        public string ScoreStatus
        {
            get
            {
                return scoreStatus;
            }
            set
            {
                scoreStatus = value;
                OnPropertyChanged(nameof(ScoreStatus));
            }
        }

        public ScoreModel(int scoreId, string scoreName, int scorePoints, string scoreStatus)
        {
            this.ScoreId = scoreId;
            this.ScoreName = scoreName;
            this.ScorePoints = scorePoints;
            this.ScoreStatus = scoreStatus;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
