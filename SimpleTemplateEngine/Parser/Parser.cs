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
            var stringBuilder = new StringBuilder();
            Process(stringBuilder, cursor, model);
            return stringBuilder.ToString();
        }

        protected void Process(StringBuilder stringBuilder, Cursor cursor, object model)
        {
            while (true)
            {
                Rule rule;
                var newCursor = SeekTemplateElement(cursor, out rule);
                var textBeforeElement = cursor.GetDifference(newCursor);
                stringBuilder.Append(textBeforeElement);
                
                if (rule == null)
                {
                    return;
                }
                else
                {
                    var templateElement = rule.Process(newCursor);
                    if (!templateElement.ContentCursor.AtEnd)
                    {
                        Process(stringBuilder, templateElement.ContentCursor, model);
                    }
                    cursor = newCursor.AdvanceTo(templateElement.ContentCursor.Length);
                }
            }
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
