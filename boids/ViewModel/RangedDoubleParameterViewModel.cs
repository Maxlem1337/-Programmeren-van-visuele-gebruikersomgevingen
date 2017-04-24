using Bindings;
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

        public RangedDoubleParameterViewModel(RangedDoubleParameter RangedDoubleParameter)
        {
            this.RangedDoubleParameter = RangedDoubleParameter;
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

        public double value
        {
            get
            {
                return 0;
            }
        }
    }
}
