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
   
}


public string Decompress(string compressed)
        {
            StringBuilder decompressed = new StringBuilder();

            int i = 0;
            while (i < compressed.Length)
            {
                char current = compressed[i];

                if (IsMarker(current))
                {
                    // Assume next few characters define offset and length
                    // For simplicity, let's say offset and length are each one digit (highly simplified)
                    int offset = Int32.Parse(compressed.Substring(i + 1, 1));
                    int length = Int32.Parse(compressed.Substring(i + 2, 1));
                    int startCopyIndex = decompressed.Length - offset;
                    for (int j = 0; j < length; j++)
                    {
                        decompressed.Append(decompressed[startCopyIndex + j]);
                    }
                    i += 3; // Move past marker, offset, and length
                }
                else
                {
                    decompressed.Append(current);
                    i++;
                }
            }

            return decompressed.ToString();
        }

        private bool IsMarker(char c)
        {
            // Determine if a character is a marker for an encoded sequence
            // Placeholder implementation
            return c == 'X'; // Example marker character
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
    public void DecompressionTest()
        {
            EncodeDecode test = new EncodeDecode();
            string compressed = "01X101X201"; 
            string decompressed = test.Decompress(compressed);
            Assert.AreEqual("01010101", decompressed); 
        }
}