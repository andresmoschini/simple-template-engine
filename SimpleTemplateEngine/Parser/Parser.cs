using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public interface IParser
    {
        string Process(string template, object model);
    }

    public class Parser : IParser
    {
        private readonly IRuleset ruleset;

        public Parser(IRuleset ruleset)
        {
            this.ruleset = ruleset;
        }

        public string Process(string template, object model)
        {
            var cursor = new Cursor(template);
            var sb = new StringBuilder();
            
            while (true)
            {
                Rule rule;
                var newCursor = SeekTemplateElement(cursor, out rule);
                var textBeforeElement = cursor.GetDifference(newCursor);
                sb.Append(textBeforeElement);
                
                if (rule == null)
                {
                    return sb.ToString();
                }
                else
                {
                    var endToken = rule.EndToken;
                    cursor = Consume(newCursor, endToken);
                }
            }
        }

        private Cursor Consume(Cursor cursor, string endText)
        {
            var newCursor = cursor.Seek(endText);
            newCursor = newCursor.Advance(endText.Length);
            return newCursor;
        }

        private Cursor SeekTemplateElement(Cursor cursor, out Rule rule)
        {
            string found;
            var newCursor = cursor.SeekAny(ruleset.StartTokens, out found);
            if (found == null)
            {
                rule = null;
            }
            else
            {
                rule = ruleset.GetRuleByStartToken(found);
            }
            return newCursor;
        }

    }
}
