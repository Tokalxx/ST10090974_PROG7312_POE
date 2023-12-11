using PROG7312_UI.Core;
using PROG7312_UI.DesignGenerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for IdentifyAreaView.xaml
    /// </summary>
    public partial class IdentifyAreaView : UserControl
    {

        IdentifyingDefinitions idd = IdentifyingDefinitions.GetDefinition();
        ProgressReport report = ProgressReport.GetProgressReport();
        IdentifyAreaDesign idDesign = new IdentifyAreaDesign();
        Dictionary<string, string> checkDictionary = new Dictionary<string, string>();
        private TextBlock callNumberTextBlock = null;
        bool checkGenerateMethod = true;
        Random ran = new Random();
        int TempNumScore = 0;
        bool checkbutton1 = true;

        public IdentifyAreaView()
        {
            InitializeComponent();

            ReportsListView.ItemsSource = report.GetReprotIA();
        }


        /// <summary>
        /// One of the Methods used to populate the stack panels. The Left with description and the right with call numbner
        /// </summary>
        private void PopulateDesciptionTextBlock()
        {
            Dictionary<string, string> tempDictionary = idd.GetShuffledDictionary();

            List<string> callNumbers = tempDictionary.Keys.ToList();
            List<string> calDescription = tempDictionary.Values.ToList();


            foreach (string x in callNumbers.OrderBy(x => ran.Next()))
            {
                TextBlock callTextBlock = idDesign.CallNumberTextBlock(x);
                callTextBlock.MouseLeftButtonDown += Definition_MouseLeftButtonClick;

                RightStackPanel.Children.Add(callTextBlock);
            }

            foreach (string x in calDescription.Take(4))
            {


                TextBlock definitionTextBlock = idDesign.DefinitionTextBlock(x);
                definitionTextBlock.MouseLeftButtonUp += Call_MouseButtonClick;

                LeftStackPanel.Children.Add(definitionTextBlock);

            }
            idDesign.changeStackPanel(LeftStackPanel, RightStackPanel, checkGenerateMethod);

            checkGenerateMethod = true;
        }

        /// <summary>
        /// One of the Methods used to populate the stack panels. The Left with call numbers and the right with description
        /// </summary>
        private void PopulateCallNumberTextBlock()
        {

            Dictionary<string, string> tempDictionary = idd.GetShuffledDictionary();

            List<string> callNumbers = tempDictionary.Keys.ToList();
            List<string> calDescription = tempDictionary.Values.ToList();


            foreach (string x in callNumbers.Take(4))
            {
                TextBlock callTextBlock = idDesign.CallNumberTextBlock(x);
                callTextBlock.MouseLeftButtonDown += Call_MouseButtonClick;

                LeftStackPanel.Children.Add(callTextBlock);


            }
            foreach (string x in calDescription.OrderBy(x => ran.Next()))
            {


                TextBlock definitionTextBlock = idDesign.DefinitionTextBlock(x);
                definitionTextBlock.MouseLeftButtonUp += Definition_MouseLeftButtonClick;

                RightStackPanel.Children.Add(definitionTextBlock);

            }

            idDesign.changeStackPanel(LeftStackPanel, RightStackPanel, checkGenerateMethod);
            checkGenerateMethod = false;
        }

        /// <summary>
        /// This click event is used for the user to assign the key to a TextBlock variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Call_MouseButtonClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                callNumberTextBlock = (TextBlock)sender;
                callNumberTextBlock.Background = Brushes.Yellow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// This click event is used for the assign the key and value to the user dictionary 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Definition_MouseLeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (callNumberTextBlock != null)
                {


                    if (!checkGenerateMethod)
                    {
                        TextBlock descriptTextBlock = (TextBlock)sender;
                        checkDictionary.Add(callNumberTextBlock.Text, descriptTextBlock.Text);
                        callNumberTextBlock.Background = Brushes.Gray;
                        callNumberTextBlock.IsHitTestVisible = false;
                        descriptTextBlock.Background = Brushes.Gray;
                        descriptTextBlock.IsHitTestVisible = false;

                        callNumberTextBlock = null;
                    }
                    else
                    {
                        TextBlock descriptTextBlock = (TextBlock)sender;
                        checkDictionary.Add(descriptTextBlock.Text, callNumberTextBlock.Text);
                        callNumberTextBlock.Background = Brushes.Gray;
                        callNumberTextBlock.IsHitTestVisible = false;
                        descriptTextBlock.Background = Brushes.Gray;
                        descriptTextBlock.IsHitTestVisible = false;

                        callNumberTextBlock = null;
                    }
                }
                else
                {
                    MessageBox.Show("Select Call Number First");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// This clcik event will check the answers in the user dictionay with the one from IdentifyingDefinitions
        /// to give them their score.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttonAnswer.IsEnabled = false;
                buttonClear.IsEnabled = false;
                buttonGenerate.IsEnabled = true;

                foreach (KeyValuePair<string, string> x in idd.GetDeweyDictionary())
                {
                    if (checkDictionary.TryGetValue(x.Key, out string area))
                    {
                        if (x.Value.Equals(area))
                        {
                            foreach (TextBlock tb in LeftStackPanel.Children)
                            {
                                if (tb.Text == x.Key || tb.Text == x.Value)
                                {
                                    tb.Background = Brushes.LimeGreen;
                                }
                            }
                            TempNumScore++;
                        }
                    }
                }


                bool status = false;
                if (TempNumScore >= 3)
                {
                    status = true;
                }
                fillProgressBar(TempNumScore);
                report.GenerateIA(status, TempNumScore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// This clcik event will generate the items for both panels
        /// This method also changes from panel to panel for the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LeftStackPanel.Children.Clear();
                RightStackPanel.Children.Clear();
                checkDictionary.Clear();
                progressBarResults.Value = 0;
                textBlockScore.Text = "";
                buttonAnswer.IsEnabled = true;
                buttonClear.IsEnabled = true;
                buttonGenerate.IsEnabled = false;
                TempNumScore = 0;

                if (checkGenerateMethod)
                {
                    PopulateCallNumberTextBlock();
                }
                else
                {
                    PopulateDesciptionTextBlock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// This method will change the progress bar to visually show the user how much they got wrong
        /// </summary>
        /// <param name="score">Int of hw many the user got right.</param>
        public void fillProgressBar(int score)
        {
            switch (score)
            {
                case 1:
                    progressBarResults.Value = 25;
                    progressBarResults.Foreground = Brushes.Red;
                    textBlockScore.Text = "25%";
                    break;
                case 2:
                    progressBarResults.Value = 50;
                    progressBarResults.Foreground = Brushes.Orange;
                    textBlockScore.Text = "50%";
                    break;
                case 3:
                    progressBarResults.Value = 75;
                    progressBarResults.Foreground = Brushes.Yellow;
                    textBlockScore.Text = "75%";
                    break;
                case 4:
                    progressBarResults.Value = 100;
                    progressBarResults.Foreground = Brushes.Green;
                    textBlockScore.Text = "100%";
                    break;
            }
        }

        /// <summary>
        /// This event will clear all items in the dictionary and then reset the display for the users.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            checkDictionary.Clear();
            foreach (TextBlock x in LeftStackPanel.Children)
            {
                x.Background = Brushes.Transparent;
                x.IsHitTestVisible = true;
            }
            foreach (TextBlock x in RightStackPanel.Children)
            {
                x.Background = Brushes.Transparent;
                x.IsHitTestVisible = true;
            }
        }
    }
}
