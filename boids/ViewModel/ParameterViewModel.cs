using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bindings;

namespace ViewModel
{
    public interface IParameterViewModel
    {
        string Id { get; }

        object DefaultValue { get; }
    }
}
