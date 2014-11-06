using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class PositiveConditionRule : Rule
    {
        private string startToken;
        private string endTokenBase;
        public override string StartToken { get { return startToken; } }

        /// <summary>
        /// Allow to specify to render a `TEXT BLOCK` only if the condition is true.
        /// </summary>
        /// <param name="template">It should contains "{id}", "{propertyName}" and "{content}" literals</param>
        public PositiveConditionRule(string template)
            : base(template)
        {
            startToken = GetTextBefore(template, "{id}");
            //<!--{{ IF #{id} {propertyName} }}{content}<!--{{ ENDIF #{id} }}-->
            //<!--{{ IF #{id} {propertyName} }}-->
            //<!--{{ ENDIF #{id} }}-->
            endTokenBase = GetTextAfter(template, "{content}");
        }

        public override Cursor Process(Cursor cursor, out TemplateElement templateElement)
        {
            //TODO: rewrite
            var idStartCursor = cursor.MoveAfter(startToken);
            var pending = GetTextAfter(RuleTemplate, "{id}");
            var beforePropertyName = GetTextBefore(pending, "{propertyName}");
            var idEndCursor = idStartCursor.MoveBefore(beforePropertyName);
            var id = idStartCursor.GetDifference(idEndCursor);
            var propertyNameStartCursor = idEndCursor.MoveAfter(beforePropertyName);
            pending = GetTextAfter(pending, "{propertyName}");
            var beforeContent = GetTextBefore(pending, "{content}");
            var propertyNameEndCursor = propertyNameStartCursor.MoveBefore(beforeContent);
            var propertyName = propertyNameStartCursor.GetDifference(propertyNameEndCursor);
            var contentStartCursor = propertyNameEndCursor.MoveAfter(beforeContent);
            pending = GetTextAfter(pending, "{content}");
            var endToken = pending.Replace("{id}", id);
            var contentEndCursor = contentStartCursor.MoveBefore(endToken);
            var templateElementEndCursor = contentEndCursor.MoveAfter(endToken);

            templateElement = new TemplateElement()
            {
                Id = id,
                PropertyName = propertyName,
                ContentCursor = contentStartCursor.Truncate(contentEndCursor.CurrentPos)
            };

            //TODO move to after endToken
            return templateElementEndCursor;
        }
    }
}
