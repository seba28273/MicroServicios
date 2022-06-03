using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace Luse.Telerecargas.Services
{

    public class CustomTextMessageBindingElement : MessageEncodingBindingElement
    {
        private MessageVersion _msgVersion;
        private string _mediaType;
        private string _encoding;
        private XmlDictionaryReaderQuotas _readerQuotas;

        private CustomTextMessageBindingElement(CustomTextMessageBindingElement binding)
            : this(binding.Encoding, binding.MediaType, binding.MessageVersion)
        {
            _readerQuotas = new XmlDictionaryReaderQuotas();
            binding.ReaderQuotas.CopyTo(_readerQuotas);
        }

        public CustomTextMessageBindingElement(string encoding, string mediaType, MessageVersion msgVersion)
        {
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            if (mediaType == null)
                throw new ArgumentNullException("mediaType");

            if (msgVersion == null)
                throw new ArgumentNullException("msgVersion");

            _msgVersion = msgVersion;
            _mediaType = mediaType;
            _encoding = encoding;
            _readerQuotas = new XmlDictionaryReaderQuotas();
        }

        public CustomTextMessageBindingElement(string encoding, string mediaType)
            : this(encoding, mediaType, MessageVersion.Soap12WSAddressing10)
        {
        }

        public CustomTextMessageBindingElement(string encoding)
            : this(encoding, "text/xml")
        {
        }

        public override MessageVersion MessageVersion
        {
            get { return _msgVersion; }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _msgVersion = value;
            }
        }

        public string MediaType
        {
            get { return _mediaType; }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _mediaType = value;
            }
        }

        public string Encoding
        {
            get { return _encoding; }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _encoding = value;
            }
        }

        // This encoder does not enforces any quotas for the unsecure messages. The 
        // quotas are enforced for the secure portions of messages when this encoder
        // is used in a binding that is configured with security. 
        public XmlDictionaryReaderQuotas ReaderQuotas
        {
            get { return _readerQuotas; }
        }

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new CustomTextMessageEncoderFactory(MediaType,
                Encoding, MessageVersion);
        }

        public override BindingElement Clone()
        {
            return new CustomTextMessageBindingElement(this);
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            return context.CanBuildInnerChannelFactory<TChannel>();
        }

        //public override COM.Microsoft.AppCenter.Channel.IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException("context");

        //    context.BindingParameters.Add(this);
        //    return context.BuildInnerChannelListener<TChannel>();
        //}

        //public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException("context");

        //    context.BindingParameters.Add(this);
        //    return context.CanBuildInnerChannelListener<TChannel>();
        //}

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
            {
                return (T)(object)_readerQuotas;
            }

            return base.GetProperty<T>(context);
        }
    }

    internal class CustomTextMessageEncoderFactory : MessageEncoderFactory
    {
        private MessageEncoder _encoder;
        private MessageVersion _version;
        private string _mediaType;
        private string _charSet;

        internal CustomTextMessageEncoderFactory(string mediaType, string charSet, MessageVersion version)
        {
            _version = version;
            _mediaType = mediaType;
            _charSet = charSet;
            _encoder = new CustomTextMessageEncoder(this);
        }

        public override MessageEncoder Encoder
        {
            get { return _encoder; }
        }

        public override MessageVersion MessageVersion
        {
            get { return _version; }
        }

        internal string MediaType
        {
            get { return _mediaType; }
        }

        internal string CharSet
        {
            get { return _charSet; }
        }
    }


    internal class CustomTextMessageEncoder : MessageEncoder
    {
        private CustomTextMessageEncoderFactory _factory;
        private XmlWriterSettings _writerSettings;
        private string _contentType;

        public CustomTextMessageEncoder(CustomTextMessageEncoderFactory factory)
        {
            _factory = factory;

            _writerSettings = new XmlWriterSettings();
            _writerSettings.Encoding = Encoding.GetEncoding(factory.CharSet);
            _writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            _writerSettings.OmitXmlDeclaration = false;
            _contentType = string.Format("{0}; charset={1}",
                _factory.MediaType, _writerSettings.Encoding.WebName);
        }

        public override string ContentType
        {
            get { return _contentType; }
        }

        public override string MediaType
        {
            get { return _factory.MediaType; }
        }

        public override MessageVersion MessageVersion
        {
            get { return _factory.MessageVersion; }
        }

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            XmlReader reader = XmlReader.Create(stream);
            return Message.CreateMessage(reader, maxSizeOfHeaders, MessageVersion);
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            byte[] msgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            MemoryStream stream = new MemoryStream(msgContents);
            return ReadMessage(stream, int.MaxValue);
        }

        public override void WriteMessage(Message message, Stream stream)
        {
            using (XmlWriter writer = XmlWriter.Create(stream, _writerSettings))
            {
                message.WriteMessage(writer);
            }

            //    XmlWriter writer = XmlWriter.Create(stream);
            //    XmlDictionaryWriter xmlDW = XmlDictionaryWriter.CreateDictionaryWriter(writer);

            //    message.WriteBodyContents(xmlDW);
            //    xmlDW.Close();
        }

        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            //MemoryStream stream = new MemoryStream();
            //this.WriteMessage(message, stream);

            //int messageLength = (int)stream.Length;
            //byte[] messageBytes = stream.GetBuffer();
            //stream.Close();

            //int totalLength = messageLength + messageOffset;
            //byte[] totalBytes = bufferManager.TakeBuffer(totalLength);
            //Array.Copy(messageBytes, 0, totalBytes, messageOffset, messageLength);

            //ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);
            //return byteArray;

            ArraySegment<byte> messageBuffer;
            byte[] writeBuffer = null;

            int messageLength;
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream, _writerSettings))
                {
                    message.WriteMessage(writer);
                }

                // TryGetBuffer is the preferred path but requires 4.6
                //stream.TryGetBuffer(out messageBuffer);
                writeBuffer = stream.ToArray();
                messageBuffer = new ArraySegment<byte>(writeBuffer);

                messageLength = (int)stream.Position;
            }

            int totalLength = messageLength + messageOffset;
            byte[] totalBytes = bufferManager.TakeBuffer(totalLength);
            Array.Copy(messageBuffer.Array, 0, totalBytes, messageOffset, messageLength);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);
            return byteArray;
        }
    }
}

