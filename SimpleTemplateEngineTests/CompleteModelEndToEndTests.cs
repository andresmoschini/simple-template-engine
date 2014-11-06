﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTemplateEngine;

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
            var result = engine.Process("alert.html", model);
            Assert.AreEqual(
                "<html lang=\"en\">\r\n<head>\r\n    <title>Copsync Email</title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width\">\r\n    \r\n</head>\r\n<body style=\"margin: 0; padding: 0;\">\r\n    <style type=\"text/css\">\r\n        /* Force Outlook to provide a \"view in browser\" message */\r\n        #outlook a {\r\n            padding: 0;\r\n        }\r\n        /* Force Hotmail to display emails at full width */\r\n        .ReadMsgBody {\r\n            width: 100%;\r\n        }\r\n\r\n        .ExternalClass {\r\n            width: 100%;\r\n        }\r\n            /* Force Hotmail to display normal line spacing */\r\n            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {\r\n                line-height: 100%;\r\n            }\r\n        /* Prevent WebKit and Windows mobile changing default text sizes */\r\n        body, table, td, a {\r\n            -webkit-text-size-adjust: 100%;\r\n            -ms-text-size-adjust: 100%;\r\n        }\r\n        /* Remove spacing between tables in Outlook 2007 and up */\r\n        table, td {\r\n            mso-table-lspace: 0pt;\r\n            mso-table-rspace: 0pt;\r\n        }\r\n        /* Allow smoother rendering of resized image in Internet Explorer */\r\n        img {\r\n            -ms-interpolation-mode: bicubic;\r\n        }\r\n        /* RESET STYLES */\r\n        body {\r\n            margin: 0;\r\n            padding: 0;\r\n            height: 100% !important;\r\n            width: 100% !important;\r\n        }\r\n\r\n        img {\r\n            border: 0;\r\n            height: auto;\r\n            line-height: 100%;\r\n            outline: none;\r\n            text-decoration: none;\r\n            display: block;\r\n        }\r\n\r\n        table {\r\n            border-collapse: collapse !important;\r\n        }\r\n        /* iOS BLUE LINKS */\r\n        .appleBody a {\r\n            color: #68440a;\r\n            text-decoration: none;\r\n        }\r\n\r\n        .appleFooter a {\r\n            color: #999999;\r\n            text-decoration: none;\r\n        }\r\n    </style>\r\n    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"900\" align=\"center\">\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"line-height: 0px; padding-top: 30px; padding-bottom: 25px;\"><img src=\"https://dataonixnonprod.blob.core.windows.net/images/v2/logoCOPsync911.png\" style=\"display: block;\" border=\"0\" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 25px; border-top: 1px solid #E0E0E0\"><span style=\"color: #444444; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 30px;\">!emailTitle!</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"20\"></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EEB700\" height=\"36\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: 14px; font-weight: bold;\">THIS IS A TEST -- THIS IS NOT A LIVE ALERT</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"padding-top: 30px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ALERT DETAILS</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Date</span></td>\r\n                        <td width=\"300\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!Today!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!agencyName!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Address</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgLocation!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgAddress!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Name</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">User Full Name</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!userName!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!userFullname!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Latitude</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Organization Location Longitude</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgLatitude!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!orgLongitude!</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Application Version</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!appVersion!</span>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Alert Text</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" colspan=\"2\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!alertText!</span>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request IP Address</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Request MAC Address</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!ipAddress!</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!macAddress!</span></td>\r\n                    </tr>\r\n                    \r\n                    \r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"25\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Status</span></td>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; margin: 0; font-family: Arial, Helvetica, sans-serif; color: #858585; font-size: 12px;\">Error Message</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"5\" colspan=\"2\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td width=\"380\" align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!statusText!</span>\r\n                        <td align=\"left\" valign=\"top\"><span style=\"padding: 0; font-weight: bold; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; color: #78ACD8; font-size: 14px;\">!errorMessage!</span>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n    \r\n        <tr>\r\n            <td style=\"padding-top: 40px; border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">OFFICERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Officers were associated with this alert.</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DISPATCHERS THAT RECEIVED THIS ALERT IN COPSYNC 2.0</span></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-bottom: 30px;\">\r\n                <table cellpadding=\"0\" cellspacing=\"0\" width=\"900\" align=\"center\">\r\n                    <tr>\r\n                        <td align=\"left\" valign=\"top\" height=\"10\" colspan=\"4\"></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" style=\"padding-left: 10px;\" align=\"left\" valign=\"top\"></td>\r\n                        <td height=\"25\" colspan=\"2\" style=\"padding-left: 10px;  background-color:#D0D7DF; border-right: 1px solid #FFFFFF;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #000000; font-weight: bold;\">COPsync Alert</span></td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Agency Name</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Enabled</span></td>\r\n                        <td height=\"25\" style=\"border: 1px solid #CCCCCC; border-left: none;\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #3D3E3F; font-weight: bold;\">Online</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Actor1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Agency1</span></td>\r\n                        <td height=\"25\" bgcolor=\"#EBF3FA\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#CAF0CC\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                    </tr>\r\n                    \r\n                    <tr>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Actor2</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"margin-right: 5px; padding: 0px; margin-bottom: 5px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">Agency2</span></td>\r\n                        <td height=\"25\" bgcolor=\"#FFFFFF\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">YES</span></td>\r\n                        <td height=\"25\" bgcolor=\"#F9C7CE\" style=\"border-right: 1px solid #CCCCCC; border-bottom: 1px solid #CCCCCC\" align=\"center\" valign=\"middle\"><span style=\"padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333333;\">NO</span></td>\r\n                    </tr>\r\n                    \r\n                </table>\r\n            </td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">DEVICES THAT RECEIVED THIS ALERT IN COPSYNC911</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Recipients were associated with this alert.</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n        </tr>\r\n        \r\n        \r\n        <tr>\r\n            <td style=\"border-bottom: 1px solid #CCCCCC; padding-bottom: 10px;\" align=\"left\" valign=\"top\"><span style=\"color: #666666; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: 16px; line-height: 17px; padding: 0px; margin-bottom: 0px; margin-top: 0px;\">ORGANIZATIONS THAT RECEIVED THIS ALERT VIA QUEUE MESSAGES</span></td>\r\n        </tr>\r\n        \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"10\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"center\" width=\"100%\" valign=\"middle\" bgcolor=\"#EBF3FA\" height=\"50\"><span style=\"font-family: Arial, Helvetica, sans-serif; color: #000000; font-size: 12px\">No Service Bus recipients were associated with this alert.</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" height=\"30\"></td>\r\n        </tr>\r\n        \r\n        \r\n    \r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 15px; border-bottom: 1px solid #E0E0E0; padding-bottom: 15px;\"><span style=\"color: #666666; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">The Dataonix Team</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td align=\"left\" valign=\"top\" style=\"padding-top: 20px; padding-bottom: 20px;\"><span style=\"color: #444444; font-size: 12px; padding: 0px; margin-bottom: 0px; margin-top: 0px; font-family: Arial, Helvetica, sans-serif\">Copyright © @DateTime.Now.Year COPsync, Inc., a Dataonix company. All rights reserved.</span></td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>",
                result);
        }

    }
}