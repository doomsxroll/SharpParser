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
            TestDOSHeader[0x66] = 0x45;
            TestDOSHeader[0x67] = 0x50;
            DOSHeader header = Parsers.ParseDOSHeader(TestDOSHeader);
            Assert.AreEqual(Constants.DOSSignature, header.MagicNumber);
            Assert.AreEqual(0x64u, header.SignatureLocation);
            Assert.AreEqual(Constants.PESignature, header.Signature);
        }

        [TestMethod]
        public void COFFParser()
        {
            byte[] TestCOFFHeader = new byte[0x14];
            TestCOFFHeader[0x0] = 0x86;
            TestCOFFHeader[0x1] = 0x64;
            TestCOFFHeader[0x2] = 0x5;
            TestCOFFHeader[0x4] = 0x69;
            TestCOFFHeader[0x5] = 0x31;
            TestCOFFHeader[0x6] = 0x58;
            TestCOFFHeader[0x7] = 0x9B;
            TestCOFFHeader[0x8] = 0x0;
            TestCOFFHeader[0xC] = 0x0;
            TestCOFFHeader[0x10] = 0xF0;
            TestCOFFHeader[0x12] = 0x22;
            COFFHeader header = Parsers.ParseCOFFHeader(TestCOFFHeader, 0x0);
            Assert.AreEqual((int)Constants.MachineTypes.AMD64, header.Machine);
            Assert.AreEqual(0x5, header.NumberOfSections);
            Assert.AreEqual((int)Constants.MachineTypes.AMD64, header.Machine);
            Assert.AreEqual((int)Constants.MachineTypes.AMD64, header.Machine);
            Assert.AreEqual((int)Constants.MachineTypes.AMD64, header.Machine);
            //ushort NumberOfSections,
            //uint TimeDateStamp,
            //uint PointerToSymbolTable,
            //uint NumberOfSymbols,
            //ushort SizeOfOptionalHeader,
            //ushort Characteristics
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
