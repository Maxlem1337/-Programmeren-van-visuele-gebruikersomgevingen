using Bindings;
using Cells;
using Mathematics;
using Model;
using Model.Species;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorldViewModel
    {
        private readonly World World;

        public WorldViewModel(World world)
        {
            this.World = world;
        }

        /*
        public ObservableCollection<BoidViewModel> Population
        {
            get
            {
                ObservableCollection<BoidViewModel> pop = new ObservableCollection<BoidViewModel>();

                foreach (Boid boid in Simulation.World.Population)
                {
                    pop.Add(new BoidViewModel(boid));
                }

                return pop;
            }
        }
        */
        /*
        public ObservableCollection<BoidViewModel> Population
        {
            get
            {
                return Simulation.World.Population;
            }
        }
        */

        public IEnumerable<BoidViewModel> Population
        {
            get
            {
                return World.Population.Select(b => new BoidViewModel(b));
            }
        }





    }
}
