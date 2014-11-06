using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public interface IRuleset
    {
        IReadOnlyCollection<Rule> Rules { get; }
        IReadOnlyCollection<String> StartTokens { get; }
        Rule GetRuleByStartToken(string startToken);
    }
    public class Ruleset : IRuleset
    {
        private readonly Dictionary<string, Rule> indexedRulesByStartToken = null;
        public IReadOnlyCollection<Rule> Rules { get; private set; }
        public IReadOnlyCollection<String> StartTokens
        {
            get { return indexedRulesByStartToken.Keys.ToArray(); }
        }

        public Rule GetRuleByStartToken(string startToken)
        {
            return indexedRulesByStartToken[startToken];
        }

        public Ruleset(IEnumerable<Rule> rules)
        {
            Rules = rules.ToArray();
            indexedRulesByStartToken = Rules.ToDictionary(x => x.StartToken);
        }
    }
}
