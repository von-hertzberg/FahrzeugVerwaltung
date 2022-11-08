using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Shared
{
    public class Helpers
    {
        /// <summary>
        /// Prints a string to the console in the given color.
        /// </summary>
        /// <param name="message">The message that should be printed to the console.</param>
        /// <param name="color">The color the message will have in the console.</param>
        public static void PrintWithColor(string message, ConsoleColor color)
        {
            var backupColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = backupColor;
        }

        /// <summary>
        /// Prints a string to the console in the color green.
        /// </summary>
        /// <param name="message">The message to be printed to the console.</param>
        public static void PrintSuccess(string message)
        {
            PrintWithColor(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Prints a string to the console in the color red.
        /// </summary>
        /// <param name="message">The message to be printed to the console.</param>
        public static void PrintError(string message)
        {
            PrintWithColor(message, ConsoleColor.Red);
        }

        /// <summary>
        /// The default prompt that will be printed when user input is requested.
        /// </summary>
        public const string PromptBegin = ">";
        /// <summary>
        /// The base path where vehicle lists will be stored.
        /// </summary>
        public const string BaseListPath = "C:/dev";

        /// <summary>
        /// Will print the prompt begin without starting a new line.
        /// </summary>
        static public void PrintPrompt()
        {
            Console.Write(PromptBegin);
        }

        /// <summary>
        /// Prompts the user for input until the user provides valid input.
        /// </summary>
        /// <param name="prompt">The prompt to print when user input is requested.</param>
        /// <param name="errorText">The message that will be printed as a error when the requested user input is faulty-./param>
        /// <returns>A double read from user input.</returns>
        static public double ReadDouble(string prompt, string errorText)
        {
            double result;

        ReadBegin:
            try
            {
                Console.Write(prompt);
                result = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                PrintError(errorText);
                goto ReadBegin;
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for input until the user provides valid input.
        /// </summary>
        /// <param name="prompt">The prompt to print when user input is requested.</param>
        /// <param name="errorText">The message that will be printed as a error when the requested user input is faulty-./param>
        /// <returns>An int read from user input.</returns>
        static public int ReadInt(string prompt, string errorText)
        {
            int result;

        ReadBegin:
            try
            {
                Console.Write(prompt);
                result = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                PrintError(errorText);
                goto ReadBegin;
            }

            return result;
        }
    }
}
