using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class HelpSystems
    {
        public static Regex StandardRegex = new Regex("^[a-zA-ZäöüÄÖÜß1234567890]\\s*$");
        public static void PrintString(int x_Position, int y_Position, string s, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.SetCursorPosition(x_Position, y_Position);
            Console.Write(s);
            Console.ResetColor();
        }
        public static bool IsStringValid(string s, Regex regex)
        {
            if (regex.IsMatch(s) && !string.IsNullOrEmpty(s)) 
                return true;
            else
                return false;
        }
        public static string WriteText(int x_Position_Text, int y_Position_Text, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(y_Position_Text, x_Position_Text);
            Console.ForegroundColor = color;
            return Console.ReadLine();
        }
        public static double ProofDouble(double min, double max, double defaultValue, string question = "", double MAX = double.MaxValue, double MIN = double.MinValue)
        {
            double returnValue;
            bool x = false;

            do
            {
                Console.Write(question);
                string? s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                {
                    returnValue = defaultValue;
                    x = true;
                }
                else
                {
                    if (double.TryParse(s, out returnValue) && returnValue >= min && returnValue <= max && returnValue >= MIN && returnValue <= MAX)
                    {
                        x = true;
                    }
                }
            } while (!x);

            return returnValue;
        }
        public static int ProofInt(int min, int max, int defaultValue, string question = "", int MAX = int.MaxValue, int MIN = int.MinValue)
        {
            int returnValue;
            bool x = false;

            do
            {
                Console.Write(question);
                string? s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                {
                    returnValue = defaultValue;
                    x = true;
                }
                else
                {
                    if (int.TryParse(s, out returnValue) && returnValue >= min && returnValue <= max && returnValue >= MIN && returnValue <= MAX)
                    {
                        x = true;
                    }
                }
            } while (!x);

            return returnValue;
        }
        public static double IncreaseDouble(double valueToIncrease, double increasingLevel = 1.0)
        {
            return valueToIncrease + increasingLevel;
        }
        public static double DecreaseDouble(double valueToDecrease, double decreasingLevel = 1.0)
        {
            return valueToDecrease - decreasingLevel;
        }
        public static int IncreaseInt(int valueToIncrease, int increasingLevel = 1)
        {
            return valueToIncrease + increasingLevel;
        }
        public static int DecreaseInt(int valueToDecrease, int decreasingLevel = 1)
        {
            return valueToDecrease - decreasingLevel;
        }
    }
}
