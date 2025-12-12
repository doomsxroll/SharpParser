using System.Text;

namespace SharpParser
{
    internal class Utility
    {
        internal static byte[] ReadFileContents(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return fileBytes;
        }
        internal static void PrintToConsole(byte[] PE)
        {

            int size = PE.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                if (i % 16 == 0) Console.Write($"{i:X8}: ");

                Console.Write($"{PE[i]:X2} ");

                if (PE[i] >= 32 && PE[i] <= 126)
                {
                    sb.Append((char)PE[i]);
                }
                else
                {
                    sb.Append('.');
                }

                if ((i + 1) % 16 == 0)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }
            }
        }
    }
}
