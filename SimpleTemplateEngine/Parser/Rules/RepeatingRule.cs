using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class RepeatingRule : IdentifiedTemplateRule
    {
        /// <summary>
        /// Allow to specify to repeat a `TEXT BLOCK` for each item of the list property.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public RepeatingRule(string template)
            : base(template)
        {
        }

        public override IEnumerable<Tuple<Cursor, object>> Process(TemplateElement templateElement, ModelProperty modelProperty, object parentModel)
        {
            return modelProperty.ListValue.Select(x => new Tuple<Cursor, object>(templateElement.ContentCursor, x));
        }

    }
}
