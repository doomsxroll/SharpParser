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
            OptionalHeaderStandardFields StandardFields = ParseOptionalHeaderStandardFields(inFile, offset);
            OptionalHeaderWindowsSpecificFields WindowsSpecificFields;
            if (Magic == Constants.PE32)
                WindowsSpecificFields = ParseOptionalHeaderWindowsSpecificPE32(inFile, offset);
            else if (Magic == Constants.PE32Plus)
                WindowsSpecificFields = ParseOptionalHeaderWindowsSpecificPE32Plus(inFile, offset);
            else
                throw new InvalidDataException($"Unknown PE magic number (probably a ROM file): 0x{Magic:X}");

            return new OptionalHeader(
                Magic,
                StandardFields,
                WindowsSpecificFields
                );
        }
        internal static OptionalHeaderStandardFields ParseOptionalHeaderStandardFields(byte[] inFile, uint offset)
        {
            byte MajorLinkerVersion = inFile[(int)offset + 0x2];
            byte MinorLinkerVersion = inFile[(int)offset + 0x3];
            uint SizeOfCode = BitConverter.ToUInt32(inFile, (int)offset + 0x4);
            uint SizeOfInitializedData = BitConverter.ToUInt32(inFile, (int)offset + 0x8);
            uint SizeOfUninitializedData = BitConverter.ToUInt32(inFile, (int)offset + 0xC);
            uint AddressOfEntryPoint = BitConverter.ToUInt32(inFile, (int)offset + 0x10);
            uint BaseOfCode = BitConverter.ToUInt32(inFile, (int)offset + 0x14);

            return new OptionalHeaderStandardFields(
                MajorLinkerVersion,
                MinorLinkerVersion,
                SizeOfCode,
                SizeOfInitializedData,
                SizeOfUninitializedData,
                AddressOfEntryPoint,
                BaseOfCode
                );
        }
        internal static OptionalHeaderWindowsSpecificFields ParseOptionalHeaderWindowsSpecificPE32(byte[] inFile, uint offset) 
        {
            uint BaseOfData = BitConverter.ToUInt32(inFile, (int)offset + 0x18);
            uint ImageBase = BitConverter.ToUInt32(inFile, (int)offset + 0x1C);
            uint SectionAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x20);
            uint FileAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x24);
            ushort MajorOperatingSystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x28);
            ushort MinorOperatingSystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2A);
            ushort MajorImageVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2C);
            ushort MinorImageVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2E);
            ushort MajorSubsystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x30);
            ushort MinorSubsystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x32);
            uint Win32VersionValue = BitConverter.ToUInt32(inFile, (int)offset + 0x34);
            uint SizeOfImage = BitConverter.ToUInt32(inFile, (int)offset + 0x38);
            uint SizeOfHeaders = BitConverter.ToUInt32(inFile, (int)offset + 0x3C);
            uint CheckSum = BitConverter.ToUInt32(inFile, (int)offset + 0x40);
            ushort Subsystem = BitConverter.ToUInt16(inFile, (int)offset + 0x44);
            ushort DllCharacteristics = BitConverter.ToUInt16(inFile, (int)offset + 0x46);
            uint SizeOfStackReserve = BitConverter.ToUInt32(inFile, (int)offset + 0x48);
            uint SizeOfStackCommit = BitConverter.ToUInt32(inFile, (int)offset + 0x4C);
            uint SizeOfHeapReserve = BitConverter.ToUInt32(inFile, (int)offset + 0x50);
            uint SizeOfHeapCommit = BitConverter.ToUInt32(inFile, (int)offset + 0x54);
            uint LoaderFlags = BitConverter.ToUInt32(inFile, (int)offset + 0x58);
            uint NumberOfRvaAndSizes = BitConverter.ToUInt32(inFile, (int)offset + 0x5C);

            return new OptionalHeaderWindowsSpecificFields(
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
        internal static OptionalHeaderWindowsSpecificFields ParseOptionalHeaderWindowsSpecificPE32Plus(byte[] inFile, uint offset)
        {
            uint ImageBase = BitConverter.ToUInt32(inFile, (int)offset + 0x18);
            uint SectionAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x20);
            uint FileAlignment = BitConverter.ToUInt32(inFile, (int)offset + 0x24);
            ushort MajorOperatingSystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x28);
            ushort MinorOperatingSystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2A);
            ushort MajorImageVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2C);
            ushort MinorImageVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x2E);
            ushort MajorSubsystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x30);
            ushort MinorSubsystemVersion = BitConverter.ToUInt16(inFile, (int)offset + 0x32);
            uint Win32VersionValue = BitConverter.ToUInt32(inFile, (int)offset + 0x34);
            uint SizeOfImage = BitConverter.ToUInt32(inFile, (int)offset + 0x38);
            uint SizeOfHeaders = BitConverter.ToUInt32(inFile, (int)offset + 0x3C);
            uint CheckSum = BitConverter.ToUInt32(inFile, (int)offset + 0x40);
            ushort Subsystem = BitConverter.ToUInt16(inFile, (int)offset + 0x44);
            ushort DllCharacteristics = BitConverter.ToUInt16(inFile, (int)offset + 0x46);
            ulong SizeOfStackReserve = BitConverter.ToUInt64(inFile, (int)offset + 0x48);
            ulong SizeOfStackCommit = BitConverter.ToUInt64(inFile, (int)offset + 0x50);
            ulong SizeOfHeapReserve = BitConverter.ToUInt64(inFile, (int)offset + 0x58);
            ulong SizeOfHeapCommit = BitConverter.ToUInt64(inFile, (int)offset + 0x60);
            uint LoaderFlags = BitConverter.ToUInt32(inFile, (int)offset + 0x68);
            uint NumberOfRvaAndSizes = BitConverter.ToUInt32(inFile, (int)offset + 0x6C);
            // IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES];

            return new OptionalHeaderWindowsSpecificFields(
                null, // no BaseOfData in PE32+
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
