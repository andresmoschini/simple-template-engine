using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public class TemplateElement
    {
        public string Id { get; set; }
        public string PropertyName { get; set; }
        public Cursor ContentCursor { get; set; }
    }
}
