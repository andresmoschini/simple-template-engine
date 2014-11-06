using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class NegativeConditionRule : Rule
    {
        public override string StartToken { get; protected set; }
        public override string EndToken { get; protected set; }

        /// <summary>
        /// Allow to specify to render a `TEXT BLOCK` only if the condition is false.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public NegativeConditionRule(string template)
            : base(template)
        {
            StartToken = GetTextBefore(template, "{id}");
            EndToken = GetTextAfter(template, "ENDIFNOT #{id}");
        }
    }
}
