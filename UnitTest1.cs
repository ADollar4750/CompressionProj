using System.Globalization;
using System.Linq;

namespace CompressionProj;

public interface IBitStringCompressor
    {
        string Compress(string original);
        string Decompress(string compressed);
    }   
    public string 
    public string Compress(string original)
    {
        string compressed;
        char[] stringBroken = ;
        
        for(int i = 0; i < stringBroken.Length; i++)
        {

            if()
            {

            }
        }
        return compressed;
    }
    public string Decompress(string compressed)
    {
        text_Byte = compressed.Compress();//waiting for compress fuction
        char[13] output;

        foreach(char i in text_Byte)
        {
            output.Append(i);
        }
        return output;
  
    }

    [SetUp]
    public void Setup()
    {
    }

    //Compression Test
    [Test]
    public void CompressionTest()
    {
        string umcompressed;
        string compressed = IBitStringCompressor.Compress(uncompressed);
        Assert.AreEqual("13", compressed);
    }
    //Decompression Test
    [Test]
    public void DecompressionTest()
    {
        string uncompressed;
        string compressed = IBitStringCompressor.Compress(uncompressed);

        string decompressed = IBitStringCompressor.Decompress(compressed);
        Assert.AreEqual(uncompressed, decompressed);
    }