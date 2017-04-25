using Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    class VM { }

    class RangedVM : VM { }

    class StringVM : VM { }

    class Dummy
    {
        public VM Create(IParameter p)
        {
            dynamic q = p;
            
            return CreateVM(q);
        }

        public VM CreateVM(RangedDoubleParameter p)
        {
            return new RangedVM();
        }

        public VM CreateVM(Parameter<string> p)
        {
            return new StringVM();
        }
    }
}
