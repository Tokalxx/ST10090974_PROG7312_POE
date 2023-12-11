using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PROG7312_UI.Core
{
    public class Acheivements
    {
        private static readonly Acheivements _instance = new Acheivements();
        TimeSpan timeCheckAcheivement1 = TimeSpan.FromSeconds(20);
        TimeSpan timeCheckAcheivement2 = TimeSpan.FromSeconds(15);
        TimeSpan timeCheckAcheivement3 = TimeSpan.FromSeconds(10);
        private ObservableCollection<AcheivementModels> acheivements = new ObservableCollection<AcheivementModels>();
        string[] authorNames = {
                    "Emily Anderson",
                    "Benjamin Turner",
                    "Jasmine Martinez",
                    "Liam Campbell",
                    "Ava Nguyen",
                    "Jackson Cooper",
                    "Isabella Wright",
                    "Henry Wood",
                    "Olivia Mitchell",
                    "Samuel Walker",
                    "Grace Thompson",
                    "Ethan Collins",
                    "Sophia Brooks",
                    "Noah Parker",
                    "Mia Hayes",
                    "Alexander Simmons",
                    "Ella Griffin",
                    "Jack Evans",
                    "Amelia Murphy",
                    "Mason Morgan",
                    "Harper Foster",
                    "Aiden Cox",
                    "Abigail Fisher",
                    "Lucas Bennett",
                    "Scarlett Reed",
                    "Oliver Price",
                    "Lily Ward",
                    "Gabriel Ross",
                    "Chloe Powell",
                    "Wyatt Harrison",
                    "Zoey Watson",
                    "Logan Kelly",
                    "Aurora Henderson",
                    "Caleb Sullivan",
                    "Penelope Russell",
                    "Owen Perry",
                    "Layla Palmer",
                    "Lincoln Walsh",
                    "Hazel Dean",
                    "Julian Foster",
                    "Stella Weaver",
                    "Carter Tucker",
                    "Riley Caldwell",
                    "Aubrey Willis",
                    "Gavin Bates",
                    "Aria Newton",
                    "Daniel Fletcher",
                    "Peyton Fitzgerald",
                    "Leo Holmes",
                    "Madeline Griffin"
                };


        private Acheivements()
        {
            acheivements.Add(new AcheivementModels("Ach.001", "Quick Thinker", "Get a pass with a time of 20 seconds or less", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.002", "Faster Then Before", "Get a pass with a time of 15 seconds or less", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.003", "Impossible Time", "Get a pass with a time of 10 seconds or less", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.004", "Fast Learner", "Get 2 passes", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.005", "Master 1 Kick", "Get 5 passes", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.006", "Strick, Your Out!!!", "Get 3 passes in a row", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.007", "On A Roll!!!", "Get 5 passes in a row", "Locked"));
        }

        /// <summary>
        /// The GetAchievements method returns the created instance from the top of the class. 
        /// </summary>
        /// <returns>_instance</returns>
        public static Acheivements GetAcheivements()
        {
            return _instance;
        }

        /// <summary>
        /// This Method returns the created list with all the information of the current achievements.
        /// </summary>
        /// <returns> ObservableCollection<AcheivementModels> acheivements </returns>
        public ObservableCollection<AcheivementModels> GetAcheivementsList()
        {
            return acheivements;
        }

        /// <summary>
        /// This methods takes the list of reports from where it is called and then goes through that list to see if
        /// the user has unlocked any achievements.
        /// </summary>
        /// <param name="list"></param>Report List
        public void checkForAcheievements(ObservableCollection<ReportModel> list)
        {
            try
            {
                if (acheivements[0].LockStatus.ToLower() == "locked" && checkAcheivement1(list))
                {
                    MessageBox.Show("Acheivement 1 Unlocked");
                }

                if (acheivements[1].LockStatus.ToLower() == "locked" && checkAcheivement2(list))
                {
                    MessageBox.Show("Acheivement 2 Unlocked");

                }
                if (acheivements[2].LockStatus.ToLower() == "locked" && checkAcheivement3(list))
                {
                    MessageBox.Show("Acheivement 3 Unlocked");

                }
                if (acheivements[3].LockStatus.ToLower() == "locked" && checkAcheivement4(list))
                {
                    MessageBox.Show("Acheivement 4 Unlocked");

                }
                if (acheivements[4].LockStatus.ToLower() == "locked" && checkAcheivement5(list))
                {
                    MessageBox.Show("Acheivement 5 Unlocked");

                }
                if (acheivements[5].LockStatus.ToLower() == "locked" && checkAcheivement6(list))
                {
                    MessageBox.Show("Acheivement 6 Unlocked");

                }
                if (acheivements[6].LockStatus.ToLower() == "locked" && checkAcheivement7(list))
                {
                    MessageBox.Show("Acheivement 7 Unlocked");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        public string[] getAuthorNames()
        {
            return authorNames;
        }
        /// <summary>
        /// Method checks through the list provided to see if the player has a time below 20 seconds
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement1(ObservableCollection<ReportModel> list)
        {
            foreach (ReportModel x in list)
            {
                if (x.endTime < timeCheckAcheivement1.TotalSeconds && x.attemptStatus == true)
                {

                    acheivements[0].LockStatus = "Unlocked";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method checks through the list provided to see if the player has a time below 15 seconds
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement2(ObservableCollection<ReportModel> list)
        {
            foreach (ReportModel x in list)
            {
                if (x.endTime < timeCheckAcheivement2.TotalSeconds && x.attemptStatus == true)
                {

                    acheivements[1].LockStatus = "Unlocked";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method checks through the list provided to see if the player has a time below 10 seconds
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement3(ObservableCollection<ReportModel> list)
        {
            foreach (ReportModel x in list)
            {
                if (x.endTime < timeCheckAcheivement3.TotalSeconds && x.attemptStatus == true)
                {

                    acheivements[2].LockStatus = "Unlocked";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// The method checks to see if the player has a total of 2 passes in their reports
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement4(ObservableCollection<ReportModel> list)
        {
            int num = 0;

            foreach (ReportModel x in list)
            {
                if (x.attemptStatus)
                {
                    num++;
                }
            }

            if (num >= 2)
            {
                acheivements[3].LockStatus = "Unlocked";
                return true;
            }
            return false;
        }

        /// <summary>
        /// The method checks to see if the player has a total of 5 passes in their reports
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement5(ObservableCollection<ReportModel> list)
        {
            int num = 0;

            foreach (ReportModel x in list)
            {
                if (x.attemptStatus)
                {
                    num++;
                }
            }

            if (num >= 5)
            {
                acheivements[4].LockStatus = "Unlocked";
                return true;
            }
            return false;
        }

        /// <summary>
        /// The method checks the players report to see if they have 3 passes in a row
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement6(ObservableCollection<ReportModel> list)
        {
            int num = 0;

            foreach (ReportModel x in list)
            {
                if (x.attemptStatus)
                {
                    num++;
                }
                else
                {
                    num = 0;
                }
            }

            if (num >= 3)
            {
                acheivements[5].LockStatus = "Unlocked";
                return true;
            }
            else
            {
                num = 0;
            }

            return false;
        }

        /// <summary>
        /// The method checks the players report to see if they have 5 passes in a row
        /// </summary>
        /// <param name="list"></param>Report List
        /// <returns> true </returns>
        public bool checkAcheivement7(ObservableCollection<ReportModel> list)
        {
            int num = 0;

            foreach (ReportModel x in list)
            {
                if (x.attemptStatus)
                {
                    num++;
                }
                else
                {
                    num = 0;
                }
            }

            if (num >= 5)
            {
                acheivements[6].LockStatus = "Unlocked";
                return true;
            }
            else
            {
                num = 0;
            }

            return false;
        }


    }

    public class AcheivementModels : INotifyPropertyChanged
    {
        private string acheiveId;
        private string achieveName;
        private string acheiveDescrip;
        private string lockStatus;

        public string AcheiveId
        {
            get { return acheiveId; }
            set
            {
                if (acheiveId != value)
                {
                    acheiveId = value;
                    OnPropertyChanged(nameof(AcheiveId));
                }
            }
        }

        public string AchieveName
        {
            get { return achieveName; }
            set
            {
                if (achieveName != value)
                {
                    achieveName = value;
                    OnPropertyChanged(nameof(AchieveName));
                }
            }
        }

        public string AcheiveDescrip
        {
            get { return acheiveDescrip; }
            set
            {
                if (acheiveDescrip != value)
                {
                    acheiveDescrip = value;
                    OnPropertyChanged(nameof(AcheiveDescrip));
                }
            }
        }

        public string LockStatus
        {
            get { return lockStatus; }
            set
            {
                if (lockStatus != value)
                {
                    lockStatus = value;
                    OnPropertyChanged(nameof(LockStatus));
                }
            }
        }

        public AcheivementModels(string acheiveId, string achieveName, string acheiveDescrip, string lockStatus)
        {
            this.AcheiveId = acheiveId;
            this.AchieveName = achieveName;
            this.AcheiveDescrip = acheiveDescrip;
            this.LockStatus = lockStatus;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
