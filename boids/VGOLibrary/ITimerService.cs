using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGOLibrary
{
    public interface ITimerService
    {
        event Action<ITimerService> Tick;
        void Start(TimeSpan interval);
        void Stop();
    }
}
