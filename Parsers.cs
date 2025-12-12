namespace SharpParser
{
    internal static class Parsers
    {
        internal static DOSHeader ParseDOSHeader(byte[] inFile)
        {
            ushort MagicNumber = BitConverter.ToUInt16(inFile, 0);
            uint SignatureLocation = BitConverter.ToUInt32(inFile, Constants.PESignatureOffset);
            uint Signature = BitConverter.ToUInt32(inFile, (int)SignatureLocation);

            return new DOSHeader(
                MagicNumber,
                SignatureLocation,
                Signature
                );
        }
        internal static COFFHeader ParseCOFFHeader(byte[] inFile, uint offset)
        {
            ushort Machine = BitConverter.ToUInt16(inFile, (int)offset);
            ushort NumberOfSections = BitConverter.ToUInt16(inFile, (int)offset + 0x2);
            uint TimeDateStamp = BitConverter.ToUInt32(inFile, (int)offset + 0x4);
            uint PointerToSymbolTable = BitConverter.ToUInt32(inFile, (int)offset + 0x8);
            uint NumberOfSymbols = BitConverter.ToUInt32(inFile, (int)offset + 0xC);
            ushort SizeOfOptionalHeader = BitConverter.ToUInt16(inFile, (int)offset + 0x10);
            ushort Characteristics = BitConverter.ToUInt16(inFile, (int)offset + 0x12);

            return new COFFHeader(
                Machine,
                NumberOfSections,
                TimeDateStamp,
                PointerToSymbolTable,
                NumberOfSymbols,
                SizeOfOptionalHeader,
                Characteristics
                );
        }
        internal static OptionalHeader ParseOptionalHeader(byte[] inFile, uint offset)
        {
            ushort Magic = BitConverter.ToUInt16(inFile, (int)offset);
            byte MajorLinkerVersion = inFile[(int)offset + 0x2];
            byte MinorLinkerVersion = inFile[(int)offset + 0x3];
            uint SizeOfCode = BitConverter.ToUInt32(inFile, (int)offset + 0x4);
            uint SizeOfInitializedData = BitConverter.ToUInt32(inFile, (int)offset + 0x8);
            uint SizeOfUninitializedData = BitConverter.ToUInt32(inFile, (int)offset + 0xC);
            uint AddressOfEntryPoint = BitConverter.ToUInt32(inFile, (int)offset + 0x10);
            uint BaseOfCode = BitConverter.ToUInt32(inFile, (int)offset + 0x14);

            if (Magic == 0x10B)
            { // PE32
                uint BaseOfData = BitConverter.ToUInt32(inFile, (int)offset + 0x18);
                uint ImageBase = BitConverter.ToUInt32(inFile, (int)offset + 0x1C);
                uint SectionAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x20);
                uint FileAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x24);
                ushort MajorOperatingSystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x28);
                ushort MinorOperatingSystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2A);
                ushort MajorImageVersion;
                ushort MinorImageVersion;
                ushort MajorSubsystemVersion;
                ushort MinorSubsystemVersion;
                uint Win32VersionValue;
                uint SizeOfImage;
                uint SizeOfHeaders;
                uint CheckSum;
                ushort Subsystem;
                ushort DllCharacteristics;
                uint SizeOfStackReserve;
                uint SizeOfStackCommit;
                uint SizeOfHeapReserve;
                uint SizeOfHeapCommit;
                uint LoaderFlags;
                uint NumberOfRvaAndSizes;
            }
            else if (Magic == 0x20B)
            { // PE32+
                uint BaseOfData = 0;
                uint ImageBase = BitConverter.ToUInt32(inFile, (int)offset + 0x1C);
                uint SectionAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x20);
                uint FileAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x24);
                ushort MajorOperatingSystemVersion;
                ushort MinorOperatingSystemVersion;
                ushort MajorImageVersion;
                ushort MinorImageVersion;
                ushort MajorSubsystemVersion;
                ushort MinorSubsystemVersion;
                uint Win32VersionValue;
                uint SizeOfImage;
                uint SizeOfHeaders;
                uint CheckSum;
                ushort Subsystem;
                ushort DllCharacteristics;
                uint SizeOfStackReserve;
                uint SizeOfStackCommit;
                uint SizeOfHeapReserve;
                uint SizeOfHeapCommit;
                uint LoaderFlags;
                uint NumberOfRvaAndSizes;
            }
            // IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES];

                return new OptionalHeader(
                    Magic,
                    MajorLinkerVersion,
                    MinorLinkerVersion,
                    SizeOfCode,
                    SizeOfInitializedData,
                    SizeOfUninitializedData,
                    AddressOfEntryPoint,
                    BaseOfCode,
                    BaseOfData,
                    ImageBase,
                    SectionAlignment,
                    FileAlignment,
                    MajorOperatingSystemVersion,
                    MinorOperatingSystemVersion,
                    MajorImageVersion,
                    MinorImageVersion,
                    MajorSubsystemVersion,
                    MinorSubsystemVersion,
                    Win32VersionValue,
                    SizeOfImage,
                    SizeOfHeaders,
                    CheckSum,
                    Subsystem,
                    DllCharacteristics,
                    SizeOfStackReserve,
                    SizeOfStackCommit,
                    SizeOfHeapReserve,
                    SizeOfHeapCommit,
                    LoaderFlags,
                    NumberOfRvaAndSizes
                // IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES];
                );
        }
    }
}
