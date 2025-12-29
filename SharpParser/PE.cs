namespace SharpParser
{
    internal class PE
    {
        // File Headers
        internal DOSHeader DOSHeader { get; }
        internal byte[] DOSHeaderRaw { get; }
        internal uint COFFHeaderStart { get; }
        internal COFFHeader COFFHeader { get; }
        internal byte[] COFFHeaderRaw { get; }
        internal uint OptionalHeaderStart { get; }
        internal OptionalHeaderStandardFields OptionalHeaderStandardFields { get; }
        internal OptionalHeaderWindowsSpecificFieldsPE32? OptionalHeaderWindowsSpecificFieldsPE32 { get; }
        internal OptionalHeaderWindowsSpecificFieldsPE32Plus? OptionalHeaderWindowsSpecificFieldsPE32Plus { get; }
        internal PE(byte[] inFile)
        {
            this.DOSHeader = Parsers.ParseDOSHeader(inFile);

            COFFHeaderStart = DOSHeader.SignatureLocation + 0x4; // this is also the end of the DOS header so we define it now

            this.DOSHeaderRaw = inFile[0..(int)COFFHeaderStart];

            this.COFFHeader = Parsers.ParseCOFFHeader(inFile, COFFHeaderStart);

            OptionalHeaderStart = COFFHeaderStart + 0x14; // again, this is also the end of the COFF header so we define it now

            this.COFFHeaderRaw = inFile[(int)COFFHeaderStart..(int)OptionalHeaderStart];

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
