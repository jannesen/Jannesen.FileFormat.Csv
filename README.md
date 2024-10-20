# Jannesen.FileFormat.Csv

Basic CSV reader.

## Classes

| Name       | Description                                                                               |
|:-----------|:------------------------------------------------------------------------------------------|
| CsvReader  | The mail reader. Method ReadRow read the next row return null on EOF                      |
| CsvOptions | How to read then CSV file                                                                 |
| CsvCell    | Then properties ValueString, ValueInt, ValueDouble, ValueDateTime represent the valueof the cell |
| CsvRow     | Collection or Cells                                                                       |
