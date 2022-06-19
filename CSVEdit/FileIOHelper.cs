using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVEdit
{
    internal class FileIOHelper
    {
        public static List<string[]> ReadCSV(string fileName, EncodingInfo encodingInfo, bool limit)
        {
            var content = new List<string[]>();

            using(var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream, encodingInfo.GetEncoding()))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var columns = line.Split(';');
                        content.Add(columns);

                        if (limit && content.Count > 2) break;
                    }
                }
            }

            return content;
        }

        public static FileInfo WriteCSV(string originalFilePath, List<string> headers, List<List<string>> content, EncodingInfo encodingInfo)
        {
            var modifiedFile = GetModifiedFileName(originalFilePath);

            var fileMode = File.Exists(modifiedFile.FullName) ? FileMode.Truncate : FileMode.Create;

            using (var fileStream = new FileStream(modifiedFile.FullName, fileMode, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream, encodingInfo.GetEncoding()))
                {
                    streamWriter.Write(CreateLine(headers));
                    foreach (var line in content)
                    {
                        streamWriter.WriteLine();
                        streamWriter.Write(CreateLine(line));
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

        private static string CreateLine(List<string> columns)
        {
            var stringBuilder = new StringBuilder();

            foreach(var column in columns)
            {
                if (stringBuilder.Length > 0) stringBuilder.Append(";");

                stringBuilder.Append(column);
            }

            return stringBuilder.ToString();
        }
    }
}
