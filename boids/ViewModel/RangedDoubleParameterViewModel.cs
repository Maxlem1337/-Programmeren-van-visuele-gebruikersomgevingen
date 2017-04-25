using Bindings;
using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public object Minimum
        {
            get
            {
                return RangedDoubleParameter.Minimum;
            }
        }

        public object Maximum
        {
            get
            {
                return RangedDoubleParameter.Maximum;
            }
        }

        public double Value
        {
            get
            {
                return cell.Value;
            }
            set
            {
                cell.Value = value;
                
            }
        }
    }
}
