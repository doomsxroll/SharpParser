namespace SharpParser
{
    internal record struct DOSHeader
    (
        ushort MagicNumber,
        uint SignatureLocation, // Note: its fine if this can be 32 bits wide
        uint Signature
    );

    internal record struct COFFHeader
    (
        ushort Machine,
        ushort NumberOfSections,
        uint TimeDateStamp,
        uint PointerToSymbolTable,
        uint NumberOfSymbols,
        ushort SizeOfOptionalHeader,
        ushort Characteristics
    );
    internal record struct OptionalHeaderStandardFields
    (
        ushort Magic,
        byte MajorLinkerVersion,
        byte MinorLinkerVersion,
        uint SizeOfCode,
        uint SizeOfInitializedData,
        uint SizeOfUninitializedData,
        uint AddressOfEntryPoint,
        uint BaseOfCode
    );
    internal record struct OptionalHeaderWindowsSpecificFieldsPE32
    (
        uint BaseOfData,
        uint ImageBase,
        uint SectionAlignment,
        uint FileAlignment,
        ushort MajorOperatingSystemVersion,
        ushort MinorOperatingSystemVersion,
        ushort MajorImageVersion,
        ushort MinorImageVersion,
        ushort MajorSubsystemVersion,
        ushort MinorSubsystemVersion,
        uint Win32VersionValue,
        uint SizeOfImage,
        uint SizeOfHeaders,
        uint CheckSum,
        ushort Subsystem,
        ushort DllCharacteristics,
        uint SizeOfStackReserve,
        uint SizeOfStackCommit,
        uint SizeOfHeapReserve,
        uint SizeOfHeapCommit,
        uint LoaderFlags,
        uint NumberOfRvaAndSizes
    );
    internal record struct OptionalHeaderWindowsSpecificFieldsPE32Plus
    (
        ulong ImageBase,
        uint SectionAlignment,
        uint FileAlignment,
        ushort MajorOperatingSystemVersion,
        ushort MinorOperatingSystemVersion,
        ushort MajorImageVersion,
        ushort MinorImageVersion,
        ushort MajorSubsystemVersion,
        ushort MinorSubsystemVersion,
        uint Win32VersionValue,
        uint SizeOfImage,
        uint SizeOfHeaders,
        uint CheckSum,
        ushort Subsystem,
        ushort DllCharacteristics,
        ulong SizeOfStackReserve,
        ulong SizeOfStackCommit,
        ulong SizeOfHeapReserve,
        ulong SizeOfHeapCommit,
        ulong LoaderFlags,
        ulong NumberOfRvaAndSizes
    );
}
