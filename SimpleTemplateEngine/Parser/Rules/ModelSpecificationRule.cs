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
        public override string StartToken { get { return startToken; } }
        public override string EndToken { get; protected set; }

        /// <summary>
        /// Describes how is the expected model, it is removed on template rendering.
        /// </summary>
        /// <param name="template">It should contains "{content}" literal</param>
        public ModelSpecificationRule(string template) 
            : base(template)
        {
            startToken = GetTextBefore(template, "{content}");
            EndToken = GetTextAfter(template, "{content}");
        }

    }
}
