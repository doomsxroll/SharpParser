namespace SharpParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 1)
            {
                Console.WriteLine("Please provide a path (enclosed in quotes if it contains whitespace)");
                return;
            }

            string filePath = args[0];
            PE PEFile = new PE(Utility.ReadFileContents(filePath));

            Console.WriteLine("=== DOS Header ===");
            Utility.PrintToConsole(PEFile.DOSHeaderRaw);
            Console.WriteLine($"\n\nMagic Number: {PEFile.DOSHeader.MagicNumber} (0x{PEFile.DOSHeader.MagicNumber:X})");
            Console.WriteLine($"Signature Location: {PEFile.DOSHeader.SignatureLocation} (0x{PEFile.DOSHeader.SignatureLocation:X})");

            Console.WriteLine("\n\n=== COFF Header ===");
            Utility.PrintToConsole(PEFile.COFFHeaderRaw, PEFile.COFFHeaderStart);
            Console.WriteLine($"\n\nMachine: {(Constants.MachineTypes)PEFile.COFFHeader.Machine} (0x{PEFile.COFFHeader.Machine:X})");
            Console.WriteLine($"NumberOfSections: {PEFile.COFFHeader.NumberOfSections} (0x{PEFile.COFFHeader.NumberOfSections:X})");
            DateTimeOffset timeStamp = DateTimeOffset.FromUnixTimeSeconds((long)PEFile.COFFHeader.TimeDateStamp);
            Console.WriteLine($"TimeDateStamp: {timeStamp.ToString()} (0x{PEFile.COFFHeader.TimeDateStamp:X})");
            Console.WriteLine($"PointerToSymbolTable: {PEFile.COFFHeader.PointerToSymbolTable} (0x{PEFile.COFFHeader.PointerToSymbolTable:X})");
            Console.WriteLine($"NumberOfSymbols: {PEFile.COFFHeader.NumberOfSymbols} (0x{PEFile.COFFHeader.NumberOfSymbols:X})");
            Console.WriteLine($"SizeOfOptionalHeader: {PEFile.COFFHeader.SizeOfOptionalHeader} (0x{PEFile.COFFHeader.SizeOfOptionalHeader:X})");
            Console.WriteLine($"Characteristics: {PEFile.COFFHeader.Characteristics} (0x{PEFile.COFFHeader.Characteristics:X})");

            Console.WriteLine();
        }

    }
}