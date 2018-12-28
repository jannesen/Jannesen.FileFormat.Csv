using System;
using System.Collections.Generic;
using System.Text;

namespace Jannesen.FileFormat.Csv
{
    public class CsvRow
    {
        private             CsvCell[]   _cells;


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
            string r = "";

            for (int i = 0 ; i < _cells.Length ; ++i) {
                if (i>0)
                    r += ",";

                r += _cells[i].ToString();
            }

            return r;
        }
    }

    public class CsvRows: List<CsvRow>
    {
        public  new         CsvRow      this[int RowIndex]
        {
            get {
                if (RowIndex < 0 || RowIndex >= base.Count)
                    throw new ArgumentException("row '+(Index.ToString())+' out of range.");

                return base[RowIndex];
            }
        }
    }
}
