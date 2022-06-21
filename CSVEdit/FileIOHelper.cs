using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVEdit
{
    internal class FileIOHelper
    {
        public static List<string[]> ReadCSV(string fileName, EncodingInfo encodingInfo, string delimiter, bool limit)
        {
            var content = new List<string[]>();
            
            using(var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using(var parser = new TextFieldParser(fileStream, encodingInfo.GetEncoding()))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(delimiter);

                    while (!parser.EndOfData)
                    {
                        content.Add(parser.ReadFields());

                        if (limit && content.Count > 11) break;
                    }
                }
            }

            return content;
        }

        public static FileInfo WriteCSV(string originalFilePath, List<string> headers, List<List<string>> content, EncodingInfo encodingInfo, string delimiter)
        {
            var modifiedFile = GetModifiedFileName(originalFilePath);

            var fileMode = File.Exists(modifiedFile.FullName) ? FileMode.Truncate : FileMode.Create;

            using (var fileStream = new FileStream(modifiedFile.FullName, fileMode, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream, encodingInfo.GetEncoding()))
                {
                    streamWriter.Write(CreateLine(headers, delimiter));
                    foreach (var line in content)
                    {
                        streamWriter.WriteLine();
                        streamWriter.Write(CreateLine(line, delimiter));
                    }
                }
            }

            return modifiedFile;
        }

        private static FileInfo GetModifiedFileName(string originalFilePath)
        {
            var orignalFile = new FileInfo(originalFilePath);

            return new FileInfo(
                Path.Combine(
                    orignalFile.Directory.FullName,
                    $"{orignalFile.Name}_bearbeitet{orignalFile.Extension}"
                )
            );
        }

        private static string CreateLine(List<string> columns, string delimiter)
        {
            var stringBuilder = new StringBuilder();

            foreach(var column in columns)
            {
                if (stringBuilder.Length > 0) stringBuilder.Append(delimiter);

                var internalColum = column;
                if (internalColum.Contains("\"")) internalColum = internalColum.Replace("\"", "\"\"");
                if (internalColum.Contains(delimiter)) internalColum = "\"" + internalColum + "\"";

                stringBuilder.Append(internalColum);
            }

            return stringBuilder.ToString();
        }
    }
}
