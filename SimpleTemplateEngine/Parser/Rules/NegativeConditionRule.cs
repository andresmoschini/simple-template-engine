using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class NegativeConditionRule : Rule
    {
        private string startToken;
        private string endTokenBase;
        public override string StartToken { get { return startToken; } }

        /// <summary>
        /// Allow to specify to render a `TEXT BLOCK` only if the condition is false.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public NegativeConditionRule(string template)
            : base(template)
        {
            startToken = GetTextBefore(template, "{id}");
            endTokenBase = GetTextAfter(template, "ENDIFNOT #{id}");
        }

        public override TemplateElement Process(Cursor cursor)
        {
            var newCursor = cursor.Seek(endTokenBase);
            newCursor = newCursor.Advance(endTokenBase.Length);

            return new TemplateElement()
            {
                Id = null,
                PropertyName = null,
                ContentCursor = newCursor.Truncate()
            };

        }
    }
}
