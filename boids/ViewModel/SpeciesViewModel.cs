using Bindings;
using Cells;
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
            ResetSpeciesParameters = new ResetSpeciesParametersCommand(this);
        }

        public String Name
        {
            get
            {
                return BoidSpecies.Name;
            }
        }

        public List<IParameterViewModel> Parameters
        {
            get
            {
                //return BoidSpecies.Bindings.Parameters;
                List<IParameterViewModel> paramlist = new List<IParameterViewModel>();
                foreach (var param in BoidSpecies.Bindings.Parameters)
                {
                    dynamic dynamicparam = param;
                    paramlist.Add(CreateParameterViewModel(dynamicparam));
                }
                return paramlist;
            }
        }

        public ICommand CreateBoid
        {
            get; set;
        }

        public ICommand ResetSpeciesParameters
        {
            get; set;
        }

        public void CreateBoidOnCoords(double x, double y)
        {
            BoidSpecies.CreateBoid(new Mathematics.Vector2D(x, y));
        }

        public IParameterViewModel CreateParameterViewModel(IParameter p)
        {
            dynamic q = p;
            return CreateParameterViewModel(q);
        }

        private IParameterViewModel CreateParameterViewModel(RangedDoubleParameter p)
        {
            //dynamic test = p;
            Cell<double> test = BoidSpecies.Bindings.Read(p);
            return new RangedDoubleParameterViewModel(p, test);
        }

        private IParameterViewModel CreateParameterViewModel(Parameter<string> p)
        {

            Cell<string> test = BoidSpecies.Bindings.Read(p);
            return new StringParameterViewModel(p, test);
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
                Random rnd = new Random();
                BoidSpecies.CreateBoid(new Mathematics.Vector2D(rnd.Next(50), rnd.Next(50)));
            }
        }

        private class ResetSpeciesParametersCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private SpeciesViewModel vm;

            public ResetSpeciesParametersCommand(SpeciesViewModel vm)
            {
                this.vm = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                foreach (IParameterViewModel pvm in vm.Parameters)
                {
                    pvm.Reset.Execute(null);
                }
            }
        }
    }

    
}
