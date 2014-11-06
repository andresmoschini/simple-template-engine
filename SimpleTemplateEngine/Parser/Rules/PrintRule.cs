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

        public override Cursor Preprocess(Cursor cursor, out TemplateElement templateElement)
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

        public override IEnumerable<Tuple<Cursor, object>> Process(TemplateElement templateElement, ModelProperty modelProperty, object parentModel)
        {
            return new[] { new Tuple<Cursor, object>(new Cursor(modelProperty.StringValue), null) };
        }
    }
}
