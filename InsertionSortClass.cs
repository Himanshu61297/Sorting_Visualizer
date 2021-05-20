using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace sorting
{
    class InsertionSortClass
    {
        public static async Task InsertionSortAsync(StackPanel stackPanel)
        {
            for (int i = 1; i < InitializationClass.currentRandomList.Count; i++)
            {
                int key = InitializationClass.currentRandomList[i];
                int j = i - 1;

                while (j >= 0 && InitializationClass.currentRandomList[j] > key)
                {
                    
                    //For stopping the algorithm in case user wants to stop.
                    if (SharedClass.IsActive == false)
                    {
                        return;
                    }

                    InitializationClass.currentRandomList[j + 1] = InitializationClass.currentRandomList[j];
                    stackPanel.Children.Move((uint)j + 1, (uint)(j));

                    j--;

                    await Task.Delay(SharedClass.speed);
                }

                InitializationClass.currentRandomList[j + 1] = key;
            }
        }
    }
}
