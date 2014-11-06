using SimpleTemplateEngine.Parser;
using SimpleTemplateEngine.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine
{
    public class TemplateEngine
    {
        public IFileReader FileReader { get; private set; }
        public IParserFactory ParserFactory { get; private set; }

        public TemplateEngine(IFileReader fileReader = null, IParserFactory parserFactory = null)
        {
            FileReader = fileReader ?? new FileReader();
            ParserFactory = parserFactory ?? new ParserFactory();
        }

        public string Process(string path, object model)
        {
            //TODO: improve it reading the file in place of use a string in memory
            var template = FileReader.Read(path);
            var parser = ParserFactory.CreateParser(template);
            return parser.Process(model);
        }
    }
}
