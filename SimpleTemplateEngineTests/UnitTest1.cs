using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTemplateEngine;

namespace SimpleTemplateEngineTests
{
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void TestMethod1()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
        }
    }
}
