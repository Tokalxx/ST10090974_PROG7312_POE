using System.Collections.ObjectModel;

namespace PROG7312_UI.Core
{
    public class ProgressReport
    {
        private static readonly ProgressReport _instance = new ProgressReport();
        private ObservableCollection<ReportModel> reportRB = new ObservableCollection<ReportModel>();
        private ObservableCollection<ReportModel> reportIA = new ObservableCollection<ReportModel>();

        private ProgressReport()
        {

        }

        /// <summary>
        /// The GetAchievements method returns the created instance from the top of the class. 
        /// </summary>
        /// <returns>_instance</returns>
        public static ProgressReport GetProgressReport()
        {
            return _instance;
        }

        //Might need to add more so that the reprot ids are not the same

        /// <summary>
        /// Generates the report of the players score and saves that information
        /// </summary>
        /// <param name="id"></param>Report ID
        /// <param name="time"></param> Time it took the player to complete the game
        /// <param name="status"></param> Status of the report to see if the player passed or not
        /// <param name="score"></param> The player's score
        public void GenerateReport(double time, bool status, int score)
        {

            reportRB.Add(new ReportModel("RP." + (reportRB.Count + 1), time, status, score));
        }

        public void GenerateIA(bool status, int score)
        {

            reportIA.Add(new ReportModel("RP." + (reportIA.Count + 1), status, score));
        }

        /// <summary>
        /// Method that will return the list to where it is being called
        /// </summary>
        /// <returns> ObservableCollection<ReportModel> report </returns>
        public ObservableCollection<ReportModel> GetReprotRB()
        {
            return reportRB;
        }

        public ObservableCollection<ReportModel> GetReprotIA()
        {
            return reportIA;
        }
    }

    public class ReportModel
    {
        public string reprotID { get; set; }
        public double endTime { get; set; }
        public bool attemptStatus { get; set; }
        public int userScore { get; set; }

        public ReportModel(string id, double time, bool status, int score)
        {
            reprotID = id;
            endTime = time;
            attemptStatus = status;
            userScore = score;
        }

        public ReportModel(string id, bool status, int score)
        {
            reprotID = id;
            attemptStatus = status;
            userScore = score;
        }
    }

}
