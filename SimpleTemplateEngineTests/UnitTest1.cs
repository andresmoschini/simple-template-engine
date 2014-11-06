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
        public void ResultTextShouldContainsTheLastCharacters()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            var endCharacters = result.Substring(result.Length - 18, 18);
            Assert.AreEqual("\r\n</body>\r\n</html>", endCharacters);
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsModelDefinition()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            var endCharacters = result.Substring(0, 158);
            Assert.AreEqual("<html lang=\"en\">\r\n<head>\r\n    <title>Copsync Email</title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width\">\r\n    \r\n</head>", endCharacters);
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsIFOpen()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains("<!--{{ IF "));
            Assert.IsFalse(result.Contains("{ IF"));
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsIFClose()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains("<!--{{ ENDIF "));
            Assert.IsFalse(result.Contains("{ ENDIF "));
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsIFNOTOpen()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains("<!--{{ IFNOT "));
            Assert.IsFalse(result.Contains("{ IFNOT "));
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsIFNOTClose()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains("<!--{{ ENDIFNOT "));
            Assert.IsFalse(result.Contains("{ ENDIFNOT "));
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsEACHOpen()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains("<!--{{ EACH "));
            Assert.IsFalse(result.Contains("{ EACH"));
        }

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldNotContainsEACHClose()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains("<!--{{ ENDEACH "));
            Assert.IsFalse(result.Contains("{ ENDEACH"));
        }
    }
}
