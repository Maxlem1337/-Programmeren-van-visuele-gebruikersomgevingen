using Bindings;
using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class StringParameterViewModel : IParameterViewModel
    {
        private readonly Parameter<string> p;
        private Cell<string> cell;

        public StringParameterViewModel(Parameter<string> p, Cell<string> cell)
        {
            this.p = p;
            this.cell = cell;
            Reset = new ResetCommand(this);
        }

        public string Id => p.Id;

        public object DefaultValue => p.DefaultValue;

        public Cell<string> Value
        {
            get
            {
                return cell;
            }
            set
            {
                cell = value;

            }
        }

        public ICommand Reset
        {
            get; set;
        }

        private class ResetCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private StringParameterViewModel vm;


            public ResetCommand(StringParameterViewModel vm)
            {
                this.vm = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                vm.Value.Value = (string)vm.DefaultValue;
            }
        }
    }
}
