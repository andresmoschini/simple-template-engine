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
        private string endToken;
        public override string StartToken { get { return startToken; } }

        /// <summary>
        /// Replace the element with current property value.
        /// </summary>
        /// <param name="template">It should contains "{propertyName}" literal</param>
        public PrintRule(string template) 
            : base(template)
        {
            startToken = GetTextBefore(template, "{propertyName}");
            endToken = GetTextAfter(template, "{propertyName}");
        }

        public override Cursor Preprocess(Cursor cursor, out TemplateElement templateElement)
        {
            var propertyNameStartCursor = cursor.MoveAfter(startToken);
            var propertyNameEndCursor = cursor.MoveBefore(endToken);
            var newCursor = propertyNameEndCursor.MoveAfter(endToken);

            var propertyName = propertyNameStartCursor.GetDifference(propertyNameEndCursor);

            templateElement = new TemplateElement()
            {
                Id = null,
                PropertyName = propertyName,
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
