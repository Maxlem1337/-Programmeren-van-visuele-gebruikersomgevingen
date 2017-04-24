using Bindings;
using Model.Species;
using System;
using System.Collections;
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

        public IEnumerable<IParameter> Parameters
        {
            get
            {
                return BoidSpecies.Bindings.Parameters;
                /*
                foreach (var param in BoidSpecies.Bindings.Parameters)
                {
                    List<ParameterViewModel> parameters = new List<ParameterViewModel>();
                    if (param is RangedDoubleParameter){
                        parameters.Insert(new RangedDoubleParameterViewModel(param));
                    } else
                    {
                        parameters.Insert(new StringParameterViewModel(param));
                    }
                }
                */
            }
        }
    }
}
