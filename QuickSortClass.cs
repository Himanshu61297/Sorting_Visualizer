using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace sorting
{
    class QuickSortClass
    {
        public static async Task QuickSortAsync(StackPanel stackPanel)
        {
            await QuickSortAsync(InitializationClass.currentRandomList, 0, InitializationClass.currentRandomList.Count-1, stackPanel);
        }

        static async Task QuickSortAsync(List<int> list, int low, int high, StackPanel stackPanel)
        {
            //For stopping the algorithm in case user wants to stop.
            if (SharedClass.IsActive == false)
            {
                return;
            }

            if (low < high)
            {                
                int p = await PartitionAsync(list, low, high, stackPanel);

                await QuickSortAsync(list, low, p - 1, stackPanel);                
                await QuickSortAsync(list, p + 1, high, stackPanel);
            }           
        }

        static async Task<int> PartitionAsync(List<int> list, int low, int high, StackPanel stackPanel)
        {
            int pivot = list[high];
            int j = low - 1;

            for (int i = low; i <= high - 1; i++)
            {
                //For stopping the algorithm in case user wants to stop.
                if (SharedClass.IsActive == false)
                {
                    break;
                }

                if (list[i] < pivot)
                {
                    j++;
                    SharedClass.SwapItems(i, j, stackPanel);
                }

                await Task.Delay(SharedClass.speed);
            }

            SharedClass.SwapItems(j + 1, high, stackPanel);
            return j + 1;
        }
    }
}
