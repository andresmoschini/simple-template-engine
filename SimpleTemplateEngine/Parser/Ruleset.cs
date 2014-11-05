using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public interface IRuleset
    {
        string ModelSpecificationPattern { get; }
        string PrintPattern { get; }
        string PositiveConditionPattern { get; }
        string NegativeConditionPattern { get; }
        string RepeatingPattern { get; }
    }
    public class Ruleset : IRuleset
    {
        public string ModelSpecificationPattern
        {
            get { return "<!--{{ MODEL {content}}}-->"; }
        }

        public string PrintPattern
        {
            get { return "{{= {propertyName} }}"; }
        }

        public string PositiveConditionPattern
        {
            get { return "<!--{{ IF #{id} {propertyName} }}{content}<!--{{ ENDIF #{id} }}-->"; }
        }

        public string NegativeConditionPattern
        {
            get { return "<!--{{ IFNOT #{id} {propertyName} }}{content}<!--{{ ENDIFNOT #{id} }}-->"; }
        }

        public string RepeatingPattern
        {
            get { return "<!--{{ EACH #{id} {propertyName} }}{content}<!--{{ ENDEACH #{id} }}-->"; }
        }
    }
}
