using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public interface IParser
    {
        string Process(object model);
    }

    public class Parser : IParser
    {
        private readonly IRuleset ruleset;

        private readonly Dictionary<string, TemplateElement> startTokens;
        private readonly string template;

        public Parser(IRuleset ruleset, string template)
        {
            this.template = template;
            this.ruleset = ruleset;

            startTokens = new Dictionary<string, TemplateElement>()
            {
                { GetTextBefore(ruleset.ModelSpecificationPattern, "{content}"), TemplateElement.ModelSpecification },
                { GetTextBefore(ruleset.PrintPattern, "{propertyName}"), TemplateElement.Print },
                { GetTextBefore(ruleset.PositiveConditionPattern, "{id}"), TemplateElement.PositiveCondition },
                { GetTextBefore(ruleset.NegativeConditionPattern, "{id}"), TemplateElement.NegativeCondition },
                { GetTextBefore(ruleset.RepeatingPattern, "{id}"), TemplateElement.Repeating }
            };

        }

        public string Process(object model)
        {
            var cursor = new Cursor(template);
            var sb = new StringBuilder();
            
            while (true)
            {
                TemplateElement elementType;
                var newCursor = SeekTemplateElement(cursor, out elementType);
                var textBeforeElement = cursor.GetDifference(newCursor);
                sb.Append(textBeforeElement);

                string endToken;
                switch (elementType)
                {
                    case TemplateElement.ModelSpecification:
                        endToken = GetTextAfter(ruleset.ModelSpecificationPattern, "{content}");
                        cursor = Consume(newCursor, endToken);
                        break;
                    case TemplateElement.Print:
                        endToken = GetTextAfter(ruleset.PrintPattern, "{propertyName}");
                        cursor = Consume(newCursor, endToken);
                        break;
                    case TemplateElement.PositiveCondition:
                        endToken = GetTextAfter(ruleset.PositiveConditionPattern, "ENDIF #{id}");
                        //TODO: 
                        //endToken = GetTextAfter(Ruleset.PositiveConditionPattern, "{content}");
                        //replace id in endToken
                        //recursive
                        cursor = Consume(newCursor, endToken);
                        break;
                    case TemplateElement.NegativeCondition:
                        endToken = GetTextAfter(ruleset.NegativeConditionPattern, "ENDIFNOT #{id}");
                        //TODO: 
                        //endToken = GetTextAfter(Ruleset.NegativeConditionPattern, "{content}");
                        //replace id in endToken
                        //recursive
                        cursor = Consume(newCursor, endToken);
                        break;
                    case TemplateElement.Repeating:
                        endToken = GetTextAfter(ruleset.RepeatingPattern, "ENDEACH #{id}");
                        //TODO: 
                        //endToken = GetTextAfter(Ruleset.RepeatingPattern, "{content}");
                        //replace id in endToken
                        //recursive
                        cursor = Consume(newCursor, endToken);
                        break;
                    case TemplateElement.End: 
                        return sb.ToString();
                }
            }
        }

        private Cursor Consume(Cursor cursor, string endText)
        {
            var newCursor = cursor.Seek(endText);
            newCursor = newCursor.Advance(endText.Length);
            return newCursor;
        }

        private Cursor SeekTemplateElement(Cursor cursor, out TemplateElement templateElement)
        {
            string found;
            var newCursor = cursor.SeekAny(startTokens.Keys, out found);
            if (found == null)
            {
                templateElement = TemplateElement.End;
            }
            else
            {
                templateElement = startTokens[found];
            }
            return newCursor;
        }

        private string GetTextBefore(string text, string token)
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

        private string GetTextAfter(string text, string token)
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
