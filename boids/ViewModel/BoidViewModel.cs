using Mathematics;
using Model;
using Model.Species;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class BoidViewModel
    {
        public Boid Boid { get; private set; }

        public BoidViewModel(World world, Vector2D position, BoidSpecies species)
        {
            this.Boid = new Boid(world, position, species);
        }

    }



}
