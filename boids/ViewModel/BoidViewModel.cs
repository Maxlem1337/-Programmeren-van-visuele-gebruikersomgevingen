using Cells;
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
    public class BoidViewModel
    {
        public Boid Boid { get; private set; }

        public BoidViewModel(Boid boid)
        {
            this.Boid = boid;
        }

        public Cell<Vector2D> Position
        {
            get
            {
                return Boid.Position;
            }
        }

        public String Color
        {
            get
            {
                return Boid.Species.Color;
            }
        }

        public BoidSpecies Species
        {
            get
            {
                return Boid.Species;
            }
        }

    }



}
