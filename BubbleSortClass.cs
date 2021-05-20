using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace sorting
{
    class BubbleSortClass
    {

        public static async Task BubbleSortAsync(StackPanel stackPanel)
        {
            for (int i = 0; i < InitializationClass.currentRandomList.Count - 1; i++)
            {
                for (int j = 0; j < InitializationClass.currentRandomList.Count - 1 - i; j++)
                {
                    if (SharedClass.IsActive == false)
                    {
                        return;
                    }
                    
                    if (InitializationClass.currentRandomList[j] > InitializationClass.currentRandomList[j + 1])
                    {
                        SharedClass.SwapItems(j, j + 1, stackPanel);
                    }                    
                    await Task.Delay(SharedClass.speed);
                }
            }           
        }
    }
}
