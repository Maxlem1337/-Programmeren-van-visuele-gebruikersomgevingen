using Mathematics;
using Model;
using System;
using System.Windows;
using System.Windows.Threading;
using Model.Species;
using ViewModel;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// Todo:
    /// 
    /// 
    /// 
    /// 
    /// Expander
    /// Timer 
    /// ValueConverterViewModel
    /// 
    /// 
    /// 
    /// (
    /// in Simulation -> this.quantizer = new TimeQuantizer(0.005, World.Update);
    /// in Mainwindow -> var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { WorldViewModel.Update(0.02); }, this.Dispatcher);
    /// )
    /// 
    /// 





    public partial class MainWindow : Window
    {
        public WorldViewModel WorldViewModel { get; }

        private bool _AllowBoidPlacement;

        public bool AllowBoidPlacement {
            get
            {
                return _AllowBoidPlacement;
            }
            set
            {
                if (value)
                {
                    BoidBorder.Cursor = Cursors.Cross;
                } else
                {
                    BoidBorder.Cursor = Cursors.No;
                }
                _AllowBoidPlacement = value;
            }
        }
       

        public MainWindow()
        {
            InitializeComponent();
            
            this.WorldViewModel = new WorldViewModel();
            this.DataContext = this;


            // Using the timer like this will yield choppy animation
            var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { WorldViewModel.Update(0.02); }, this.Dispatcher);
            timer.Start();
        }

        private void Test_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AllowBoidPlacement)
            {
                Point p = e.GetPosition(BoidViewBox);
                SpeciesViewModel species = (SpeciesViewModel)availableSpecies.SelectedItem;
                ContainerVisual child = VisualTreeHelper.GetChild(BoidViewBox, 0) as ContainerVisual;
                ScaleTransform scale = child.Transform as ScaleTransform;
                species.CreateBoidOnCoords(p.X / scale.ScaleX, p.Y / scale.ScaleY);
            }
            else
            {

            }
        }

        private void btnNextSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (availableSpecies.SelectedIndex < availableSpecies.Items.Count - 1)
                availableSpecies.SelectedIndex = availableSpecies.SelectedIndex + 1;
        }

        private void btnPreviousSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (availableSpecies.SelectedIndex > 0)
                availableSpecies.SelectedIndex = availableSpecies.SelectedIndex - 1;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            BoidBorder.Cursor = Cursors.No;
        }

   
    }
}
