using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public enum TemplateElement
    {
        ModelSpecification,
        Print,
        PositiveCondition,
        NegativeCondition,
        Repeating,
        End
    }
}
