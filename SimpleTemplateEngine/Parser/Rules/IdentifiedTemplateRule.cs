using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public abstract class IdentifiedTemplateRule : Rule
    {
        private string startToken;
        public override string StartToken { get { return startToken; } }
        
        public IdentifiedTemplateRule(string template)
            : base(template)
        {
            startToken = GetTextBefore(template, "{id}");
        }

        public override Cursor Preprocess(Cursor cursor, out TemplateElement templateElement)
        {
            //TODO: rewrite
            var endTokenBase = GetTextAfter(RuleTemplate, "{content}");
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

            return templateElementEndCursor;
        }
    }
}
