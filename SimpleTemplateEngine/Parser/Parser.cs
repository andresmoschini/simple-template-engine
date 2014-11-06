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

        private readonly char[] startChars;
        private readonly Dictionary<TemplateElement, string> startTokens;
        private readonly string template;
        private readonly int templateLenght;

        private int currentPos = 0;

        public Parser(IRuleset ruleset, string template)
        {
            this.ruleset = ruleset;
            this.template = template;
            templateLenght = template.Length;

            startTokens = new Dictionary<TemplateElement, string>()
            {
                { TemplateElement.ModelSpecification, GetTextBefore(ruleset.ModelSpecificationPattern, "{content}") },
                { TemplateElement.Print, GetTextBefore(ruleset.PrintPattern, "{propertyName}") },
                { TemplateElement.PositiveCondition, GetTextBefore(ruleset.PositiveConditionPattern, "{id}") },
                { TemplateElement.NegativeCondition, GetTextBefore(ruleset.NegativeConditionPattern, "{id}") },
                { TemplateElement.Repeating, GetTextBefore(ruleset.RepeatingPattern, "{id}") }
            };
            
            startChars = startTokens.Values.Select(x => x[0]).Distinct().ToArray();
        }

        public string Process(object model)
        {
            var sb = new StringBuilder();
            
            while (true)
            {
                var previousPos = currentPos;
                var templateElement = GetNextTemplateElement();
                var substr = template.Substring(previousPos, currentPos - previousPos);
                sb.Append(substr);

                string endToken;
                switch (templateElement)
                {
                    case TemplateElement.ModelSpecification:
                        endToken = GetTextAfter(ruleset.ModelSpecificationPattern, "{content}");
                        Consume(endToken);
                        break;
                    case TemplateElement.Print:
                        endToken = GetTextAfter(ruleset.PrintPattern, "{propertyName}");
                        Consume(endToken);
                        break;
                    case TemplateElement.PositiveCondition:
                        endToken = GetTextAfter(ruleset.PositiveConditionPattern, "ENDIF #{id}");
                        //TODO: 
                        //endToken = GetTextAfter(Ruleset.PositiveConditionPattern, "{content}");
                        //replace id in endToken
                        //recursive
                        Consume(endToken);
                        break;
                    case TemplateElement.NegativeCondition:
                        endToken = GetTextAfter(ruleset.NegativeConditionPattern, "ENDIFNOT #{id}");
                        //TODO: 
                        //endToken = GetTextAfter(Ruleset.NegativeConditionPattern, "{content}");
                        //replace id in endToken
                        //recursive
                        Consume(endToken);
                        break;
                    case TemplateElement.Repeating:
                        endToken = GetTextAfter(ruleset.RepeatingPattern, "ENDEACH #{id}");
                        //TODO: 
                        //endToken = GetTextAfter(Ruleset.RepeatingPattern, "{content}");
                        //replace id in endToken
                        //recursive
                        Consume(endToken);
                        break;
                    case TemplateElement.End: 
                        return sb.ToString();
                }
            }
        }

        private string Consume(string endText)
        {
            var pos = template.IndexOf(endText, currentPos);
            var result = template.Substring(currentPos, pos - currentPos);
            currentPos = pos + endText.Length;
            return result;
        }

        private TemplateElement GetNextTemplateElement()
        {
            while (true)
            {
                var tentativePos = template.IndexOfAny(startChars, currentPos);
                if (tentativePos < 0 || tentativePos == templateLenght)
                {
                    return TemplateElement.End;
                }

                foreach (var pair in startTokens)
                {
                    var startTokenLenght = pair.Value.Length;
                    if (tentativePos + startTokenLenght < templateLenght && template[tentativePos] == pair.Value[0])
                    {
                        var tentativeText = template.Substring(tentativePos, startTokenLenght);
                        if (tentativeText == pair.Value)
                        {
                            currentPos = tentativePos;
                            return pair.Key;
                        }
                    }
                }

                currentPos = tentativePos + 1;
            }
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
