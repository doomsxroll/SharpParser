namespace SharpParser
{
    internal class PE
    {
        // File Headers
        internal DOSHeader DOSHeader { get; }
        internal COFFHeader COFFHeader { get; }
        internal OptionalHeaderStandardFields OptionalHeaderStandardFields { get; }
        internal OptionalHeaderWindowsSpecificFieldsPE32? OptionalHeaderWindowsSpecificFieldsPE32 { get; }
        internal OptionalHeaderWindowsSpecificFieldsPE32Plus? OptionalHeaderWindowsSpecificFieldsPE32Plus { get; }
        internal PE(byte[] inFile)
        {
            this.DOSHeader = Parsers.ParseDOSHeader(inFile);

            uint CoffHeaderStart = DOSHeader.SignatureLocation + 0x4;
            this.COFFHeader = Parsers.ParseCOFFHeader(inFile, CoffHeaderStart);

            uint OptionalHeaderStart = CoffHeaderStart + 0x14;
            this.OptionalHeaderStandardFields = Parsers.ParseOptionalHeaderStandardFields(inFile, OptionalHeaderStart);

            if (this.OptionalHeaderStandardFields.Magic == Constants.PE32) {
                this.OptionalHeaderWindowsSpecificFieldsPE32 = Parsers.ParseOptionalHeaderWindowsSpecificPE32(inFile, OptionalHeaderStart);
            } else if (this.OptionalHeaderStandardFields.Magic == Constants.PE32Plus)
            {
                this.OptionalHeaderWindowsSpecificFieldsPE32Plus = Parsers.ParseOptionalHeaderWindowsSpecificPE32Plus(inFile, OptionalHeaderStart);
            } else
            {
                throw new Exception($"Not a PE: {this.OptionalHeaderStandardFields.Magic}");
            }
        }
    }
}
