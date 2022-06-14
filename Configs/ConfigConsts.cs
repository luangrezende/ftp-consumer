namespace Ftp.Consumer.Configs
{
    public class ConfigConsts
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FileName { get; set; }

        public string FileNameCsv { get; set; }

        public string FtpServer { get; set; }

        public string FileTempFolder { get; set; }

        public string FileCsvPath { get; set; }

        public string ExtractPath { get; set; }

        public ConfigConsts()
        {
            UserName = "cs_sigmapharma";
            Password = "etz832";
            FileName = "112_Visitacao.zip";
            FileNameCsv = "112_Visitacao.csv";
            FtpServer = $"ftp://ftp.close-upinternational.com.br/{FileName}";
            FileTempFolder = @$".\temp\{FileName}";
            ExtractPath = @".\temp\extract";
            FileCsvPath = $@"{ExtractPath}\{FileNameCsv}";
        }
    }
}
