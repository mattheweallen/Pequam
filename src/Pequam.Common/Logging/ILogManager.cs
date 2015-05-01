using System;
using log4net;

namespace Pequam.Common.Logging
{
    public interface ILogManager
    {
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }
}
