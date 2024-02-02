using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CompressionProj;

public interface IBitStringCompressor
{
    string Compress(string original);
    string Decompress(string compressed);
}
public class EncodeDecode : IBitStringCompressor
{
    public string Compress(string original)
    {
        string compressed = "";
        char[] stringBroken = original.ToCharArray();

        for (int i = 0; i < original.Length; i++)
        {
            if (i+1<original.Length && stringBroken[i] != stringBroken[i+1])
            {
                compressed+= stringBroken[i];
                continue;
            }
            else if(i+1<original.Length && stringBroken[i] == stringBroken[i+1])
            {
                compressed+= stringBroken[i];
                i++;
            }
            else
            {
                compressed+= stringBroken[i];
            }
        }
        return compressed;
    }
    public string Decompress(string compressed)
    {
        // text_Byte = compressed.Compress();//waiting for compress fuction
        // char[13] output;

        // foreach (char i in text_Byte)
        // {
        //     output.Append(i);
        // }
        // return output;
        return "";
    }
}
public class Test
{
    [SetUp]
    public void Setup()
    {
    }

    //Compression Test
    [Test]
    public void CompressionTest()
    {
        EncodeDecode test = new EncodeDecode();
        string uncompressed = "01000011101011";
        string result = test.Compress(uncompressed);
        Assert.AreEqual("0100110101", result);
    }
    // Decompression Test
    //Syntax error
    // [Test]
    // public void DecompressionTest()
    // {
    //     string uncompressed;
    //     string compressed = IBitStringCompressor.Compress(uncompressed);

    //     string decompressed = IBitStringCompressor.Decompress(compressed);
    //     Assert.AreEqual(uncompressed, decompressed);
    // }
}