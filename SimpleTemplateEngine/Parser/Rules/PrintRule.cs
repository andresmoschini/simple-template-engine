using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class PrintRule : Rule
    {
        private string startToken;
        public override string StartToken { get { return startToken; } }
        public override string EndToken { get; protected set; }

        /// <summary>
        /// Replace the element with current property value.
        /// </summary>
        /// <param name="template">It should contains "{propertyName}" literal</param>
        public PrintRule(string template) 
            : base(template)
        {
            startToken = GetTextBefore(template, "{propertyName}");
            EndToken = GetTextAfter(template, "{propertyName}");
        }
    }
}
