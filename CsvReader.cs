using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jannesen.FileFormat.Csv
{
    public class CsvReader: IDisposable
    {
        private                     TextReader          _textReader;
        private readonly            CsvOptions          _options;
        private readonly            StringBuilder       _buf;
        private                     int                 _rowIndex;

        public                                  CsvReader(TextReader textReader, CsvOptions options)
        {
            if (textReader is null) throw new ArgumentNullException(nameof(textReader));
            if (options is null) throw new ArgumentNullException(nameof(options));

            _textReader = textReader;
            _options    = options;
            _rowIndex   = 0;
            _buf        = new StringBuilder(256);
        }
                                                ~CsvReader()
        {
            Dispose(false);
        }
        public              void                Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual   void                Dispose(bool disposing)
        {
            if (_textReader != null) {
                _textReader.Dispose();
                _textReader = null;
            }
        }

        public              CsvRow              ReadRow()
        {
            int     c;
            int     colIndex = 0;
            var     cells = new List<CsvCell>();

            if (_textReader == null)
                throw new ObjectDisposedException("CsvReader disposed.");

            c = _textReader.Read();
            if (c < 0)
                return null;

            for (;;) {
                _buf.Length = 0;

                if (c == _options.StringQuote) {
                    for (;;) {
                        c = _textReader.Read();
                        if (c < 0)
                            throw new CsvException("EOF in quoted field.");

                        if (c == _options.StringQuote) {
                            c = _textReader.Read();
                            if (c != _options.StringQuote)
                                break;
                        }

                        _buf.Append((char)c);
                    }
                }
                else {
                    while (c >= 0 && c != _options.FieldSeperator && c != '\n' && c != '\r') {
                        _buf.Append((char)c);
                        c = _textReader.Read();
                    }
                }

                cells.Add(new CsvCell(_rowIndex, colIndex++, _buf.ToString(), _options));

                if (c == _options.FieldSeperator) {
                    c = _textReader.Read();
                    continue;
                }

                if (c == '\r')
                    c = _textReader.Read();

                if (c == '\n' || c < 0) {
                    ++ _rowIndex;
                    return new CsvRow(cells.ToArray());
                }

                throw new CsvException("Invalid char in CSV document at row " +_rowIndex + ".");
            }
        }
    }
}
