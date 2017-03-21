using Mathematics;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorldViewModel
    {

        public WorldViewModel()
        {
            this.Simulation = new Simulation();
            this.Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            this.Simulation.Species[1].CreateBoid(new Vector2D(150, 150));
        }

        public Simulation Simulation { get; set; }
        

    }
}
