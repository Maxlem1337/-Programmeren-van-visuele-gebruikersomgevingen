using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bindings;
using System.Windows.Input;

namespace ViewModel
{
    public interface IParameterViewModel
    {
        string Id { get; }

        object DefaultValue { get; }

        ICommand Reset
        {
            get; set;
        }
    }
}
