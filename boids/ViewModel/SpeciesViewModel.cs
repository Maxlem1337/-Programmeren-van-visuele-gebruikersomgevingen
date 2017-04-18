using Model.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SpeciesViewModel
    {
        private readonly BoidSpecies BoidSpecies;

        public SpeciesViewModel(BoidSpecies BoidSpecies)
        {
            this.BoidSpecies = BoidSpecies;
        }

        public String Name
        {
            get
            {
                return BoidSpecies.Name;
            }
        }

        public String Color
        {
            get
            {
                return BoidSpecies.Color;
            }
        }

        public IEnumerable<StringParameterViewModel> Parameters
        {
            get
            {
                return null;
            }
        }
    }
}
