using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace sorting
{
    class SelectionSortClass
    {
        public static async Task SelectionSortAsync(StackPanel stackPanel)
        {
            for (int j = 0; j < InitializationClass.currentRandomList.Count - 1; j++)
            {
                int small = j;


                for (int i = j + 1; i < InitializationClass.currentRandomList.Count; i++)
                {
                    //For stopping the algorithm in case user wants to stop.
                    if (SharedClass.IsActive == false)
                    {
                        return;
                    }

                    if (InitializationClass.currentRandomList[i] < InitializationClass.currentRandomList[small])
                    {                        
                        small = i;
                    }
                    else
                    {
                        
                    }
                }

                SharedClass.SwapItems(j, small, stackPanel);

                await Task.Delay(SharedClass.speed);                

            }

        }
    }
}
