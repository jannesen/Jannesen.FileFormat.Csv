using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Jannesen.FileFormat.Csv
{
    public sealed class CsvRow
    {
        private readonly    CsvCell[]   _cells;

        public              int         Count
        {
            get {
                return _cells.Length;
            }
        }

        public              CsvCell     this[int Index]
        {
            get {
                return _cells[Index];
            }
        }

        public                          CsvRow(CsvCell[] cells)
        {
            _cells = cells;
        }

        public  override    string      ToString()
        {
            var r = "";

            for (var i = 0 ; i < _cells.Length ; ++i) {
                if (i>0)
                    r += ",";

                r += _cells[i].ToString();
            }

            return r;
        }
    }

    public class CsvRows: List<CsvRow>
    {
        public  new         CsvRow      this[int rowIndex]
        {
            get {
                if (rowIndex < 0 || rowIndex >= base.Count)
                    throw new ArgumentOutOfRangeException(nameof(rowIndex), rowIndex.ToString(CultureInfo.InvariantCulture));

                return base[rowIndex];
            }
        }
    }
}
