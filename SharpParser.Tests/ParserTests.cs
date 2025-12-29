using SharpParser;

namespace SharpParserTests
{
    [TestClass]
    public sealed class ParserTests
    {
        [TestMethod]
        public void DOSParser()
        {
            byte[] TestDOSHeader = new byte[0x68];
            TestDOSHeader[0x0] = 0x4D;
            TestDOSHeader[0x1] = 0x5A;
            TestDOSHeader[0x3c] = 0x64;
            TestDOSHeader[0x64] = 0x50;
            TestDOSHeader[0x65] = 0x45;
            DOSHeader header = Parsers.ParseDOSHeader(TestDOSHeader);
            Assert.AreEqual(Constants.DOSSignature, header.MagicNumber);
            Assert.AreEqual(0x64u, header.SignatureLocation);
            Assert.AreEqual(Constants.PESignature, header.Signature);
        }

        [TestMethod]
        public void COFFParser()
        {
            byte[] TestCOFFHeader = new byte[0x14];
            TestCOFFHeader[0x0] = 0x64;
            TestCOFFHeader[0x1] = 0x86;
            TestCOFFHeader[0x2] = 0x5;
            TestCOFFHeader[0x4] = 0x9B;
            TestCOFFHeader[0x5] = 0x58;
            TestCOFFHeader[0x6] = 0x31;
            TestCOFFHeader[0x7] = 0x69;
            TestCOFFHeader[0x8] = 0x0;
            TestCOFFHeader[0xC] = 0x0;
            TestCOFFHeader[0x10] = 0xF0;
            TestCOFFHeader[0x12] = 0x22;
            COFFHeader header = Parsers.ParseCOFFHeader(TestCOFFHeader, 0x0);
            Assert.AreEqual((uint)Constants.MachineTypes.AMD64, header.Machine);
            Assert.AreEqual(0x5, header.NumberOfSections);
            Assert.AreEqual(0x6931589Bu, header.TimeDateStamp);
            Assert.AreEqual(0x0u, header.PointerToSymbolTable);
            Assert.AreEqual(0x0u, header.NumberOfSymbols);
            Assert.AreEqual(0xF0u, header.SizeOfOptionalHeader);
            Assert.AreEqual(0x22u, header.Characteristics);
        }

        [TestMethod]
        public void OptionalHeaderStandardFieldsParser()
        {

        }
        [TestMethod]
        public void OptionalHeaderWindowsSpecificPE32Parser()
        {

        }
        [TestMethod]
        public void OptionalHeaderWindowsSpecificPE32PlusParser()
        {

        }
        
    }
}
