using Bindings;
using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public string Id => p.Id;

        public object DefaultValue => p.DefaultValue;

        public string Value
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
