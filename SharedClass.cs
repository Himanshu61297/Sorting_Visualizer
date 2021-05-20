using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace sorting
{
    class SharedClass
    {
        public static int speed = 1;
        public static bool IsActive = true;
        
        public static void SwapItems(int p1, int p2, StackPanel stackPanel)
        {
            int temp = InitializationClass.currentRandomList[p1];
            InitializationClass.currentRandomList[p1] = InitializationClass.currentRandomList[p2];
            InitializationClass.currentRandomList[p2] = temp;

            ((ProgressBar)stackPanel.Children[p1]).Value = InitializationClass.currentRandomList[p1];
            ((ProgressBar)stackPanel.Children[p2]).Value = InitializationClass.currentRandomList[p2];           
            
        }       
    }
}
