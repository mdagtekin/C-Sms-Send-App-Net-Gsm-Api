using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace NetGsmSms
{
    public class SentMe
    {
        XDocument document;
        string PostAdress = "https://api.netgsm.com.tr/sms/send/xml";
        public string MessageSetting(string UserName, string Password, List<Messages> Messages, string HeaderText = null)
        {
            if (UserName != String.Empty || Password != String.Empty || Messages.Count() != 0)
            {
                if (HeaderText == null)
                    HeaderText = UserName;
                document = new XDocument(
                new XElement(
                    "mainbody", new XElement("header",
                    new XElement("company", new XAttribute("dil", "TR"), "Netgsm"),
                    new XElement("usercode", UserName),
                    new XElement("password", Password),
                    new XElement("type", "1:n"),
                    new XElement("msgheader", HeaderText)
                    )
                )
                );
                XElement mp = new XElement("body");
                if (Messages.Count() > 1)
                {
                    foreach (var message in Messages)
                    {
                        mp.Add(new XElement("mp", new XElement("msg", message.Message), new XElement("no", message.PhoneNumber)));
                        document.Root.Element("header").Element("type").Value = "n:n";
                    }
                }
                else if (Messages.Count() == 1)
                {
                    mp.Add(new XElement("msg", Messages.First().Message), new XElement("no", Messages.First().PhoneNumber));
                    document.Root.Element("header").Element("type").Value = "1:n";
                }

                document.Root.Add(mp);
                Console.WriteLine(document.ToString());
                //string res = SentMessage(PostAdress, document.ToString());
                return res;
            }
            else
            {
                return "Gerekli Alanları Doldurunuz Zorunlu Alanlar [UserName,Password,Messages]";
            }
        }

        private string SentMessage(string PostAddress, string data)
        {
            try
            {
                string SentData = "<?xml version='1.0' encoding='UTF-8'?>\n";
                SentData += data;
                WebClient wUpload = new WebClient();
                HttpWebRequest request = WebRequest.Create(PostAddress) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Byte[] bPostArray = Encoding.UTF8.GetBytes(SentData);
                Byte[] bResponse = wUpload.UploadData(PostAddress, "POST", bPostArray);
                Char[] sReturnChars = Encoding.UTF8.GetChars(bResponse);
                string sWebPage = new string(sReturnChars);
                return sWebPage;
            }
            catch (Exception e)
            {
                var da = e;
                return "-1";
            }
        }

        public class Messages
        {
            public string Message { get; set; }
            public string PhoneNumber { get; set; }

            public static implicit operator List<object>(Messages v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
