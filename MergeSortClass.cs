using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace sorting
{
    class MergeSortClass
    {
        public static async Task MergeSortAsync(List<int> NumberList, List<ProgressBar> ItemList, int startIndex, int endIndex, StackPanel stackPanel)
        {
            int mid;
            if (startIndex < endIndex)
            {
                mid = (startIndex + endIndex) / 2;

                await MergeSortAsync(NumberList, ItemList, startIndex, mid, stackPanel);
                await MergeSortAsync(NumberList, ItemList, mid + 1, endIndex, stackPanel);
                await MergeAsync(NumberList, ItemList, startIndex, mid, mid + 1, endIndex, stackPanel);
            }

        }

        static async Task MergeAsync(List<int> numberList, List<ProgressBar> itemsList, int startIndex1, int endIndex1, int startIndex2, int endIndex2, StackPanel stackPanel)
        {
            int[] temp = new int[InitializationClass.currentRandomList.Count];
            ProgressBar[] temp2 = new ProgressBar[InitializationClass.currentItemList.Count];
            
            int i, j, k;
            i = startIndex1;
            j = startIndex2;
            k = 0;

            while (i <= endIndex1 && j <= endIndex2)
            {
                //For stopping the algorithm in case user wants to stop.
                if (SharedClass.IsActive == false)
                {
                    return;
                }

                if (numberList[i] < numberList[j])
                {
                    temp[k] = numberList[i];
                    temp2[k] = itemsList[i];

                    k++;
                    i++;
                }

                else
                {
                    temp[k] = numberList[j];
                    temp2[k] = itemsList[j];

                    k++;
                    j++;
                }

            }

            while (i <= endIndex1)
            {
                //For stopping the algorithm in case user wants to stop.
                if (SharedClass.IsActive == false)
                {
                    return;
                }

                temp[k] = numberList[i];
                temp2[k] = itemsList[i];

                k++;
                i++;
            }


            while (j <= endIndex2)
            {
                //For stopping the algorithm in case user wants to stop.
                if (SharedClass.IsActive == false)
                {
                    return;
                }

                temp[k] = numberList[j];
                temp2[k] = itemsList[j];

                k++;
                j++;
            }

            for (i = startIndex1, j = 0; i <= endIndex2; i++, j++)
            {
                //For stopping the algorithm in case user wants to stop.
                if (SharedClass.IsActive == false)
                {
                    return;
                }

                numberList[i] = temp[j];
                itemsList[i] = temp2[j];

                ProgressBar bar = new ProgressBar();
               
                bar.Height = temp2[j].Height;
                bar.Maximum = temp2[j].Maximum;
                bar.Minimum = temp2[j].Minimum;
                bar.Value = temp2[j].Value;
                bar.HorizontalAlignment =  Windows.UI.Xaml.HorizontalAlignment.Stretch;

                bar.Background = new SolidColorBrush(Colors.Transparent);


                stackPanel.Children.RemoveAt(i);
                stackPanel.Children.Insert(i, bar);               

                await Task.Delay(SharedClass.speed);

            }
        }
    }
}
