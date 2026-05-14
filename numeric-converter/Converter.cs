namespace numeric_converter
{
    static public class Converter
    {
        static public int GetRemainderDivByTwo(int i)
        {
            return i % 2;
        }

        static public int GetRemainderDivBySixteen(int i)
        {
            return i % 16;
        }

        static public char ConvertIntToLetter(int i)
        {
            char letter = '0';
            switch (i)
            {
                case 10:
                    letter = 'A';
                    break;
                case 11:
                    letter = 'B';
                    break;
                case 12:
                    letter = 'C';
                    break;
                case 13:
                    letter = 'D';
                    break;
                case 14:
                    letter = 'E';
                    break;
                case 15:
                    letter = 'F';
                    break;
                default:
                    Console.WriteLine("Error: input number outside of bounds.");
                    break;
            }
            return letter;
        }

        static public int ConvertLetterToInt(char l)
        {
            int num = 0;
            switch (l)
            {
                case 'A':
                case 'a':
                    num = 10;
                    break;
                case 'B':
                case 'b':
                    num = 11;
                    break;
                case 'C':
                case 'c':
                    num = 12;
                    break;
                case 'D':
                case 'd':
                    num = 13;
                    break;
                case 'E':
                case 'e':
                    num = 14;
                    break;
                case 'F':
                case 'f':
                    num = 15;
                    break;
                default:
                    Console.WriteLine("Error: input letter outside of bounds.");
                    break;
            }
            return num;
        }

        static public int GetPowerOfTwo(int p)
        {
            double power = Math.Pow(2, p);
            return Convert.ToInt32(power);
        }

        static public int GetPowerOfSixteen(int p)
        {
            double power = Math.Pow(16, p);
            return Convert.ToInt32(power);
        }

        static public int DecimalToBinary(int dec)
        {
            string binaryString = "";

            while (dec > 0)
            {
                int r = GetRemainderDivByTwo(dec);
                binaryString = r + binaryString;
                dec = dec / 2;
            }

            int binary;
            if (int.TryParse(binaryString, out binary) == false)
            {
                throw new Exception("Something went wrong in converting a string to an integer.");
            }
            return binary;
        }

        static public int BinaryToDecimal(int bin)
        {
            string binString = $"{bin}";
            int dec = 0;
            int power = 0;

            for (int i = binString.Length - 1; i >= 0; i--)
            {
                int curr = (int)char.GetNumericValue(binString[i]);

                if (curr >= 2 || curr < 0)
                {
                    throw new Exception("Input is not binary.");
                }

                int calcPower = GetPowerOfTwo(power++);

                dec += curr * calcPower;
            }
            return dec;
        }

        static public string DecimalToHex(int dec)
        {
            string hexString = "";

            if (dec < 16)
            {
                return hexString + ConvertIntToLetter(dec);
            }

            while (dec > 0)
            {
                int r = GetRemainderDivBySixteen(dec);
                if (r > 9)
                {
                    r = ConvertIntToLetter(r);
                }
                hexString = r + hexString;
                dec = dec / 16;
            }
            return hexString;
        }

        static public int HexToDecimal(string hex)
        {
            int[] decs = new int[hex.Length];
            int decCount = 0;
            int power = hex.Length - 1;
            Console.WriteLine("power = " + power);

            foreach (char c in hex)
            {
                int i;
                if (Char.ToUpper(c) == 'A' || Char.ToUpper(c) == 'B' || Char.ToUpper(c) == 'C' || Char.ToUpper(c) == 'D' || Char.ToUpper(c) == 'E' || Char.ToUpper(c) == 'F') 
                {
                    i = ConvertLetterToInt(c);
                }
                else
                {
                    i = (int)char.GetNumericValue(c);
                    if (i < 0)
                    {
                        Console.WriteLine("Invalid input.");
                        return 0;
                    }
                    Console.WriteLine(i);
                }
                decs[decCount++] = i;
            }

            for (int i = 0; i < decs.Length; i++)
            {
                decs[i] = decs[i] * GetPowerOfSixteen(power--);
                Console.WriteLine(decs[i]);
            }

            int sum = 0;

            foreach (int i in decs)
            {
                sum += i;
            }

            Console.WriteLine(sum);
            return sum;
        }
    }
}