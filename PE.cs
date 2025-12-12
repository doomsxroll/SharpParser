namespace SharpParser
{
    internal class PE
    {
        internal DOSHeader DOSHeader { get; }
        internal COFFHeader COFFHeader { get; }
        internal OptionalHeader OptionalHeader { get; }
        internal PE(byte[] inFile)
        {
            this.DOSHeader = Parsers.ParseDOSHeader(inFile);

            uint CoffHeaderStart = DOSHeader.SignatureLocation + 0x4;
            this.COFFHeader = Parsers.ParseCOFFHeader(inFile, CoffHeaderStart);

            uint OptionalHeaderStart = CoffHeaderStart + 0x14;
            this.OptionalHeader = Parsers.ParseOptionalHeader(inFile, OptionalHeaderStart);


        }
    }
}
