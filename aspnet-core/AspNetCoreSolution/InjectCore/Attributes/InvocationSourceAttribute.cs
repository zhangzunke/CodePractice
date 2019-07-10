using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjectCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InvocationSourceAttribute : Attribute
    {
        public string Source { get; }
        public InvocationSourceAttribute(string source) => Source = source;
    }
}
