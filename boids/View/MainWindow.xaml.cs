using System;
using System.Windows;
using System.Windows.Threading;
using ViewModel;
using System.Windows.Media;
using System.Windows.Input;
using VGOLibrary;
using Microsoft.Practices.ServiceLocation;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// 
    /// Model extension 
    /// AllowBoidPlacement
    /// 
    /// 
    /// 
    /// (
    /// in Simulation -> this.quantizer = new TimeQuantizer(0.005, World.Update);
    /// in Mainwindow -> var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { WorldViewModel.Update(0.02); }, this.Dispatcher);
    /// )
    /// 
    /// Move AllowBoidPlacement to WorldViewModel, move the if(AllowBoidPlacement) there aswell.
    /// Remove MultiplyConverter





    public partial class MainWindow : Window
    {
        public WorldViewModel WorldViewModel { get; }

        private bool _AllowBoidPlacement;

        public bool AllowBoidPlacement
        {
            get
            {
                return _AllowBoidPlacement;
            }
            set
            {
                if (value)
                {
                    BoidBorder.Cursor = Cursors.Cross;
                }
                else
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
            //var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { WorldViewModel.Update(0.02); }, this.Dispatcher);
            //timer.Start();


            var timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0, 0, 20));
        }

        private void Timer_Tick(ITimerService obj)
        {
            WorldViewModel.Update(0.02);
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

        private void Random_Boid_Button_Click(object sender, RoutedEventArgs e)
        {
            SpeciesViewModel species = (SpeciesViewModel)availableSpecies.SelectedItem;
            species.CreateBoid(WorldViewModel.Width.Value, WorldViewModel.Height.Value);
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

        private void Fullscreen_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Default: SingleBorderWindow CanResize Normal
            HomePage.WindowStyle = WindowStyle.None;
            HomePage.ResizeMode = ResizeMode.NoResize;

            HomePage.WindowState = WindowState.Normal; //I have to switch to normal first, or it wont switch to fullscreen when window is maximized.
            HomePage.WindowState = WindowState.Maximized;

            HomePage.Width = SystemParameters.VirtualScreenWidth;
            HomePage.Height = SystemParameters.VirtualScreenHeight;
            //HomePage.Left = 0;
            //HomePage.Top = 0;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                HomePage.WindowStyle = WindowStyle.SingleBorderWindow;
                HomePage.ResizeMode = ResizeMode.CanResize;
                HomePage.WindowState = WindowState.Normal; //Changing to normal first will fix the small black border on the right.
                HomePage.WindowState = WindowState.Maximized;
            }
        }

        private void Collapsed_Expander(object sender, RoutedEventArgs e)
        {
            //new GridLength(5, GridUnitType.Star);
            col2.Width = new GridLength(5, GridUnitType.Star);
            col1.Width = new GridLength(95, GridUnitType.Star);
        }

        private void Expanded_Expander(object sender, RoutedEventArgs e)
        {
            col2.Width = new GridLength(25, GridUnitType.Star);
            col1.Width = new GridLength(75, GridUnitType.Star);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            BoidBorder.Cursor = Cursors.No;
        }
    }
}
