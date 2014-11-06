using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class PrintRule : Rule
    {
        public override string StartToken { get; protected set; }
        public override string EndToken { get; protected set; }

        /// <summary>
        /// Replace the element with current property value.
        /// </summary>
        /// <param name="template">It should contains "{propertyName}" literal</param>
        public PrintRule(string template) 
            : base(template)
        {
            StartToken = GetTextBefore(template, "{propertyName}");
            EndToken = GetTextAfter(template, "{propertyName}");
        }
    }
}
