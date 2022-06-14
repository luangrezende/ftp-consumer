using CsvHelper;
using CsvHelper.Configuration;
using Ftp.Consumer.Configs;
using Ftp.Consumer.Mappings;
using Ftp.Consumer.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Ftp.Consumer
{
    public class Consumer
    {
        public async Task GetFileFromFtpServer()
        {
            //CONFIG
            var config = new ConfigConsts();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(config.FtpServer);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new NetworkCredential(config.UserName, config.Password);

            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (Stream rs = response.GetResponseStream())
            {
                using FileStream ws = new(config.FileTempFolder, FileMode.Create);
                byte[] buffer = new byte[2048];
                int bytesRead = rs.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    ws.Write(buffer, 0, bytesRead);
                    bytesRead = rs.Read(buffer, 0, buffer.Length);
                }
            }

            Console.WriteLine($"Download Complete, status {response.StatusDescription}");
        }

        public async Task UnzipFileFromTemFolder()
        {
            //CONFIG
            var config = new ConfigConsts();

            if (!Directory.Exists(config.ExtractPath))
                Directory.CreateDirectory(config.ExtractPath);

            if (File.Exists(config.FileCsvPath))
                File.Delete(config.FileCsvPath);

            ZipFile.ExtractToDirectory(config.FileTempFolder, config.ExtractPath);
        }

        public async Task<string> ReadCsvAndConvertToJson()
        {
            //CONFIG
            var config = new ConfigConsts();

            List<VisitacaoModel> VisitacaoModelList = new();
            var file = File.OpenRead(config.FileCsvPath);

            using StreamReader reader = new(file, Encoding.UTF8, true);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                IgnoreBlankLines = true,
                HasHeaderRecord = true,
            };

            using (var csv = new CsvReader(reader, csvConfig))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    csv.Context.RegisterClassMap<VisitacaoMapping>();
                    var result = csv.GetRecord<VisitacaoModel>();
                    VisitacaoModelList.Add(result);
                }
            }

            var jsonResult = JsonConvert.SerializeObject(VisitacaoModelList, Formatting.Indented);

            return jsonResult;
        }
    }
}
