using PROG7312_UI.Core;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReplacingBooksView.xaml
    /// </summary>
    public partial class ReplacingBooksView : UserControl
    {
        Random random = new Random();
        ProgressReport pr = ProgressReport.GetProgressReport();
        private DateTime generateStart;
        private Stopwatch stopwatch;
        private DispatcherTimer timer;
        private ObservableCollection<string> unorderedBooks = new ObservableCollection<string>();
        private ObservableCollection<string> orderedBooks = new ObservableCollection<string>();
        private ObservableCollection<string> correctOrder = new ObservableCollection<string>();
        ProgressReport rp = ProgressReport.GetProgressReport();
        Acheivements ach = Acheivements.GetAcheivements();


        public ReplacingBooksView()
        {
            InitializeComponent();


            unorderedView.ItemsSource = unorderedBooks;
            orderedView.ItemsSource = orderedBooks;
            unorderedView.MouseDoubleClick += UnorderedView_MouseDoubleClick;
            orderedView.MouseDoubleClick += OrderedView_MouseDoubleClick;
            ReportsListView.ItemsSource = rp.GetReprotRB();
            AcheivementsView.ItemsSource = ach.GetAcheivementsList();
            stopwatch = new Stopwatch();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Method that is exacuted when the player double clicks on the item in the Unordered List
        /// When it exacutes it will move the item to the Ordered List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnorderedView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (unorderedView.SelectedItem != null)
                {
                    string selectedItem = unorderedView.SelectedItem as string;
                    unorderedBooks.Remove(selectedItem);
                    orderedBooks.Add(selectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Method that is exacuted when the player double clicks on the item in the Ordered List
        /// When it exacutes it will move the item to the Unordered List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderedView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (orderedView.SelectedItem != null)
                {
                    string selectedItem = orderedView.SelectedItem as string;
                    orderedBooks.Remove(selectedItem);
                    unorderedBooks.Add(selectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Method that when exacuted will display the descriptions for the achievements of the lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcheivementsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                if (AcheivementsView.SelectedItem != null)
                {
                    // Cast the selected item to your data type (AcheivementModels)
                    AcheivementModels selectedItem = AcheivementsView.SelectedItem as AcheivementModels;

                    if (selectedItem != null)
                    {
                        MessageBox.Show($"Achievement Description: \n{selectedItem.AcheiveDescrip}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Method that will 
        /// 1st. Start the time tracker
        /// 2nd. Generate the random itenms for the player to sort 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            timer.Stop();
            stopwatchTextBlock.Text = "00:00";

            stopwatch.Start();
            timer.Start();

            unorderedBooks.Clear();
            orderedBooks.Clear();
            generateStart = DateTime.Now;

            int num = 0;
            try
            {
                while (num < 10)
                {
                    string tempDewey = generateBooks();
                    if (!unorderedBooks.Contains(tempDewey))
                    {
                        unorderedBooks.Add(tempDewey);
                        num++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            buttonGenerate.IsEnabled = false;
            buttonCheck.IsEnabled = true;
        }

        /// <summary>
        /// Method that will 
        /// 1st. Stop the time tracker
        /// 2nd. Sort the original unordered items
        /// 3rd. Compare the players list with the sorted on and return the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheck_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();

            int scoreCounter = 0;
            correctOrder = new ObservableCollection<string>(orderedBooks);


            TimeSpan eTime = DateTime.Now - generateStart;
            double eSeconds = Math.Round(eTime.TotalSeconds, 2);

            try
            {
                for (int i = 0; i < correctOrder.Count; i++)
                {
                    for (int j = i + 1; j < correctOrder.Count; j++)
                    {
                        if (correctOrder[j].CompareTo(correctOrder[i]) < 0)
                        {
                            string temp = correctOrder[j];
                            correctOrder[j] = correctOrder[i];
                            correctOrder[i] = temp;
                        }
                    }
                }

                for (int i = 0; i < orderedBooks.Count; i++)
                {

                    if (orderedBooks[i] == correctOrder[i])
                    {
                        scoreCounter++;
                    }
                }

                if (scoreCounter == 10)
                {
                    pr.GenerateReport(eSeconds, true, scoreCounter);
                    ach.checkForAcheievements(pr.GetReprotRB());

                }
                else
                {
                    pr.GenerateReport(eSeconds, false, scoreCounter);
                    ach.checkForAcheievements(pr.GetReprotRB());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            unorderedBooks.Clear();
            orderedBooks.Clear();
            buttonCheck.IsEnabled = false;
            buttonGenerate.IsEnabled = true;
        }


        /// <summary>
        /// The method generates the random items that the player will sort
        /// </summary>
        /// <returns>A string of the random items for the list</returns>
        public string generateBooks()
        {
            string ranDeweyNum1 = random.Next(1000).ToString("000");
            string ranDeweyNum2 = random.Next(100).ToString("00");
            return $"{ranDeweyNum1}.{ranDeweyNum2} {generateAuther()}";

        }



        /// <summary>
        /// The method will return the random string for the items in the above method
        /// </summary>
        /// <returns>A string that is the random string for the auther name</returns>
        public string generateAuther()
        {
            string[] tempAuth = ach.getAuthorNames();

            Random random = new Random();

            // Fisher-Yates shuffle
            for (int i = tempAuth.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                // Swap tempAuth[i] and tempAuth[j]
                string temp = tempAuth[i];
                tempAuth[i] = tempAuth[j];
                tempAuth[j] = temp;
            }

            // Now, tempAuth is shuffled, return a random author
            return tempAuth[random.Next(0, tempAuth.Length)];
        }



        /// <summary>
        /// Method that will compare the strings and then with each other.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int Compare(string other)
        {
            int results = this.ToString().CompareTo(other.ToString());

            return results;
        }

        /// <summary>
        /// The method tracks the time it takes for the player to complate the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = stopwatch.Elapsed;
            string formattedTime = string.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds);
            stopwatchTextBlock.Text = formattedTime;
        }


    }
}
