using Bindings;
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
        private readonly Boid Boid;

        public BoidViewModel(Boid boid)
        {
            this.Boid = boid;
        }

        public Cell<Vector2D> Position => Boid.Position;

        public SpeciesViewModel Species
        {
            get
            {
                return new SpeciesViewModel(Boid.Species);
            }
        }

        public ParameterBindings Bindings => Boid.Bindings;

    }
}
