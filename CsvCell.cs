﻿using System;
using System.Collections.Generic;

namespace Jannesen.FileFormat.Csv
{
    public sealed class CsvCell
    {
        private readonly    int             _colIndex;
        private readonly    int             _rowIndex;
        private readonly    string          _value;
        private readonly    CsvOptions      _options;

        public              string          ValueString
        {
            get {
                return _value;
            }
        }
        public              int             ValueInt
        {
            get {
                try {
                    return _options.ParseInt(_value);
                }
                catch(Exception) {
                    throw new InvalidOperationException("Cell("+_rowIndex+","+_colIndex+") is not a integer.");
                }
            }
        }
        public              double          ValueDouble
        {
            get {
                try {
                    return _options.ParseDouble(_value);
                }
                catch(Exception) {
                    throw new InvalidOperationException("Cell("+_rowIndex+","+_colIndex+") is not a number.");
                }
            }
        }
        public              DateTime        ValueDateTime
        {
            get {
                try {
                    return _options.ParseDateTime(_value);
                }
                catch(Exception) {
                    throw new InvalidOperationException("Cell("+_rowIndex+","+_colIndex+") is not a DateTime.");
                }
            }
        }

        public                              CsvCell(int colIndex, int rowIndex, string Value, CsvOptions Options)
        {
            _rowIndex = colIndex;
            _colIndex = rowIndex;
            _value    = Value;
            _options  = Options;
        }

        public  override    string          ToString()
        {
            return "\"" + _value + "\"";
        }
    }
}
