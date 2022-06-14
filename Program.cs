using Ftp.Consumer;

try
{
    var consumer = new Consumer();

    await consumer.GetFileFromFtpServer();
    await consumer.UnzipFileFromTemFolder();

    var jsonTest = await consumer.ReadCsvAndConvertToJson();

    Console.WriteLine($"RESULT: {jsonTest}");
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
    throw;
}