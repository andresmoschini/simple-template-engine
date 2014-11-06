using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class RepeatingRule : Rule
    {
        private string startToken;
        public override string StartToken { get { return startToken; } }
        public override string EndToken { get; protected set; }

        /// <summary>
        /// Allow to specify to repeat a `TEXT BLOCK` for each item of the list property.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public RepeatingRule(string template)
            : base(template)
        {
            startToken = GetTextBefore(template, "{id}");
            EndToken = GetTextAfter(template, "ENDEACH #{id}");
        }
    }
}
