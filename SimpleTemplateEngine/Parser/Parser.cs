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
                    //TODO: find a more elegant way to do it
                    TemplateElement templateElement;
                    cursor = rule.Preprocess(newCursor, out templateElement);
                    var propertyValue = templateElement.PropertyName == null ? ModelProperty.Empty : ModelProperty.FromObject(model, templateElement.PropertyName);
                    var list = rule.Process(templateElement, propertyValue, model);
                    foreach (var tuple in list)
                    {
                        Process(stringBuilder, tuple.Item1, tuple.Item2);
                    }
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
