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
        private string endTokenBase;
        public override string StartToken { get { return startToken; } }

        /// <summary>
        /// Replace the element with current property value.
        /// </summary>
        /// <param name="template">It should contains "{propertyName}" literal</param>
        public PrintRule(string template) 
            : base(template)
        {
            startToken = GetTextBefore(template, "{propertyName}");
            endTokenBase = GetTextAfter(template, "{propertyName}");
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
