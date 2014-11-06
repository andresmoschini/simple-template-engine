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
        private string endTokenBase;
        public override string StartToken { get { return startToken; } }

        /// <summary>
        /// Allow to specify to repeat a `TEXT BLOCK` for each item of the list property.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public RepeatingRule(string template)
            : base(template)
        {
            startToken = GetTextBefore(template, "{id}");
            endTokenBase = GetTextAfter(template, "ENDEACH #{id}");
        }

        public override Cursor Process(Cursor cursor, out TemplateElement templateElement)
        {
            var newCursor = cursor.MoveBefore(endTokenBase);
            newCursor = newCursor.Advance(endTokenBase.Length);

            templateElement = new TemplateElement()
            {
                Id = null,
                PropertyName = null,
                ContentCursor = newCursor.Truncate()
            };

            return newCursor;
        }
    }
}
