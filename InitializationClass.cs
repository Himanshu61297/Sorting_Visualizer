using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace sorting
{
    class InitializationClass
    {
        public static List<int> mainRandomList = new List<int>();
        public static List<int> currentRandomList = new List<int>();
        public static List<ProgressBar> currentItemList = new List<ProgressBar>();
        public static List<ProgressBar> mainItemList = new List<ProgressBar>();

        public static void ResetLineItems(StackPanel stackPanel)
        {
            int barHeight = (int)currentItemList[0].Height;
            
            currentRandomList.Clear();
            currentRandomList.AddRange(mainRandomList);

            currentItemList.Clear();
            mainItemList.Clear();

            stackPanel.Children.Clear();

            Random rand = new Random();

            foreach(var value in mainRandomList)
            {
                ProgressBar bar = CreateItem(rand, barHeight, value);
                stackPanel.Children.Add(bar);
                currentItemList.Add(bar);
                mainItemList.Add(bar);
            }
        }

        static ProgressBar CreateItem(Random rand, int barHeight, int value=-1)
        {
            ProgressBar bar = new ProgressBar();
            bar.HorizontalAlignment = HorizontalAlignment.Stretch;
            bar.VerticalAlignment = VerticalAlignment.Center;
            bar.Height = barHeight;
            bar.Maximum = 1000;

            if (value == -1)
                bar.Value = rand.Next(1, 1000);
            else
                bar.Value = value;

            bar.Background = new SolidColorBrush(Colors.Transparent);

            return bar;
        }

        public static void InitializeLineItems(StackPanel stackPanel, int totalItems=0)
        {
            mainRandomList.Clear();
            mainItemList.Clear();
            currentRandomList.Clear();
            currentItemList.Clear();
            stackPanel.Children.Clear();

            Random rand = new Random();
            int barHeight = 5;

            int items = (int)(((int)Window.Current.Bounds.Height) / barHeight);
            if (totalItems > 0)
            {
                items = totalItems;
                barHeight = (int)(((int)Window.Current.Bounds.Height) / totalItems);
            }           

            for (int i = 1; i < items ; i++)
            {
                ProgressBar bar = CreateItem(rand, barHeight);

                mainRandomList.Add((int)bar.Value);
                currentRandomList.Add((int)bar.Value);

                stackPanel.Children.Add(bar);
                currentItemList.Add(bar);
                mainItemList.Add(bar);
            }
        }

    }
}
