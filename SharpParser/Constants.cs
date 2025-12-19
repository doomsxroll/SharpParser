namespace SharpParser
{
    internal static class Constants
    {
        internal const uint DOSSignature = 0x5A4D;
        internal const int PESignatureOffset = 0x3C;
        // PE signature is "PE00" but x64 intel arch is little endian, so is stored as 00EP
        internal const uint PESignature = 0x00004550;
        internal enum MachineTypes
        {
            UNKNOWN = 0x0,
            ALPHA = 0x184,
            ALPHA64 = 0x284,
            AM33 = 0x1d3,
            AMD64 = 0x8664,
            ARM = 0x1c0,
            ARM64 = 0xaa64,
            ARM64EC = 0xA641,
            ARM64X = 0xA64E,
            ARMNT = 0x1c4,
            AXP64 = 0x284,
            EBC = 0xebc,
            I386 = 0x14c,
            IA64 = 0x200,
            LOONGARCH32 = 0x6232,
            LOONGARCH64 = 0x6264,
            M32R = 0x9041,
            MIPS16 = 0x266,
            MIPSFPU = 0x366,
            MIPSFPU16 = 0x466,
            POWERPC = 0x1f0,
            POWERPCFP = 0x1f1,
            R3000BE = 0x160,
            R3000 = 0x162,
            R4000 = 0x166,
            R10000 = 0x168,
            RISCV32 = 0x5032,
            RISCV64 = 0x5064,
            RISCV128 = 0x5128,
            SH3 = 0x1a2,
            SH3DSP = 0x1a3,
            SH4 = 0x1a6,
            SH5 = 0x1a8,
            THUMB = 0x1c2,
            WCEMIPSV2 = 0x169
        }

        internal enum Characteristics {
            RELOCS_STRIPPED = 0x0001,
            EXECUTABLE_IMAGE = 0x0002,
            LARGE_ADDRESS_AWARE = 0x0020,
            BYTES_REVERSED_LO = 0x0080,
            X32BIT_MACHINE = 0x0100,
            DEBUG_STRIPPED = 0x0200,
            REMOVABLE_RUN_FROM_SWAP = 0x0400,
            NET_RUN_FROM_SWAP = 0x0800,
            SYSTEM = 0x1000,
            DLL = 0x2000,
            UP_SYSTEM_ONLY = 0x4000,
            BYTES_REVERSED_HI = 0x8000
        }

        internal const uint PE32 = 0x10b;
        internal const uint PE32Plus = 0x20b;
    }
}
