using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public abstract class Rule
    {
        public string Template { get; private set; }
        public abstract string StartToken { get; protected set; }
        public abstract string EndToken { get; protected set; }

        public Rule(string template)
        {
            Template = template;
        }

        protected static string GetTextBefore(string text, string token)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            var pos = text.IndexOf(token);
            if (pos < 0)
            {
                throw new ArgumentException("Text does not contain specified token");
            }

            if (pos == 0)
            {
                throw new ArgumentException("Text starts with token");
            }

            return text.Substring(0, pos);
        }

        protected static string GetTextAfter(string text, string token)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            var pos = text.IndexOf(token);
            if (pos < 0)
            {
                throw new ArgumentException("Text does not contain specified token");
            }

            if (pos == 0)
            {
                throw new ArgumentException("Text starts with token");
            }

            return text.Substring(pos + token.Length, text.Length - pos - token.Length);
        }

    }
}
