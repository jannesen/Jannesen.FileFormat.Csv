using System;

namespace Jannesen.FileFormat.Csv
{
    [Serializable]
    public class CsvException : Exception
    {
        public  CsvException(string Message) : base(Message)
        {
        }
        public  CsvException(string Message, Exception InnerException) : base(Message, InnerException)
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
