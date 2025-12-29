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
        internal static void PrintToConsole(byte[] inArray, uint startAddress = 0)
        {

            int size = inArray.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                if (i % 16 == 0) Console.Write($"{i+startAddress:X8}: ");

                Console.Write($"{inArray[i]:X2} ");

                if (inArray[i] >= 32 && inArray[i] <= 126)
                {
                    sb.Append((char)inArray[i]);
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
