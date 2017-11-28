using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public delegate void MessageSentEventHandler(object sender, MessageSentEventArgs e);

    public enum MessageType
    {
        Navigation,
        Log
    }

    public class MessageSentEventArgs : EventArgs
    {
        public MessageType MessageType { get; private set; }
        public string Message { get; private set; }
        public object Parameter { get; private set; }
        public MessageSentEventArgs(MessageType type)
        {
            MessageType = type;
        }

        public MessageSentEventArgs(MessageType type, string message) : this(type)
        {
            Message = message;
        }

        public MessageSentEventArgs(MessageType type, object parameter) : this(type)
        {
            Parameter = parameter;
        }

        public MessageSentEventArgs(MessageType type, string message, object parameter) : this(type)
        {
            Message = message;
            Parameter = parameter;
        }
    }
}
