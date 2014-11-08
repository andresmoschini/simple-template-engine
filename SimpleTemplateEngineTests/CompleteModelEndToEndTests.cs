using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTemplateEngine;
using System.Globalization;
using System.Diagnostics;

namespace SimpleTemplateEngineTests
{
    [TestClass]
    public class CompleteModelEndToEndTests
    {
        [TestMethod]
        [DeploymentItem(@"TemplateExamples\alert.html")]
        public void ResultTextShouldContainsTheLastCharacters()
        {
            var model = new
            {
                emailTitle = "!emailTitle!",
                testMode = true,
                alertDay = "!Today!",
                agencyName = "!agencyName!",
                orgLocation = "!orgLocation!",
                orgAddress = "!orgAddress!",
                userName = "!userName!",
                userFullname = "!userFullname!",
                orgLatitude = "!orgLatitude!",
                orgLongitude = "!orgLongitude!",
                appVersion = "!appVersion!",
                alertText = "!alertText!",
                ipAddress = "!ipAddress!",
                macAddress = "!macAddress!",
                status = true,
                statusText = "!statusText!",
                errorMessage = "!errorMessage!",
                success = false,
                hasHistoryStatus = true,
                hasOfficers = false,
                hasDispatchers = true,
                dispatchers = new[] 
                {
                    new {
                        colorRow = "#EBF3FA",
                        actorName = "Actor1",
                        agencyName = "Agency1",
                        colorOnline = "#CAF0CC",
                        alertSent = "YES"
                    },
                    new {
                        colorRow = "#FFFFFF",
                        actorName = "Actor2",
                        agencyName = "Agency2",
                        colorOnline = "#F9C7CE",
                        alertSent = "NO"
                    }
                },
                hasRecipients = false,
                recipients = new[] 
                {
                    new {
                        colorRow = "#EBF3FA",
                        actorName = "ActorName",
                        currentLocation = "currentLocation",
                        alertSent = "YES"
                    },
                    new {
                        colorRow = "#FFFFFF",
                        actorName = "ActorName",
                        currentLocation = "currentLocation",
                        alertSent = "YES"
                    }
                },
                hasBusRecipients = false
            };
            var engine = new TemplateEngine();
            var result = engine.ProcessFile("alert.html", model);
            Assert.AreEqual(
                "<html lang=\"en\">\r\n<head>\r\n    <title>Copsync Email</title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width\">\r\n    \r\n</head>\r\n<body style=\"margin: 0; padding: 0;\">\r\n    <style type=\"text/css\">\r\n        /* Force Outlook to provide a \"view in browser\" message */\r\n        #outlook a {\r\n            padding: 0;\r\n        }\r\n        /* Force Hotmail to display emails at full width */\r\n        .ReadMsgBody {\r\n            width: 100%;\r\n        }\r\n\r\n        .ExternalClass {\r\n            width: 100%;\r\n        }\r\n            /* Force Hotmail to display normal line spacing */\r\n            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {\r\n                line-height: 100%;\r\n            }\r\n        /* Prevent WebKit and Windows mobile changing default text sizes */\r\n        body, table, td, a {\r\n            -webkit-text-size-adjust: 100%;\r\n            -ms-text-size-adjust: 100%;\r\n        }\r\n        /* Remove spacing between tables in Outlook 2007 and up */\r\n        table, td {\r\n            mso-table-lspace: 0pt;\r\n            mso-table-rspace: 0pt;\r\n        }\r\n        /* Allow smoother rendering of resized image in Internet Explorer */\r\n        img {\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n        /* RESET STYLES */\r\n        body {\r\n            margin: 0;\r\n            padding: 0;\r\n            height: 100% !important;\r\n            width: 100% !important;\r\n        }\r\n\r\n        img {\r\n            border: 0;\r\n            height: auto;\r\n            line-height: 100%;\r\n            outline: none;\r\n            text-decoration: none;\r\n            display: block;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse !important;\r\n        }\r\n        /* iOS BLUE LINKS */\r\n        .appleBody a {\r\n            color: #68440a;\r\n            text-decoration: none;\r\n        }\r\n\r\n        .appleFooter a {\r\n            color: #999999;\r\n            text-decoration: none;\r\n        }\r\n    </style>\r\n    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"900\" align=\"center\">\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"line-height: 0px; padding-top: 30px; padding-bottom: 25px;\"><img src=\"https://dataonixnonprod.blob.core.windows.net/images/v2/logoCOPsync911.png\" style=\"display: block;\" border=\"0\" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 25px; border-top: 1px solid #E0E0E0\"><span style=\"color: #444444; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 30px;\">!emailTitle!</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"20\"></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EEB700\" height=\"36\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: 14px; font-weight: bold;\">THIS IS A TEST -- THIS IS NOT A LIVE ALERT</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"padding-top: 30px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ALERT DETAILS</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Date</span></td>\r\n                        <td width=\"300\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!Today!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!agencyName!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Address</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgLocation!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgAddress!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Name</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Full Name</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!userName!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!userFullname!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Latitude</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Longitude</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgLatitude!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgLongitude!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Application Version</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!appVersion!</span>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Text</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!alertText!</span>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request IP Address</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request MAC Address</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!ipAddress!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!macAddress!</span></td>\r\n                    </tr>\r\n                    \r\n                    \r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Status</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Error Message</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!statusText!</span>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!errorMessage!</span>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n    \r\n        <tr>\r\n            <td style=\"padding-top: 40px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">OFFICERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Officers were associated with this alert.</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DISPATCHERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF; border-right: 1px solid #FFFFFF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Agency Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Actor1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Agency1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#CAF0CC\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Actor2</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Agency2</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#F9C7CE\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">NO</span></td>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DEVICES THAT RECEIVED THIS ALERT IN COPSYNC911</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Recipients were associated with this alert.</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ORGANIZATIONS THAT RECEIVED THIS ALERT VIA QUEUE MESSAGES</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Service Bus recipients were associated with this alert.</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n        </tr>\r\n        \r\n        \r\n    \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px; border-bottom: 1px solid #E0E0E0; padding-bottom: 15px;\"><span style=\"color: #666666; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">The Dataonix Team</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 20px; padding-bottom: 20px;\"><span style=\"color: #444444; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">Copyright © @DateTime.Now.Year COPsync, Inc., a Dataonix company. All rights reserved.</span></td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>",
                result);
        }


        #region Performance test helper methods
        private object GenerateModel(int count)
        {
            var baseUrl = "http://alerts.com";
            const string UNKNOWN = "(unknown)";
            var subject = "TEST " + count;
            var alert = new {
                CreatedOnClient = DateTimeOffset.Now,
                RequestId = count,
                RequestIPAddress = "50.199.226.109",
                RequestMACAddress = "D0-DF-9A-F8-7C-A7",
                Address = "222 Rosewood Drive",
                AddressTwo = "AddressTwo",
                CityName = "Danvers",
                StateName = "Massachusetts",
                StateCode = "MZ",
                CountryName = "US",
                CountryCode = "US",
                PostalCode = "01923",
                Latitude = 42.569581725128536M,
                Longitude = -70.90723894122314M,
                TestMode = true,
                PartyLocationId = Guid.NewGuid(),
                PartyLocationName = "PartyLocationName",
                CurrentLocationId = Guid.NewGuid(),
                CurrentLocationName = "CurrentLocationName",
                FloorPlanLink = "FloorPlanLink",
                OrganizationId = Guid.NewGuid(),
                OrganizationName = "OrganizationName",
                AlertType = "AlertType",
                ChatroomName = "ChatroomName",
                SendAlertsToAllOrganization = true,
                AllowLocationDispatchOverride = true,
                MaxNearestOfficers = 20,
                IsGeolocated = true,
                UserId = Guid.NewGuid(),
                UserName = "MSIELICKIW7",
                UserFullName = (string)null,
                DeviceId = Guid.NewGuid(),
                DeviceName = "MSIELICKIW7",
                OriginId = Guid.NewGuid(),
                OriginDescription = "COPsync911",
                OriginVersion = "1.12.5381.31543",
                InitialMessage = "TEST - Assistance requested from DANVERS SCHOOL DISTRICT 1, Ranger High School, 222 Rosewood Drive, Danvers, Massachusetts, 01923, Location: Classroom 16",
                SmsMessage = "SmsMessage",
                ChatConversationId = 20,
                ChatroomLink = "http://mobile.com",
                Success = true,
                ErrorDetails = (string)null,
                FormattedAddress = "222 Rosewood Drive, Danvers, Massachusetts, 01923",
            };
            var lawUsers = new [] {
                new {
                    FirstName = "Andrés",
                    LastName = "Moschini",
                    AgencyName = "BRANDON COPSYNC DEMO 1",
                    Distance = 3M,
                    IsOnLine = true,
                    Type = "officer"
                },
                new {
                    FirstName = "Matías",
                    LastName = "Beckerle",
                    AgencyName = "BRANDON COPSYNC DEMO 1",
                    Distance = 0M,
                    IsOnLine = false,
                    Type = "officer"
                },
                new {
                    FirstName = "Gastón",
                    LastName = "Kolocsar",
                    AgencyName = "BRANDON COPSYNC DEMO 1",
                    Distance = 3.36M,
                    IsOnLine = true,
                    Type = "dispatcher"
                },
                new {
                    FirstName = "Gastón",
                    LastName = "Mancini",
                    AgencyName = "BRANDON COPSYNC DEMO 1",
                    Distance = 0M,
                    IsOnLine = false,
                    Type = "dispatcher"
                },
            };

            var devices = new [] {
                new {
                    Id = new Guid("13973b2c-9f4a-4419-8c9e-3999fca4630d"),
                    UserName = "BUBBA1",
                    Description = (string)null,
                    CurrentLocationName = "Classroom 33",
                    Organization = new {
                        Id = Guid.NewGuid(),
                        Name = "OrganizationName"
                    },
                },
                new  {
                    Id = new Guid("23973b2c-9f4a-4419-8c9e-3999fca4630d"),
                    UserName = "BUBBA2",
                    Description = (string)null,
                    CurrentLocationName = "Classroom 34",
                    Organization = new  {
                        Id = Guid.NewGuid(),
                        Name = "OrganizationName"
                    },
                },
                new {
                    Id = new Guid("33973b2c-9f4a-4419-8c9e-3999fca4630d"),
                    UserName = (string)null,
                    Description = "BUBBA3",
                    CurrentLocationName = "Classroom 35",
                    Organization = new {
                        Id = Guid.NewGuid(),
                        Name = "OrganizationName"
                    },
                },
                new {
                    Id = new Guid("43973b2c-9f4a-4419-8c9e-3999fca4630d"),
                    UserName = "BUBBA4",
                    Description = (string)null,
                    CurrentLocationName = "Classroom 36",
                    Organization = new {
                        Id = Guid.NewGuid(),
                        Name = "OrganizationName"
                    },
                },
            };
            var onLineDevicesIdsHash = new [] {
                "23973b2c-9f4a-4419-8c9e-3999fca4630d",
                "33973b2c-9f4a-4419-8c9e-3999fca4630d"
            };

            var listOrgQueues = new [] {
                new {
                    OrganizationName = "OrganizationName",
                    QueueName = "QueueName",
                    EncryptionAlgorithm = "Diffie-Hellman",
                    HashingFunction = "SHA1"
                }
            };

            var model =
                new {
                    emailTitle = subject,
                    testMode = alert.TestMode,
                    alertDay = alert.CreatedOnClient == null ? UNKNOWN : alert.CreatedOnClient.UtcDateTime.ToString("yyyy-MM-dd HH:mm:ss UTC"),
                    agencyName = alert.OrganizationName ?? UNKNOWN,
                    orgLocation = alert.PartyLocationName ?? UNKNOWN,
                    orgAddress = alert.Address ?? UNKNOWN,
                    userName = alert.UserName ?? UNKNOWN,
                    userFullname = alert.UserFullName ?? "-",
                    orgLatitude = alert.Latitude,
                    orgLongitude = alert.Longitude,
                    appVersion = string.Format("{0} v{1}", alert.OriginDescription, alert.OriginVersion),
                    alertText = alert.InitialMessage,
                    ipAddress = alert.RequestIPAddress ?? UNKNOWN,
                    macAddress = alert.RequestMACAddress ?? UNKNOWN,
                    status = alert.Success ? "Success" : "Failed",
                    errorMessage = alert.Success ? string.Empty : alert.ErrorDetails ?? UNKNOWN,
                    success = alert.Success,
                    officers = lawUsers.Where(x => "officer".Equals(x.Type, StringComparison.InvariantCultureIgnoreCase)).Select((x, i) => new {
                        colorRow = i % 2 == 0 ? "#EBF3FA" : "#FFFFFF",
                        actorName = string.Format("{0} {1}", x.FirstName, x.LastName),
                        agencyName = x.AgencyName ?? UNKNOWN,
                        actorDistance = x.Distance.ToString(CultureInfo.InvariantCulture),
                        colorOnline = x.IsOnLine ? "#CAF0CC" : "#F9C7CE",
                        alertSent = x.IsOnLine ? "YES" : "NO",
                    }),
                    dispatchers = lawUsers.Where(x => "dispatcher".Equals(x.Type, StringComparison.InvariantCultureIgnoreCase)).Select((x, i) => new {
                        colorRow = i % 2 == 0 ? "#EBF3FA" : "#FFFFFF",
                        actorName = string.Format("{0} {1}", x.FirstName, x.LastName),
                        agencyName = x.AgencyName ?? UNKNOWN,
                        colorOnline = x.IsOnLine ? "#CAF0CC" : "#F9C7CE",
                        alertSent = x.IsOnLine ? "YES" : "NO",
                    }),
                    recipients = devices.Select((x, i) => new {
                        colorRow = i % 2 == 0 ? "#EBF3FA" : "#FFFFFF",
                        actorLink = x.Organization == null ? null : string.Format("{0}/redirect/organizations/{1}/devices/{2}", baseUrl, x.Organization.Id, x.Id),
                        actorName = x.UserName ?? x.Description ?? UNKNOWN,
                        currentLocation = x.CurrentLocationName ?? UNKNOWN,
                        colorOnline = onLineDevicesIdsHash.Contains(x.Id.ToString()) ? "#CAF0CC" : "#F9C7CE",
                        alertSent = onLineDevicesIdsHash.Contains(x.Id.ToString()) ? "YES" : "NO",
                    }),
                    busRecipients = listOrgQueues.Select((x, i) => new {
                        colorRow = i % 2 == 0 ? "#EBF3FA" : "#FFFFFF",
                        agencyName = x.OrganizationName ?? UNKNOWN,
                        actorName = x.QueueName ?? UNKNOWN,
                        encryption = x.EncryptionAlgorithm ?? UNKNOWN,
                        hashing = x.HashingFunction ?? UNKNOWN,
                    }),
                    afterActionUrl = string.Format("{0}/redirect/reports/copsync911alerts/{1}", baseUrl, alert.RequestId),
                    currentYear = DateTime.Now.Year,
                };

            return model;
        }

        private string GenerateTemplate()
        {
            var template =
"<html lang=\"en\">\r\n" +
"<head>\r\n" +
"    <title>Copsync Email</title>\r\n" +
"    <meta charset=\"utf-8\">\r\n" +
"    <meta name=\"viewport\" content=\"width=device-width\">\r\n" +
"    <!--{{ MODEL\r\n" +
"        emailTitle : string,\r\n" +
"        testMode : boolean,\r\n" +
"        alertDay : string,\r\n" +
"        agencyName : string,\r\n" +
"        orgLocation : string,\r\n" +
"        orgAddress : string,\r\n" +
"        userName : string,\r\n" +
"        userFullname : string,\r\n" +
"        orgLatitude : string,\r\n" +
"        orgLongitude : string,\r\n" +
"        appVersion : string,\r\n" +
"        alertText : string,\r\n" +
"        ipAddress : string,\r\n" +
"        macAddress : string,\r\n" +
"        status : string,\r\n" +
"        errorMessage : string,\r\n" +
"        success : boolean,\r\n" +
"        officers : list {\r\n" +
"            new {\r\n" +
"                colorRow : string, // pair:#EBF3FA / odd:#FFFFFF\r\n" +
"                actorName : string,\r\n" +
"                agencyName : string,\r\n" +
"                actorDistance : string,\r\n" +
"                colorOnline : string, // connected:#CAF0CC / offline:#F9C7CE\r\n" +
"                alertSent : string, // YES / NO\r\n" +
"            },\r\n" +
"        },\r\n" +
"        dispatchers : list {\r\n" +
"            new {\r\n" +
"                colorRow : string, // pair:#EBF3FA / odd:#FFFFFF\r\n" +
"                actorName : string,\r\n" +
"                agencyName : string,\r\n" +
"                colorOnline : string, // connected:#CAF0CC / offline:#F9C7CE\r\n" +
"                alertSent : string, // YES / NO\r\n" +
"            },\r\n" +
"        },\r\n" +
"        recipients : list {\r\n" +
"            new {\r\n" +
"                colorRow : string, // pair:#EBF3FA / odd:#FFFFFF\r\n" +
"                actorLink : string,\r\n" +
"                actorName : string,\r\n" +
"                currentLocation : string,\r\n" +
"                colorOnline : string, // connected:#CAF0CC / offline:#F9C7CE\r\n" +
"                alertSent : string, // YES / NO\r\n" +
"            },\r\n" +
"        },\r\n" +
"        busRecipients : list {\r\n" +
"            new {\r\n" +
"                colorRow : string, // pair:#EBF3FA / odd:#FFFFFF\r\n" +
"                agencyName : string,\r\n" +
"                actorName : string,\r\n" +
"                encryption : string,\r\n" +
"                hashing : string,\r\n" +
"            },\r\n" +
"        },\r\n" +
"        afterActionUrl : string,\r\n" +
"        currentYear : string,\r\n" + 
"    }}-->\r\n" +
"</head>\r\n" +
"<body style=\"margin: 0; padding: 0;\">\r\n" +
"    <style type=\"text/css\">\r\n" +
"        /* Force Outlook to provide a \"view in browser\" message */\r\n" +
"        #outlook a {\r\n" +
"            padding: 0;\r\n" +
"        }\r\n" +
"        /* Force Hotmail to display emails at full width */\r\n" +
"        .ReadMsgBody {\r\n" +
"            width: 100%;\r\n" +
"        }\r\n" +
"\r\n" +
"        .ExternalClass {\r\n" +
"            width: 100%;\r\n" +
"        }\r\n" +
"            /* Force Hotmail to display normal line spacing */\r\n" +
"            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {\r\n" +
"                line-height: 100%;\r\n" +
"            }\r\n" +
"        /* Prevent WebKit and Windows mobile changing default text sizes */\r\n" +
"        body, table, td, a {\r\n" +
"            -webkit-text-size-adjust: 100%;\r\n" +
"            -ms-text-size-adjust: 100%;\r\n" +
"        }\r\n" +
"        /* Remove spacing between tables in Outlook 2007 and up */\r\n" +
"        table, td {\r\n" +
"            mso-table-lspace: 0pt;\r\n" +
"            mso-table-rspace: 0pt;\r\n" +
"        }\r\n" +
"        /* Allow smoother rendering of resized image in Internet Explorer */\r\n" +
"        img {\r\n" +
"            -ms-interpolation-mode: bicubic;\r\n" +
"        }\r\n" +
"        /* RESET STYLES */\r\n" +
"        body {\r\n" +
"            margin: 0;\r\n" +
"            padding: 0;\r\n" +
"            height: 100% !important;\r\n" +
"            width: 100% !important;\r\n" +
"        }\r\n" +
"\r\n" +
"        img {\r\n" +
"            border: 0;\r\n" +
"            height: auto;\r\n" +
"            line-height: 100%;\r\n" +
"            outline: none;\r\n" +
"            text-decoration: none;\r\n" +
"            display: block;\r\n" +
"        }\r\n" +
"\r\n" +
"        table {\r\n" +
"            border-collapse: collapse !important;\r\n" +
"        }\r\n" +
"        /* iOS BLUE LINKS */\r\n" +
"        .appleBody a {\r\n" +
"            color: #68440a;\r\n" +
"            text-decoration: none;\r\n" +
"        }\r\n" +
"\r\n" +
"        .appleFooter a {\r\n" +
"            color: #999999;\r\n" +
"            text-decoration: none;\r\n" +
"        }\r\n" +
"    </style>\r\n" +
"    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"900\" align=\"center\">\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"line-height: 0px; padding-top: 30px; padding-bottom: 25px;\"><img src=\"https://dataonixnonprod.blob.core.windows.net/images/v2/logoCOPsync911.png\" style=\"display: block;\" border=\"0\" /></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-top: 25px; border-top: 1px solid #E0E0E0\"><span style=\"color: #444444; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 30px;\">{{= emailTitle }}</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"20\"></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ IF #testMode testMode }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EEB700\" height=\"36\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: 14px; font-weight: bold;\">THIS IS A TEST -- THIS IS NOT A LIVE ALERT</span></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIF #testMode }}-->\r\n" +
"        <tr>\r\n" +
"            <td style=\"padding-top: 30px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ALERT DETAILS</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px;\">\r\n" +
"                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Date</span></td>\r\n" +
"                        <td width=\"300\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= alertDay }}</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= agencyName }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Address</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= orgLocation }}</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= orgAddress }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Name</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Full Name</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= userName }}</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= userFullname }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Latitude</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Longitude</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= orgLatitude }}</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= orgLongitude }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Application Version</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= appVersion }}</span>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Text</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= alertText }}</span>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request IP Address</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request MAC Address</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= ipAddress }}</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= macAddress }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ IF #success1 success }}-->\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Status</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" colspan=\"2\">\r\n" +
"                            <span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= status }}</span>\r\n" +
"                        </td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ ENDIF #success1 }}-->\r\n" +
"                    <!--{{ IFNOT #not_success success }}-->\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Status</span></td>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Error Message</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= status }}</span>\r\n" +
"                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">{{= errorMessage }}</span>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ ENDIFNOT #not_success }}-->\r\n" +
"                </table>\r\n" +
"            </td>\r\n" +
"        </tr>\r\n" +
"    <!--{{ IF #success2 success }}-->\r\n" +
"        <tr>\r\n" +
"            <td style=\"padding-top: 40px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">OFFICERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ IFNOT #not_hasOfficers officers }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Officers were associated with this alert.</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIFNOT #not_hasOfficers }}-->\r\n" +
"        <!--{{ IF #hasOfficers officers }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n" +
"                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF; border-right: 1px solid #FFFFFF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Agency Name</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Distance (miles)</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ EACH #officers officers }}-->\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= actorName }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= agencyName }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= actorDistance }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorOnline }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= alertSent }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ ENDEACH #officers }}-->\r\n" +
"                </table>\r\n" +
"            </td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIF #hasOfficers }}-->\r\n" +
"        <tr>\r\n" +
"            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DISPATCHERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ IFNOT #not_hasDispatchers dispatchers }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Dispatchers were associated with this alert.</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIFNOT #not_hasDispatchers }}-->\r\n" +
"        <!--{{ IF #hasDispatchers dispatchers }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n" +
"                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF; border-right: 1px solid #FFFFFF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Agency Name</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ EACH #dispatchers dispatchers }}-->\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= actorName }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= agencyName }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorOnline }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= alertSent }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ ENDEACH #dispatchers }}-->\r\n" +
"                </table>\r\n" +
"            </td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIF #hasDispatchers }}-->\r\n" +
"        <tr>\r\n" +
"            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DEVICES THAT RECEIVED THIS ALERT IN COPSYNC911</span></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ IFNOT #not_hasRecipients recipients }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Recipients were associated with this alert.</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIFNOT #not_hasRecipients }}-->\r\n" +
"        <!--{{ IF #hasRecipients recipients }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n" +
"                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n" +
"                    <tr>\r\n" +
"                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n" +
"                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Current Location</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n" +
"                        <td height=\"25\" style=\"border-top: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ EACH #recipients recipients }}-->\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">\r\n" +
"                            <!--{{ IF #actorHasLink actorLink }}-->\r\n" +
"                                <a href=\"{{= actorLink }}\">{{= actorName }}</a>\r\n" +
"                            <!--{{ ENDIF #actorHasLink }}-->\r\n" +
"                            <!--{{ IFNOT #not_actorHasLink actorLink }}-->\r\n" +
"                                {{= actorName }}\r\n" +
"                            <!--{{ ENDIFNOT #not_actorHasLink }}-->\r\n" +
"                        </span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= currentLocation }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorOnline }}\" style=\"border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= alertSent }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ ENDEACH #recipients }}-->\r\n" +
"                </table>\r\n" +
"            </td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIF #hasRecipients }}-->\r\n" +
"        <tr>\r\n" +
"            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ORGANIZATIONS THAT RECEIVED THIS ALERT VIA QUEUE MESSAGES</span></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ IFNOT #not_hasBusRecipients busRecipients }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Service Bus recipients were associated with this alert.</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIFNOT #not_hasBusRecipients }}-->\r\n" +
"        <!--{{ IF #hasBusRecipients busRecipients }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n" +
"                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Organization</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Queue</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Encryption Algorithm</span></td>\r\n" +
"                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Hashing Function</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ EACH #busRecipients busRecipients }}-->\r\n" +
"                    <tr>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= agencyName }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= actorName }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= encryption }}</span></td>\r\n" +
"                        <td height=\"25\" bgcolor=\"{{= colorRow }}\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">{{= hashing }}</span></td>\r\n" +
"                    </tr>\r\n" +
"                    <!--{{ ENDEACH #busRecipients }}-->\r\n" +
"                </table>\r\n" +
"            </td>\r\n" +
"        </tr>\r\n" +
"        <!--{{ ENDIF #hasBusRecipients }}-->\r\n" +
"    <!--{{ ENDIF #success2 }}-->\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px; border-bottom: 1px solid #E0E0E0; padding-bottom: 15px;\"><span style=\"color: #666666; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">The Dataonix Team</span></td>\r\n" +
"        </tr>\r\n" +
"        <tr>\r\n" +
"            <td align=\"left\" valign=\"top\" style=\"padding-top: 20px; padding-bottom: 20px;\"><span style=\"color: #444444; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">Copyright © {{= currentYear }} COPsync, Inc., a Dataonix company. All rights reserved.</span></td>\r\n" +
"        </tr>\r\n" +
"    </table>\r\n" +
"</body>\r\n" +
"</html>\r\n";
            return template;
        }

        private string IdealEngineSimulator(object model)
        {
            return "<html lang=\"en\">\r\n<head>\r\n    <title>Copsync Email</title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width\">\r\n    \r\n</head>\r\n<body style=\"margin: 0; padding: 0;\">\r\n    <style type=\"text/css\">\r\n        /* Force Outlook to provide a \"view in browser\" message */\r\n        #outlook a {\r\n            padding: 0;\r\n        }\r\n        /* Force Hotmail to display emails at full width */\r\n        .ReadMsgBody {\r\n            width: 100%;\r\n        }\r\n\r\n        .ExternalClass {\r\n            width: 100%;\r\n        }\r\n            /* Force Hotmail to display normal line spacing */\r\n            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {\r\n                line-height: 100%;\r\n            }\r\n        /* Prevent WebKit and Windows mobile changing default text sizes */\r\n        body, table, td, a {\r\n            -webkit-text-size-adjust: 100%;\r\n            -ms-t" +
"ext-size-adjust: 100%;\r\n        }\r\n        /* Remove spacing between tables in Outlook 2007 and up */\r\n        table, td {\r\n            mso-table-lspace: 0pt;\r\n            mso-table-rspace: 0pt;\r\n        }\r\n        /* Allow smoother rendering of resized image in Internet Explorer */\r\n        img {\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n        /* RESET STYLES */\r\n        body {\r\n            margin: 0;\r\n            padding: 0;\r\n            height: 100% !important;\r\n            width: 100% !important;\r\n        }\r\n\r\n        img {\r\n            border: 0;\r\n            height: auto;\r\n            line-height: 100%;\r\n            outline: none;\r\n            text-decoration: none;\r\n            display: block;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse !important;\r\n        }\r\n        /* iOS BLUE LINKS */\r\n        .appleBody a {\r\n            color: #68440a;\r\n            text-decoration: none;\r\n        }\r\n\r" +
"\n        .appleFooter a {\r\n            color: #999999;\r\n            text-decoration: none;\r\n        }\r\n    </style>\r\n    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"900\" align=\"center\">\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"line-height: 0px; padding-top: 30px; padding-bottom: 25px;\"><img src=\"https://dataonixnonprod.blob.core.windows.net/images/v2/logoCOPsync911.png\" style=\"display: block;\" border=\"0\" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 25px; border-top: 1px solid #E0E0E0\"><span style=\"color: #444444; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 30px;\">TEST 0</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"20\"></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EEB700" +
"\" height=\"36\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: 14px; font-weight: bold;\">THIS IS A TEST -- THIS IS NOT A LIVE ALERT</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"padding-top: 30px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ALERT DETAILS</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Date</span></td>\r\n      " +
"                  <td width=\"300\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">2014-11-08 10:58:08 UTC</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">OrganizationName</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td al" +
"ign=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Address</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">PartyLocationName</sp" +
"an></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">222 Rosewood Drive</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Name</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Full Name</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=" +
"\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">MSIELICKIW7</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">-</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Latitude</span></td>\r\n                  " +
"      <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Longitude</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">42.569581725128536</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">-70.90723894122314</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left" +
"\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Application Version</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">COPsync911 v1.12.5381.31543</span>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                  " +
"      <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Text</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">TEST - Assistance requested from DANVERS SCHOOL DISTRICT 1, Ranger High School, 222 Rosewood Drive, Danvers, Massachusetts, 01923, Location: Classroom 16</span>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td wid" +
"th=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request IP Address</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request MAC Address</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">50.199.226.109</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Aria" +
"l, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">D0-DF-9A-F8-7C-A7</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Status</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\">\r\n                            <span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">Success</span>\r\n" +
"                        </td>\r\n                    </tr>\r\n                    \r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n    \r\n        <tr>\r\n            <td style=\"padding-top: 40px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">OFFICERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"" +
"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF; border-right: 1px solid #FFFFFF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; co" +
"lor: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Agency Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Distance (miles)</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weig" +
"ht: bold;\">Enabled</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Andrés Moschini</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin" +
"-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">BRANDON COPSYNC DEMO 1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">3</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#CAF0CC\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padd" +
"ing: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Matías Beckerle</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">BRANDON COPSYNC DEMO 1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\"" +
" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">0</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#F9C7CE\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">NO</span></td>\r\n                    </tr>\r\n                    \r\n            " +
"    </table>\r\n            </td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DISPATCHERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" style=\"padding-l" +
"eft: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF; border-right: 1px solid #FFFFFF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bott" +
"om: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Agency Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" vali" +
"gn=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Gastón Kolocsar</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">BRANDON COPSYNC DEMO 1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#CAF0CC\" style=\"border-right: 1px solid #CCCCCC; border-" +
"bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Gastón Mancini</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">BRANDON COPSYNC DEM" +
"O 1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#F9C7CE\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">NO</span></td>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-" +
"weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DEVICES THAT RECEIVED THIS ALERT IN COPSYNC911</span></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top" +
": 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Current Location</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding:" +
" 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n                        <td height=\"25\" style=\"border-top: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">\r\n                            \r\n                                <a href=\"http://alerts.com/redirect/organi" +
"zations/d9f4cd3e-63be-48e3-a5f8-aa37c92e1c9e/devices/13973b2c-9f4a-4419-8c9e-3999fca4630d\">BUBBA1</a>\r\n                            \r\n                            \r\n                        </span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Classroom 33</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#F9C7CE\" style=\"border-bottom: 1px solid #CCCCCC\" align=\"cent" +
"er\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">NO</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">\r\n                            \r\n                                <a href=\"http://alerts.com/redirect/organizations/7288fd6b-b50e-40cb-8e81-a6995a74c63a/devices/23973b2c-9f4a-4419-8c9e-3999fca4630d\">BUBBA2</a>\r\n                            \r\n                            \r\n                        </span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; b" +
"order-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Classroom 34</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#CAF0CC\" style=\"border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolo" +
"r=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">\r\n                            \r\n                                <a href=\"http://alerts.com/redirect/organizations/3e981c26-5230-40fc-a4b8-b6e49a6cbd36/devices/33973b2c-9f4a-4419-8c9e-3999fca4630d\">BUBBA3</a>\r\n                            \r\n                            \r\n                        </span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Classroom 35</span></td>\r\n                        <td height=\"25\" bgcolor=\"#E" +
"BF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#CAF0CC\" style=\"border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">\r\n                      " +
"      \r\n                                <a href=\"http://alerts.com/redirect/organizations/51356460-bf44-4cd1-a3b0-c7864a2fcf9f/devices/43973b2c-9f4a-4419-8c9e-3999fca4630d\">BUBBA4</a>\r\n                            \r\n                            \r\n                        </span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Classroom 36</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td heig" +
"ht=\"25\" bgcolor=\"#F9C7CE\" style=\"border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">NO</span></td>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ORGANIZATIONS THAT RECEIVED THIS ALERT VIA QUEUE MESSAGES</span></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n          " +
"          <tr>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Organization</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Queue</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Encryption Algor" +
"ithm</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Hashing Function</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">OrganizationName</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; paddi" +
"ng: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">QueueName</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Diffie-Hellman</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">SHA1</span></td>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n        \r\n    \r\n        <tr>\r\n " +
"           <td align=\"left\" valign=\"top\" style=\"padding-top: 15px; border-bottom: 1px solid #E0E0E0; padding-bottom: 15px;\"><span style=\"color: #666666; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">The Dataonix Team</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 20px; padding-bottom: 20px;\"><span style=\"color: #444444; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">Copyright © 2014 COPsync, Inc., a Dataonix company. All rights reserved.</span></td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>\r\n";
        }

        #endregion

        [TestMethod]
        public void ItShouldTakeLessThan3MillisecondsEachMessage()
        {
            var template = GenerateTemplate();
            var q = 5000;
            var swIdeal = new Stopwatch();
            var swReal = new Stopwatch();
            int strIdeal = 0;
            int strReal = 0;
            var tEngine = new SimpleTemplateEngine.TemplateEngine();

            swIdeal.Restart();
            for (var i = 0; i < q; i++)
            {
                var model = GenerateModel(i);
                var result = IdealEngineSimulator(model);
                // To avoid possible code optimizations
                strIdeal += result.Length;
            }
            swIdeal.Stop();
            var idealTime = swIdeal.ElapsedMilliseconds;
            Console.WriteLine("Ignore it: {0}", strIdeal);

            swReal.Restart();
            for (var i = 0; i < q; i++)
            {
                var model = GenerateModel(i);
                var result = tEngine.ProcessString(template, model);
                // To avoid possible code optimizations
                strReal += result.Length;
            }
            swReal.Stop();
            var realTime = swReal.ElapsedMilliseconds;
            Console.WriteLine("Ignore it: {0}", strReal);

            var relation = (decimal)realTime / idealTime;
            var msByMessage = (decimal)realTime / q;

            Console.WriteLine("Ideal Template Engine time: {0}", idealTime);
            Console.WriteLine("Current Template Engine time: {0}", realTime);
            Console.WriteLine("Relation: {0}x", relation);
            Console.WriteLine("Milliseconds by message: {0}", msByMessage);

            Assert.IsTrue(msByMessage < 3);
        }
    }
}
