namespace Base64EncodeDecode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //For example 01.mp4 in same path of execution file of project
            Console.WriteLine(ConvertToBase64("01.mp4"));
            ConvertFromBase64("01.base64");
            Console.ReadLine();
        }

        static string ConvertToBase64(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);

            // Encode the file contents to Base64
            string base64String = Convert.ToBase64String(fileBytes);

            // Write the Base64 data to a new file
            string base64FilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + ".base64");
            File.WriteAllText(base64FilePath, base64String);

            return base64FilePath;
        }

        static void ConvertFromBase64(string filePath)
        {
            string base64String = File.ReadAllText(filePath);

            // Decode the Base64 data back to the original file format
            byte[] decodedBytes = Convert.FromBase64String(base64String);

            // Write the decoded data to a new file
            string decodedFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_decoded" + Path.GetExtension(filePath));
            File.WriteAllBytes(decodedFilePath, decodedBytes);
        }
    }
}