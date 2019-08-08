using System;
using System.Runtime.Serialization;

namespace Jannesen.FileFormat.Csv
{
    [Serializable]
    public class CsvException : Exception
    {
        public                          CsvException(string Message) : base(Message)
        {
        }
        public                          CsvException(string Message, Exception InnerException) : base(Message, InnerException)
        {
        }
        protected                       CsvException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        public override     string      Source
        {
            get {
                return "Jannesen.FileFormat.CsvException";
            }
        }
    }
}
