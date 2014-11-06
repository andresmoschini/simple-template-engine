using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTemplateEngine;

namespace SimpleTemplateEngineTests
{
    [TestClass]
    public class NullModelEndToEndTests
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

        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldContainsIFNOTcontents()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsTrue(result.Contains(
@"                    <tr>
                        <td align=""left"" valign=""top"" height=""25"" colspan=""2""></td>
                    </tr>
                    <tr>
                        <td width=""380"" align=""left"" valign=""top""><span style=""padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;"">Status</span></td>
                        <td align=""left"" valign=""top""><span style=""padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;"">Error Message</span></td>
                    </tr>
                    <tr>
                        <td align=""left"" valign=""top"" height=""5"" colspan=""2""></td>
                    </tr>
                    <tr>
                        <td width=""380"" align=""left"" valign=""top""><span style=""padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;"">[Empty]</span>
                        <td align=""left"" valign=""top""><span style=""padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;"">[Empty]</span>
                    </tr>"));
        }

                [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextNotShouldContainsIFcontents()
        {
            var engine = new TemplateEngine();
            var result = engine.Process("alert.html", null);
            Assert.IsFalse(result.Contains(@"<td align=""center"" width=""100%"" valign=""middle"" bgcolor=""#EEB700"" height=""36""><span style=""font-family: Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: 14px; font-weight: bold;"">THIS IS A TEST -- THIS IS NOT A LIVE ALERT</span></td>"));
        }

    }
}
