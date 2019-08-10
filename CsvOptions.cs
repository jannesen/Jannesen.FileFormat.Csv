using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Jannesen.FileFormat.Csv
{
    public class CsvOptions
    {
        public              Encoding            Encoding                    { get; set; }
        public              char                FieldSeperator              { get; set; }
        public              char                StringQuote                 { get; set; }
        public              IFormatProvider     DoubleFormatProvider        { get; set; }
        public              string              DateFormat                  { get; set; }
        public              string              DateTimeFormat              { get; set; }
        public              IFormatProvider     DateTimeFormatProvider      { get; set; }

        public                                  CsvOptions()
        {
        }

        public  static      CsvOptions          US
        {
            get {
                var    cultureInfo = CultureInfo.InvariantCulture;

                return new CsvOptions() {
                           Encoding               = Encoding.ASCII,
                           FieldSeperator         = ',',
                           StringQuote            = '\"',
                           DoubleFormatProvider   = cultureInfo.NumberFormat,
                           DateFormat             = "yyyy-M-d",
                           DateTimeFormat         = "yyyy-M-d H:mm:ss",
                           DateTimeFormatProvider = cultureInfo.DateTimeFormat
                       };
            }
        }
        public  static      CsvOptions          NL
        {
            get {
                var    CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");

                return new CsvOptions() {
                           Encoding               = Encoding.ASCII,
                           FieldSeperator         = ';',
                           StringQuote            = '\"',
                           DoubleFormatProvider   = CultureInfo.NumberFormat,
                           DateFormat             = "d-M-yyyy",
                           DateTimeFormat         = "d-M-yyyy H:mm:ss",
                           DateTimeFormatProvider = CultureInfo.DateTimeFormat
                       };
            }
        }

        public  virtual     int                 ParseInt(string Value)
        {
            return int.Parse(Value, NumberStyles.Integer, CultureInfo.InvariantCulture);
        }
        public  virtual     double              ParseDouble(string Value)
        {
            return double.Parse(Value, DoubleFormatProvider);
        }
        public  virtual     DateTime            ParseDateTime(string Value)
        {
            return DateTime.ParseExact(Value, DateTimeFormat, DateTimeFormatProvider);
        }
    }
}
