using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser.Rules
{
    public class ModelSpecificationRule : Rule
    {
        private string startToken;
        private string endTokenBase;
        public override string StartToken { get { return startToken; } }
        
        /// <summary>
        /// Describes how is the expected model, it is removed on template rendering.
        /// </summary>
        /// <param name="template">It should contains "{content}" literal</param>
        public ModelSpecificationRule(string template) 
            : base(template)
        {
            startToken = GetTextBefore(template, "{content}");
            endTokenBase = GetTextAfter(template, "{content}");
        }

        public override TemplateElement Process(Cursor cursor)
        {
            var newCursor = cursor.MoveBefore(endTokenBase);
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
