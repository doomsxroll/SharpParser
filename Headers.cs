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
        byte MajorLinkerVersion,
        byte MinorLinkerVersion,
        uint SizeOfCode,
        uint SizeOfInitializedData,
        uint SizeOfUninitializedData,
        uint AddressOfEntryPoint,
        uint BaseOfCode
    );
    internal record struct OptionalHeaderWindowsSpecificFields
    (
        uint? BaseOfData,
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
        dynamic SizeOfStackReserve,
        dynamic SizeOfStackCommit,
        dynamic SizeOfHeapReserve,
        dynamic SizeOfHeapCommit,
        dynamic LoaderFlags,
        dynamic NumberOfRvaAndSizes
    );
    internal record struct OptionalHeader
    (
        ushort Magic,
        OptionalHeaderStandardFields StandardFields,
        OptionalHeaderWindowsSpecificFields WindowsSpecificFields
        //IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES];
    );
}
