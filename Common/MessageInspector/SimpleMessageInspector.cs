using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace WSDLTest.Common.MessageInspector
{
    public class SimpleMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            Console.WriteLine(reply.ToString());
            var soapfssresult = reply.ToString();
            //var decryptSs = CryptoTools.DecryptXml(soapfssresult);
            //reply = CreateMessageFromString(decryptSs, MessageVersion.Soap11);
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            throw new NotImplementedException();
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request,
            System.ServiceModel.IClientChannel channel)
        {
            Console.WriteLine($"====SimpleMessageInspector+BeforeSendRequest is called=====    {DateTime.Now}");

            //var req = request.ToString();

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(req);
            //XmlElement xmlElement;
            //CryptoTools cryptoTools = new CryptoTools();

            //XmlNodeList bodyNode = doc.GetElementsByTagName("Body", Constants.xmlns_soapenv);
            //if (bodyNode != null && bodyNode.Count == 1)
            //{
            //    XmlElement body = bodyNode[0] as XmlElement;
            //    body.SetAttribute("xmlns:wsu", Constants.xmlns_wsu);
            //    body.SetAttribute("Id", Constants.xmlns_wsu, $"OGRN_{Constants.OGRN}");
            //    xmlElement = cryptoTools.GenerateSecurity(doc, Constants.CertificateMO, "OGRN", Constants.OGRN);
            //}
            //else
            //{
            //    throw new Exception($"Не удалось найти подписываемый сегмент {$"OGRN_{Constants.OGRN}"} в сообщении.");
            //}
            //XmlDocument encryptionXML = CryptoTools.EncryptionXML(doc, Constants.CertificateFss,
            //    Constants.CertificateMO);
            //request = CreateMessageFromString(encryptionXML.OuterXml, MessageVersion.Soap11);



            return null;
        }
        Message CreateMessageFromString(String xml, MessageVersion ver)
        {
            return Message.CreateMessage(XmlReaderFromString(xml), int.MaxValue, ver);
        }
        private XmlReader XmlReaderFromString(string xml)
        {
            return XmlReader.Create(new StringReader(xml));
        }
    }
}
