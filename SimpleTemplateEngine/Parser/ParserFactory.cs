using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public interface IParserFactory
    {
        IParser CreateParser(string template);
    }

    public class ParserFactory : IParserFactory
    {
        private readonly IRuleset ruleset;
        
        public ParserFactory(IRuleset ruleset)
        {
            this.ruleset = ruleset;
        }

        public IParser CreateParser(string template)
        {
            return new Parser(ruleset, template);
        }

    }
}
