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
    /// 
    /// 
    /// Timer
    /// ValueConverterViewModel?
    /// Viewbox voor canvas?
    /// 



    public partial class MainWindow : Window
    {
        private float Zoom = 1;
        public MainWindow()
        {
            InitializeComponent();

            // WARNING: THIS CODE VIOLATES MVVM PRINCIPLES
            // IT IS FOR ILLUSTRATIVE PURPOSES ONLY
            //this.Simulation = new Simulation();
            //this.Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            //this.Simulation.Species[1].CreateBoid(new Vector2D(150, 150));
            //this.DataContext = this;

            this.WorldViewModel = new WorldViewModel();
            this.DataContext = WorldViewModel;




            // Using the timer like this will yield choppy animation
            var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { WorldViewModel.Update(0.02); }, this.Dispatcher);
            timer.Start();
        }

        //public Simulation Simulation { get; }

        public WorldViewModel WorldViewModel { get; }



        private void Test_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Left mouse button");
        }

        private void content_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Testing");
            Canvas canvas = (Canvas)this.FindName("CanvasName");
            if(canvas != null)
            {
                canvas.Width *= 2;  // BLAH
                canvas.Height *= 2;  // BLAH
                Zoom *= 2;
                TransformGroup gridTransforms = new TransformGroup();
                gridTransforms.Children.Add(new ScaleTransform(Zoom, Zoom));
                gridTransforms.Children.Add(new TranslateTransform(0, 0));
                canvas.LayoutTransform = gridTransforms;
            }


        }

        private void content_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //canvas.Width /= 2;  // BLAH
            //canvas.Height /= 2;  // BLAH
            //Zoom /= 2;
            //TransformGroup gridTransforms = new TransformGroup();
            //gridTransforms.Children.Add(new ScaleTransform(Zoom, Zoom));
            //gridTransforms.Children.Add(new TranslateTransform(0, 0));
            //canvas.RenderTransform = gridTransforms;
        }

    }
}
