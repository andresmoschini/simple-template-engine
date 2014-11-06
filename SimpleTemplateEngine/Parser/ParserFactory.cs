using SimpleTemplateEngine.Parser.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public interface IParserFactory
    {
        IParser CreateParser();
    }

    public class ParserFactory : IParserFactory
    {
        private readonly IRuleset ruleset;
        
        public IParser CreateParser()
        {
            var ruleset = new Ruleset(new Rule[] {
                new ModelSpecificationRule("<!--{{ MODEL{content}}}-->"),
                new PrintRule("{{= {propertyName} }}"),
                new PositiveConditionRule("<!--{{ IF #{id} {propertyName} }}{content}<!--{{ ENDIF #{id} }}-->"),
                new NegativeConditionRule("<!--{{ IFNOT #{id} {propertyName} }}{content}<!--{{ ENDIFNOT #{id} }}-->"),
                new RepeatingRule("<!--{{ EACH #{id} {propertyName} }}{content}<!--{{ ENDEACH #{id} }}-->")
            });
            return new Parser(ruleset);
        }

    }
}
