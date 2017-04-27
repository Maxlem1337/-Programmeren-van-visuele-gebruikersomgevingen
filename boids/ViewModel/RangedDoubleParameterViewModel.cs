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
    public class RangedDoubleParameterViewModel : IParameterViewModel
    {
        private readonly RangedDoubleParameter RangedDoubleParameter;
        private Cell<double> cell;

        public RangedDoubleParameterViewModel(RangedDoubleParameter RangedDoubleParameter, Cell<double> cell)
        {
            this.RangedDoubleParameter = RangedDoubleParameter;
            this.cell = cell;
            Reset = new ResetCommand(this);
        }

        public object DefaultValue
        {
            get
            {
                return RangedDoubleParameter.DefaultValue;
            }
        }

        public string Id
        {
            get
            {
                return RangedDoubleParameter.Id;
            }
        }

        public double Minimum
        {
            get
            {
                return RangedDoubleParameter.Minimum;
            }
        }

        public double Maximum
        {
            get
            {
                return RangedDoubleParameter.Maximum;
            }
        }

        public Cell<double> Value
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
            private RangedDoubleParameterViewModel vm;


            public ResetCommand(RangedDoubleParameterViewModel vm)
            {
                this.vm = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                vm.Value.Value = (double)vm.DefaultValue;
            }
        }
    }
}
