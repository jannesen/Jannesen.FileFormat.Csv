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
                CsvOptions  Options = new CsvOptions();

                System.Globalization.CultureInfo    CultureInfo = CultureInfo.InvariantCulture;

                Options.Encoding               = Encoding.ASCII;
                Options.FieldSeperator         = ',';
                Options.StringQuote            = '\"';
                Options.DoubleFormatProvider   = CultureInfo.NumberFormat;
                Options.DateFormat             = "yyyy-M-d";
                Options.DateTimeFormat         = "yyyy-M-d H:mm:ss";
                Options.DateTimeFormatProvider = CultureInfo.DateTimeFormat;

                return Options;
            }
        }
        public  static      CsvOptions          NL
        {
            get {
                CsvOptions                          Options = new CsvOptions();

                System.Globalization.CultureInfo    CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");

                Options.Encoding               = Encoding.ASCII;
                Options.FieldSeperator         = ';';
                Options.StringQuote            = '\"';
                Options.DoubleFormatProvider   = CultureInfo.NumberFormat;
                Options.DateFormat             = "d-M-yyyy";
                Options.DateTimeFormat         = "d-M-yyyy H:mm:ss";
                Options.DateTimeFormatProvider = CultureInfo.DateTimeFormat;

                return Options;
            }
        }

        public  virtual     int                 ParseInt(string Value)
        {
            return int.Parse(Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture);
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
