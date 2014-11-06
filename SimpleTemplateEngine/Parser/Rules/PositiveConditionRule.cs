using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class PositiveConditionRule : IdentifiedTemplateRule
    {
        /// <summary>
        /// Allow to specify to render a `TEXT BLOCK` only if the condition is true.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public PositiveConditionRule(string template)
            : base(template)
        {
        }

        public override IEnumerable<Tuple<Cursor, object>> Process(TemplateElement templateElement, ModelProperty modelProperty, object parentModel)
        {
            if (!modelProperty.BooleanValue)
            {
                return Enumerable.Empty<Tuple<Cursor, object>>();
            }
            else
            {
                return new[] { new Tuple<Cursor, object>(templateElement.ContentCursor, parentModel) };
            }
        }
    }
}
