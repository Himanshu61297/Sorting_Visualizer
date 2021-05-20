using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sorting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int size = 0;
        int minSize = 20;      

        int algoIndex = 0;
        
        public MainPage()
        {
            this.InitializeComponent();
            size = (int)(((int)Window.Current.Bounds.Height) / 5);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            arraySize.Maximum = size;
            arraySize.Minimum = minSize;
            arraySize.Value = arraySize.Maximum;

            algoSpeed.Maximum = 100;
            algoSpeed.Minimum = 1;
            algoSpeed.Value = 100;

            bubble.Opacity = 0.5;

            InitializationClass.InitializeLineItems(itemsPanel);
        }

        private void bubble_Click(object sender, RoutedEventArgs e)
        {
            algoIndex = 0;            
        }

        private void selection_Click(object sender, RoutedEventArgs e)
        {
            algoIndex = 1;
        }

        private void insertion_Click(object sender, RoutedEventArgs e)
        {
            algoIndex = 2;
        }

        private void merge_Click(object sender, RoutedEventArgs e)
        {
            algoIndex = 3;
        }

        private void quick_Click(object sender, RoutedEventArgs e)
        {
            algoIndex = 4;
        }

        private async void startBtn_Click(object sender, RoutedEventArgs e)
        {
            SharedClass.IsActive = true;
            
            startBtn.Visibility = Visibility.Collapsed;
            stopBtn.Visibility = Visibility.Visible;

            switch (algoIndex)
            {
                case 0:
                    await BubbleSortClass.BubbleSortAsync(itemsPanel);
                    break;
                case 1:
                    await SelectionSortClass.SelectionSortAsync(itemsPanel);                   
                    break;
                case 2:
                    await InsertionSortClass.InsertionSortAsync(itemsPanel);
                    break;
                case 3:
                    await MergeSortClass.MergeSortAsync(InitializationClass.currentRandomList,
                        InitializationClass.currentItemList,
                        0,
                        InitializationClass.currentRandomList.Count - 1,
                        itemsPanel);
                    break;
                case 4:
                    await QuickSortClass.QuickSortAsync(itemsPanel);
                    break;
            }

            startBtn.Visibility = Visibility.Visible;
            stopBtn.Visibility = Visibility.Collapsed;

            SharedClass.IsActive = false;
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializationClass.ResetLineItems(itemsPanel);
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializationClass.InitializeLineItems(itemsPanel, size);
        }

        private void arraySize_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            size = (int)e.NewValue;
        }

        private void algoSpeed_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SharedClass.speed = 101 - (int)e.NewValue;
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            SharedClass.IsActive = false;

            startBtn.Visibility = Visibility.Visible;
            stopBtn.Visibility = Visibility.Collapsed;
        }
    }
}
