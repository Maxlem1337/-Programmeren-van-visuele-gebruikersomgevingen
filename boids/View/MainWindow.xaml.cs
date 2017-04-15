using Mathematics;
using Model;
using System;
using System.Windows;
using System.Windows.Threading;
using Model.Species;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // WARNING: THIS CODE VIOLATES MVVM PRINCIPLES
            // IT IS FOR ILLUSTRATIVE PURPOSES ONLY
            this.Simulation = new Simulation();
            this.Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            this.Simulation.Species[1].CreateBoid(new Vector2D(150, 150));
            this.DataContext = this;

            //this.WorldViewModel = new WorldViewModel();
            //this.DataContext = WorldViewModel.Simulation;




            // Using the timer like this will yield choppy animation
            var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { this.Simulation.Update(0.02); }, this.Dispatcher);
            timer.Start();
        }

        public Simulation Simulation { get; }

        public double test
        {
            get
            {
            return Simulation.World.Population[0].Species.Bindings.Read(BoidSpecies.MaximumSpeed).Value;
            }
            set
            {
                Simulation.World.Population[0].Species.Bindings.Read(BoidSpecies.MaximumSpeed).Value = value;
            }
       
        }

        //public WorldViewModel WorldViewModel { get; }
    }
}
