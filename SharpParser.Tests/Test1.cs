using SharpParser;

namespace SharpParserTests
{
    [TestClass]
    public sealed class TestParsers
    {
        [TestMethod]
        public void DOSParser()
        {
            byte[] TestDOSHeader = new byte[200];
            TestDOSHeader[0] = 0x4D;
            TestDOSHeader[1] = 0x5A;
            TestDOSHeader[0x3c] = 0x64;
            TestDOSHeader[0x66] = 0x45;
            TestDOSHeader[0x67] = 0x50;
            DOSHeader header = Parsers.ParseDOSHeader(TestDOSHeader);
            Assert.AreEqual(Constants.DOSSignature, header.MagicNumber);
            Assert.AreEqual(0x64u, header.SignatureLocation);
            Assert.AreEqual(Constants.PESignature, header.Signature);
        }
    }
}
