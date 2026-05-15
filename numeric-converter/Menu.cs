namespace numeric_converter
{
    static public class Menu
    {
        static public void StartProgram()
        {
            Console.WriteLine("Welcome to my numeric converter!");
            bool converting = true;

            while (converting)
            {
                converting = SelectConversion();
            }
            Console.WriteLine("\n\nThanks for using my program!");
        }

        static public bool SelectConversion()
        {
            Console.WriteLine("\nSelect a conversion method:" +
                "\n[1] - Decimal to Binary" +
                "\n[2] - Binary to Decimal" +
                "\n[3] - Decimal to Hexadecimal" +
                "\n[4] - Hexadecimal to Decimal" +
                "\n[0] - Exit program");
            char input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    DecimalToBinaryMenu();
                    break;
                case '2':
                    BinaryToDecimalMenu();
                    break;
                case '3':
                    DecimalToHexMenu();
                    break;
                case '4':
                    HexToDecimalMenu();
                    break;
                case '0':
                    return false;
                default:
                    Console.WriteLine("\nInvalid input.");
                    break;
            }
            return true;
        }

        static public void DecimalToBinaryMenu()
        {
            Console.WriteLine("\n\nEnter an integer:");
            string input = Console.ReadLine();
            int i;
            if (int.TryParse(input, out i) == false)
            {
                Console.WriteLine("Input is not an integer.");
                return;
            }
            Console.WriteLine($"Input {i} translates to {Converter.DecimalToBinary(i)}.");
        }

        static public void BinaryToDecimalMenu()
        {
            Console.WriteLine("\n\nEnter some binary:");
            string input = Console.ReadLine();
            int i;
            if (int.TryParse(input, out i) == false)
            {
                Console.WriteLine("Input is not an integer.");
                return;
            }

            foreach (char c in input)
            {
                int ci = c - '0';
                if (ci < 0 || ci > 1)
                {
                    Console.WriteLine("Input is not binary.");
                    return;
                }
            }

            Console.WriteLine($"Input {i} translates to {Converter.BinaryToDecimal(i)}.");
        }

        static public void DecimalToHexMenu()
        {
            Console.WriteLine("\n\nEnter a number:");
            string input = Console.ReadLine();
            int i;
            if (int.TryParse(input, out i) == false)
            {
                Console.WriteLine("Input is not an integer.");
                return;
            }

            Console.WriteLine($"Input {i} translates to {Converter.DecimalToHex(i)}.");
        }

        static public void HexToDecimalMenu()
        {
            Console.WriteLine("\n\nEnter some hexadecimal:");
            string input = Console.ReadLine();
            Console.WriteLine($"Input {input} translates to {Converter.HexToDecimal(input)}");
        }
    }
}
