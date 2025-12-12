namespace SharpParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 1)
            {
                Console.WriteLine("Please provide a path (enclosed in quotes if it contains whitespace");
                return;
            }

            string filePath = args[0];
            PE PEFile = new PE(Utility.ReadFileContents(filePath));
            ushort magicBytes = PEFile.DOSHeader.MagicNumber;
            if (magicBytes == Constants.DOSSignature) Console.WriteLine($"Magic Bytes: 0x{magicBytes:X}");
            Console.Write($"Machine Type: {(Constants.MachineTypes)PEFile.COFFHeader.Machine}");

        }

    }
}