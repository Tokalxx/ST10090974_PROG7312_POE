using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG7312_UI.DesignGenerate
{
    public class IdentifyAreaDesign
    {
        /// <summary>
        /// Design for the TextBlock
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public TextBlock CallNumberTextBlock(string x)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = x,
                Cursor = Cursors.Hand,
                FontFamily = new FontFamily("Arial"),
                FontSize = 20,
                Width = 100,
                Height = 35,
                Margin = new Thickness(5),
                TextAlignment = TextAlignment.Center,
            };
            return textBlock;
        }

        /// <summary>
        /// Design for the TextBlock
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public TextBlock DefinitionTextBlock(string x)
        {
            TextBlock textBlock = new TextBlock()
            {

                Text = x,
                Cursor = Cursors.Hand,
                FontFamily = new FontFamily("Arial"),
                FontSize = 20,
                Width = 400,
                Height = 45,
                Margin = new Thickness(5),
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            };

            return textBlock;
        }

        /// <summary>
        /// Changing the size of the stack panel dynamically
        /// </summary>
        /// <param name="stack1"></param>
        /// <param name="stack2"></param>
        /// <param name="check"></param>
        public void changeStackPanel(StackPanel stack1, StackPanel stack2, bool check)
        {
            if (check)
            {
                stack1.Width = 100;

                stack2.Width = 500;
            }
            else
            {
                stack1.Width = 500;

                stack2.Width = 100;
            }
        }
    }
}
