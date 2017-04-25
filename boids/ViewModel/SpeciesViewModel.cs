using Bindings;
using Model.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SpeciesViewModel
    {
        private readonly BoidSpecies BoidSpecies;

        public SpeciesViewModel(BoidSpecies BoidSpecies)
        {
            this.BoidSpecies = BoidSpecies;
            CreateBoid = new CreateBoidCommand(BoidSpecies);
        }

        public String Name
        {
            get
            {
                return BoidSpecies.Name;
            }
        }

        public IEnumerable<IParameter> Parameters
        {
            get
            {
                return BoidSpecies.Bindings.Parameters;
            }
        }

        public ICommand CreateBoid
        {
            get; set;
        }



        private class CreateBoidCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public BoidSpecies BoidSpecies;

            public CreateBoidCommand(BoidSpecies BoidSpecies)
            {
                this.BoidSpecies = BoidSpecies;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                BoidSpecies.CreateBoid(new Mathematics.Vector2D(50, 50));
            }
        }
    }

    
}
