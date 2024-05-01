using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
     public partial class Form1 : Form
     {
          public Form1()
          {
               InitializeComponent();
          }

          UInt32[] K = {
            0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
            0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
            0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
            0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
            0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
            0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
            0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
            0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
        };
          UInt32[] H = new UInt32[8];
          UInt32[] W = new UInt32[64];

          string binaryValues = "";


          int sleeptime=2000;
          public void sd()
          {
               richText.SelectionStart = richText.Text.Length;
               richText.ScrollToCaret();
               Thread.Sleep(sleeptime);
               Application.DoEvents();
          }

          private void btnSimulationCalculation_Click(object sender, EventArgs e)
          {
               var watch = new System.Diagnostics.Stopwatch();
               watch.Start();


               lblState.Text = "Processing...";
               Application.DoEvents();

               sd();;

               richText.Clear();

               step1();
               step2();
               step3();
               step4();

               print("\n********************************** Step 8 – Concatenate Final Hash **********************************\n");
               //print(Convert.ToString(H[0], 16));
               //print(Convert.ToString(H[1], 16));
               //print(Convert.ToString(H[2], 16));
               //print(Convert.ToString(H[3], 16));
               //print(Convert.ToString(H[4], 16));
               //print(Convert.ToString(H[5], 16));
               //print(Convert.ToString(H[6], 16));
               //print(Convert.ToString(H[7], 16));


               string result = "";

               result = pad((Convert.ToString(H[0], 16)), 8);
               result += pad((Convert.ToString(H[1], 16)), 8);
               result += pad((Convert.ToString(H[2], 16)), 8);
               result += pad((Convert.ToString(H[3], 16)), 8);
               result += pad((Convert.ToString(H[4], 16)), 8);
               result += pad((Convert.ToString(H[5], 16)), 8);
               result += pad((Convert.ToString(H[6], 16)), 8);
               result += pad((Convert.ToString(H[7], 16)), 8);

               print(result);


               lblState.Text = "Completed Successfully!!";

               watch.Stop();
               MessageBox.Show("Completed Successfully!!\nResult: \n" + result + "\nExecution Time: " + watch.ElapsedTicks + " Ticks");
               richText.SelectionStart = richText.Text.Length;
               richText.ScrollToCaret();


               print("\nExecution Time: " + watch.ElapsedTicks + " Ticks");

          }
          ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          #region step 1
          private void step1()
          {
               binaryValues = "";
               //Step 1 – Pre - Processing
               string plainText = txtMsg.Text;
               print("Plain Text:\t\t" + plainText + "\nNumber of Chars:\t" + plainText.Length + "\n");

               print("\n********************************** Step 1 – Pre-Processing **********************************");
               // ASCII Values
               byte[] asciiBytes = textToBytes(plainText);

               string collectingBytes = "";
               print("\nASCII Value:\n");
               foreach (byte item in asciiBytes)
               {
                    collectingBytes += item.ToString();
                    print(item.ToString() + "\t");
               }

               //Binary values of the ASCIIs
               binaryValues = bytesAsBinaryString(asciiBytes);
               int originalLengthInBinary = binaryValues.Length;
               print("\n\nBinary Value:\n");

               print(binaryValues, 8, 8);
               //for(int i=0;i< binaryValues.Length; i+=8)
               //{
               //    print(binaryValues.Substring(i,8)+"\t");
               //}

               //Append a single 1:
               binaryValues += "1";
               print("\n\nAppend a Single 1:\n");
               print(binaryValues, 8, 8);

               //for (int i = 0; i < binaryValues.Length; i += 8)
               //{
               //    if(i+8<=binaryValues.Length)
               //        print(binaryValues.Substring(i, 8) + "\t");
               //    else
               //        print(binaryValues.Substring(i, binaryValues.Length-i) + "\t");
               //}


               //Pad with 0’s until data is a multiple of 512
               while ((binaryValues.Length + 64) % 512 != 0)
               {
                    binaryValues = binaryValues + "0";
               }
               print("\n\nPad 0’s to 512 multiple (Len=" + binaryValues.Length + "):\n");
               print(binaryValues, 8, 8);
               //for (int i = 0, j=0; i < binaryValues.Length; i += 8,j++)
               //{
               //    if (j % 8 == 0)
               //        print("\n");
               //    if (i + 8 <= binaryValues.Length)
               //        print(binaryValues.Substring(i, 8) + "\t");
               //    else
               //        print(binaryValues.Substring(i, binaryValues.Length - i) + "\t");
               //}


               //Append 64 bits to the end, where the 64 bits are a big-endian integer representing the length of the original input in binary.
               String originalLengthInBinary_output = Convert.ToString(originalLengthInBinary, 2);
               while (originalLengthInBinary_output.Length < 64)
               {
                    originalLengthInBinary_output = "0" + originalLengthInBinary_output;
               }


               binaryValues += originalLengthInBinary_output;
               print("\n\nAppend 64 bits to the end, where the 64 bits are a big-endian integer representing the length of the original input in binary (Len=" + binaryValues.Length + "):\n");
               print(binaryValues, 8, 8);

               //for (int i = 0, j = 0; i < binaryValues.Length; i += 8, j++)
               //{
               //    if (j % 8 == 0)
               //        print("\n");
               //    if (i + 8 <= binaryValues.Length)
               //        print(binaryValues.Substring(i, 8) + "\t");
               //    else
               //        print(binaryValues.Substring(i, binaryValues.Length - i) + "\t");
               //}

          }



          // calculate hash
          static string ComputeSha256Hash(string rawData)
          {
               // Create a SHA256   
               using (SHA256 sha256Hash = SHA256.Create())
               {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                         builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
               }
          }



          // text to array of bytes
          private static byte[] textToBytes(string plainText)
          {
               return Encoding.ASCII.GetBytes(plainText);
          }

          //Byte array to Binary String
          private static string bytesAsBinaryString(Byte[] bytes)
          {
               string result = "";
               string oneByte = "";
               foreach (Byte b in bytes)
               {
                    oneByte = Convert.ToString(b, 2);
                    while (oneByte.Length < 8)
                    {
                         oneByte = "0" + oneByte;
                    }
                    result += oneByte;
               }
               return result;
          }

          private void btnRapidCaluclation_Click(object sender, EventArgs e)
          {
               // generate hash using a ready to use function to compare with my result;
               txtHashResult.Text = ComputeSha256Hash(txtMsg.Text);
               //txtLenChar.Text = txtHash.Text.Length.ToString();
               //txtLenByte.Text = (Int32.Parse(txtLenChar.Text) * 4).ToString();
          }// end of button click
          #endregion
          //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          #region step 2
          private void step2()
          {
               print("\n\n********************************** Step 2 – Initialize Hash Values (h) **********************************\n");

               //int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19 };
               //int counter = 0;

               //foreach (int num in primes)
               //{
               //    print("H" + counter + "\t");
               //    print(BinaryStringToHexString(decimalToBinary((Math.Sqrt(num)) % 1, 32).Substring(1)) + "\t");
               //    print(decimalToBinary((Math.Sqrt(num)) % 1, 32).Substring(1) + "\n");
               //    H[counter] = (uint)Convert.ToInt32(((BinaryStringToHexString(decimalToBinary((Math.Sqrt(num)) % 1, 32).Substring(1)))), 16);
               //    counter++;
               //}


               H[0] = 0x6a09e667;
               H[1] = 0xbb67ae85;
               H[2] = 0x3c6ef372;
               H[3] = 0xa54ff53a;
               H[4] = 0x510e527f;
               H[5] = 0x9b05688c;
               H[6] = 0x1f83d9ab;
               H[7] = 0x5be0cd19;

               print("H0\t" + string.Format("{0:X}", (long)H[0]) + "\t" + H[0] + "\t" + pad(Convert.ToString((long)H[0], 2), 32) + "\n");
               print("H1\t" + string.Format("{0:X}", (long)H[1]) + "\t" + H[1] + "\t" + pad(Convert.ToString((long)H[1], 2), 32) + "\n");
               print("H2\t" + string.Format("{0:X}", (long)H[2]) + "\t" + H[2] + "\t" + pad(Convert.ToString((long)H[2], 2), 32) + "\n");
               print("H3\t" + string.Format("{0:X}", (long)H[3]) + "\t" + H[3] + "\t" + pad(Convert.ToString((long)H[3], 2), 32) + "\n");
               print("H4\t" + string.Format("{0:X}", (long)H[4]) + "\t" + H[4] + "\t" + pad(Convert.ToString((long)H[4], 2), 32) + "\n");
               print("H5\t" + string.Format("{0:X}", (long)H[5]) + "\t" + H[5] + "\t" + pad(Convert.ToString((long)H[5], 2), 32) + "\n");
               print("H6\t" + string.Format("{0:X}", (long)H[6]) + "\t" + H[6] + "\t" + pad(Convert.ToString((long)H[6], 2), 32) + "\n");
               print("H7\t" + string.Format("{0:X}", (long)H[7]) + "\t" + H[7] + "\t" + pad(Convert.ToString((long)H[7], 2), 32) + "\n");
          }

          static String decimalToBinary(double num, int k_prec)
          {
               String binary = "";

               // Fetch the integral part of decimal number
               int Integral = (int)num;

               // Fetch the fractional part decimal number
               double fractional = num - Integral;

               // Conversion of integral part to
               // binary equivalent
               while (Integral > 0)
               {
                    int rem = Integral % 2;

                    // Append 0 in binary
                    binary += ((char)(rem + '0'));

                    Integral /= 2;
               }

               // Reverse string to get original binary
               // equivalent
               binary = reverse(binary);

               // Append point before conversion of
               // fractional part
               binary += ('.');

               // Conversion of fractional part to
               // binary equivalent
               while (k_prec-- > 0)
               {
                    // Find next bit in fraction
                    fractional *= 2;
                    int fract_bit = (int)fractional;

                    if (fract_bit == 1)
                    {
                         fractional -= fract_bit;
                         binary += (char)(1 + '0');
                    }
                    else
                    {
                         binary += (char)(0 + '0');
                    }
               }

               return binary;
          }

          static String reverse(String input)
          {
               char[] temparray = input.ToCharArray();
               int left, right = 0;
               right = temparray.Length - 1;

               for (left = 0; left < right; left++, right--)
               {
                    // Swap values of left and right
                    char temp = temparray[left];
                    temparray[left] = temparray[right];
                    temparray[right] = temp;
               }
               return String.Join("", temparray);
          }
          ///////////////////////////////////////////////////////////

          private static string BinaryStringToHexString(string binary)
          {
               if (string.IsNullOrEmpty(binary))
                    return binary;

               StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

               // TODO: check all 1's or 0's... throw otherwise

               int mod4Len = binary.Length % 8;
               if (mod4Len != 0)
               {
                    // pad to length multiple of 8
                    binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
               }

               for (int i = 0; i < binary.Length; i += 8)
               {
                    string eightBits = binary.Substring(i, 8);
                    result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
               }

               return result.ToString();
          }





          #endregion
          /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          #region step 3
          private void step3()
          {
               print("\n********************************** Step 3 – Initialize Round Constants (k) **********************************\n");
               //int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311 };
               //int counter = 0;
               //foreach (int num in primes)
               //{
               //    print("K" + counter + "\t");
               //    print(BinaryStringToHexString(decimalToBinary((Cbrt(num)) % 1, 32).Substring(1)) + "\t");
               //    print(decimalToBinary((Cbrt(num)) % 1, 32).Substring(1) + "\n");
               //    K[counter] = (uint)Convert.ToInt32(((BinaryStringToHexString(decimalToBinary((Cbrt(num)) % 1, 32).Substring(1)))), 16);

               //    counter++;
               //}

               for (int i = 0; i < 64; i++)
               {
                    print("K" + i + "\t" + string.Format("{0:X}", (long)K[i]) + "\t" + K[i] + "\t" + pad(Convert.ToString((long)K[i], 2), 32) + "\n");
               }
          }
          #endregion
          //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          #region step 4
          private void step4()
          {
               print("\n********************************** Step 4 – Chunk Loop (Create Message Blocks) **********************************\n");
               for (int i = 0; i < binaryValues.Length; i += 512)
               {
                    string block = binaryValues.Substring(i, 512);
                    print("Message Block " + i / 512 + "/" + ((binaryValues.Length / 512) - 1) + "\n");
                    print(block, 8, 8);
                    step5(block, i);
                    step6();
               }
          }
          #endregion
          //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          #region step 5
          private void step5(string blockOf512bits, int roundd)
          {
               print("\n********************************** Step 5 – Create Message Schedule (w) **********************************\n");
               int count = 0;
               for (int i = roundd; i < roundd + 512; i += 32)
               {
                    string w = binaryValues.Substring(i, 32);
                    W[count] = (UInt32)Convert.ToInt32(w, 2);
                    print("w" + count + "\t");
                    print(w + "\t");
                    print(W[count].ToString() + "\n");
                    count++;
               }
               print("Appending another 48 word to this Message Schedule\n");
               for (int i = 16; i < 64; i++)
               {
                    UInt32 r = sigma1(W[i - 2]) + W[i - 7] + sigma0(W[i - 15]) + W[i - 16];
                    W[i] = r;
                    print("w" + i + "\t");
                    print(pad(Convert.ToString(r, 2), 32) + "\t");
                    print(W[i].ToString() + "\n");
               }
          }
          #endregion
          //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          #region step 6
          private void step6()
          {
               print("\n\n********************************** Step 6 – Compression **********************************\n");


               UInt32 a = H[0],
                       b = H[1],
                       c = H[2],
                       d = H[3],
                       e = H[4],
                       f = H[5],
                       g = H[6],
                       h = H[7];

               for (int i = 0; i < 64; i++)
               {

                    UInt32 T1 = h + Sigma1(e) + Ch(e, f, g) + K[i] + W[i];
                    UInt32 T2 = Sigma0(a) + Maj(a, b, c);
                    h = g;
                    g = f;
                    f = e;
                    e = d + T1;
                    d = c;
                    c = b;
                    b = a;
                    a = T1 + T2;




                    print("\nM.S(" + i + ")\n");
                    print("k[" + i + "]:\t" + pad(Convert.ToString(K[i], 2), 32) + "\n");
                    print("w[" + i + "]:\t" + pad(Convert.ToString(W[i], 2), 32) + "\n");
                    print("T1:\t" + pad(Convert.ToString(T1, 2), 32) + "\n");
                    print("T2:\t" + pad(Convert.ToString(T2, 2), 32) + "\n");
                    print("T1+T2:\t" + pad(Convert.ToString(T1 + T2, 2), 32) + "\n");
                    //print("Sigma1(e):\t" + Sigma1(e));
                    print("a:\t" + pad(Convert.ToString(a, 2), 32) + "\n");
                    print("b:\t" + pad(Convert.ToString(b, 2), 32) + "\n");
                    print("c:\t" + pad(Convert.ToString(c, 2), 32) + "\n");
                    print("d:\t" + pad(Convert.ToString(d, 2), 32) + "\n");
                    print("e:\t" + pad(Convert.ToString(e, 2), 32) + "\n");
                    print("f:\t" + pad(Convert.ToString(f, 2), 32) + "\n");
                    print("g:\t" + pad(Convert.ToString(g, 2), 32) + "\n");
                    print("h:\t" + pad(Convert.ToString(h, 2), 32) + "\n");



               }
               print("\n\n********************************** Step 7 – Modify Final Values **********************************\n");

               H[0] += a;
               H[1] += b;
               H[2] += c;
               H[3] += d;
               H[4] += e;
               H[5] += f;
               H[6] += g;
               H[7] += h;

               print("a:\t" + pad(Convert.ToString(H[0], 2), 32) + "\t" + Convert.ToString(H[0], 16) + "\n");
               print("b:\t" + pad(Convert.ToString(H[1], 2), 32) + "\t" + Convert.ToString(H[1], 16) + "\n");
               print("c:\t" + pad(Convert.ToString(H[2], 2), 32) + "\t" + Convert.ToString(H[2], 16) + "\n");
               print("d:\t" + pad(Convert.ToString(H[3], 2), 32) + "\t" + Convert.ToString(H[3], 16) + "\n");
               print("e:\t" + pad(Convert.ToString(H[4], 2), 32) + "\t" + Convert.ToString(H[4], 16) + "\n");
               print("f:\t" + pad(Convert.ToString(H[5], 2), 32) + "\t" + Convert.ToString(H[5], 16) + "\n");
               print("g:\t" + pad(Convert.ToString(H[6], 2), 32) + "\t" + Convert.ToString(H[6], 16) + "\n");
               print("h:\t" + pad(Convert.ToString(H[7], 2), 32) + "\t" + Convert.ToString(H[7], 16) + "\n");

          }
          #endregion
          //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

          // needed functions
          private static UInt32 ROTL(UInt32 x, byte n)
          {
               return (x << n) | (x >> (32 - n));
          }

          private static UInt32 ROTR(UInt32 x, byte n)
          {
               return (x >> n) | (x << (32 - n));
          }

          private static UInt32 Ch(UInt32 x, UInt32 y, UInt32 z)
          {
               return (x & y) ^ ((~x) & z);
          }

          private static UInt32 Maj(UInt32 x, UInt32 y, UInt32 z)
          {
               return (x & y) ^ (x & z) ^ (y & z);
          }

          private static UInt32 Sigma0(UInt32 x)
          {
               return ROTR(x, 2) ^ ROTR(x, 13) ^ ROTR(x, 22);
          }

          private static UInt32 Sigma1(UInt32 x)
          {
               return ROTR(x, 6) ^ ROTR(x, 11) ^ ROTR(x, 25);
          }

          private static UInt32 sigma0(UInt32 x)
          {
               return ROTR(x, 7) ^ ROTR(x, 18) ^ (x >> 3);
          }

          private static UInt32 sigma1(UInt32 x)
          {
               return ROTR(x, 17) ^ ROTR(x, 19) ^ (x >> 10);
          }
          ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



          private void print(string text)
          {

               richText.Text = richText.Text + text;
               sd();
          }

          private void print(string text, int wordLength, int cols)
          {

               int wordcount = 0;
               string word = "";
               for (int i = 0; i < text.Length; i += wordLength)
               {
                    if (wordLength > (text.Length - i))
                         wordLength = text.Length - i;

                    word = text.Substring(i, wordLength);
                    wordcount++;

                    if (wordcount % cols == 0 && wordcount != 0)
                    {
                         richText.Text = richText.Text + word;
                         richText.Text = richText.Text + "\n";
                    }
                    else
                    {
                         richText.Text = richText.Text + word + "\t";
                    }
               }
               sd();
          }

          private string pad(string text, int toLength)
          {
               while (text.Length < toLength)
               {
                    text = "0" + text;
               }
               return text;
          }

          private double Cbrt(int num)
          {
               return Math.Pow(num, (1.0 / 3.0));
          }

          private void Sha256_Load(object sender, EventArgs e)
          {
          }

          private void setSleepTime_Click(object sender, EventArgs e)
          {
               if(!int.TryParse(textBox1.Text, out sleeptime))
               {
                    textBox1.Text="";
               }
          }

          private void Form1_Load(object sender, EventArgs e)
          {
               textBox1.Text=sleeptime.ToString();
          }

          private void lblState_Click(object sender, EventArgs e)
          {

          }
     }
}
