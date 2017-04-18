using Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RangedDoubleParameterViewModel : StringParameterViewModel
    {
        private readonly RangedDoubleParameter RangedDoubleParameter;

        public RangedDoubleParameterViewModel(RangedDoubleParameter RangedDoubleParameter)
        {
            this.RangedDoubleParameter = RangedDoubleParameter;
        }
    }
}
