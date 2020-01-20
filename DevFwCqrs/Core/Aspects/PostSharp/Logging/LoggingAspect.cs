using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.PostSharp.Logging
{
    public class LoggingAspect:OnMethodBoundaryAspect
    {
        Type _loggerType;

    }
}
