using CommandLineFluent;
using Encryption.Caesar;
using System;

namespace CaesarCipherApp
{
    class Program
    {
        public class Input
        {
            public string Text { get; set; }
            public int? Shift { get; set; }
            public bool Decrypt { get; set; }
        }

        static void Main(string[] args)
        {
            CliParser parser = new CliParserBuilder()
                .AddVerb<Input>("encrypt", verb =>
                {
                    verb.HelpText = "Encrypts the input text";
                    verb.Invoke = EncryptText;

                    verb.AddValue(theClass => theClass.Text, x =>
                    {
                        x.DescriptiveName = "Input Text";
                        x.HelpText = "The text which has to be processed";
                    });

                    verb.AddOption(theClass => theClass.Shift, x =>
                    {
                        x.ShortName = "-s";
                        x.LongName = "--shift";
                        x.DescriptiveName = "Shift";
                        x.HelpText = "The number oharachters to shift";
                        x.Required = false;
                    });
                })
                .AddVerb<Input>("decrypt", verb =>
                {
                    verb.HelpText = "Decrypts the input text";
                    verb.Invoke = DecryptText;

                    verb.AddValue(theClass => theClass.Text, x =>
                    {
                        x.DescriptiveName = "Input Text";
                        x.HelpText = "The text which has to be processed";
                    });

                    verb.AddOption(theClass => theClass.Shift, x =>
                    {
                        x.ShortName = "-s";
                        x.LongName = "--shift";
                        x.DescriptiveName = "Shift";
                        x.HelpText = "The number oharachters to shift";
                        x.Required = false;
                    });
                })
                .Build();

            IParseResult result = parser.Parse(args);

            parser.Handle(result); 

        }

        private static void EncryptText(Input input)
        {
            ProcessText(input, Cipher.Encrypt);
        }

        private static void DecryptText(Input input)
        {
            input.Decrypt = true;
            ProcessText(input, Cipher.Decrypt);
        }

        private static void ProcessText(Input input, Func<string, int, string> method)
        {
            Console.WriteLine();
            if (input.Shift.HasValue)
            {
                string label = input.Decrypt ? "Decrypted Text: " : "Encrypted Text: ";

                Console.WriteLine(label + method(input.Text, input.Shift.Value));
            }
            else
            {
                string label = input.Decrypt ? "Decrypted Text" : "Encrypted Text";
                int padding = Math.Max(label.Length, input.Text.Length);
                
                string heading = " | Shift | " + label.PadRight(padding) + " |";
                string lineSeparator = ' ' + new string('-', heading.Length - 1);
                
                Console.WriteLine(lineSeparator);
                Console.WriteLine(heading);
                Console.WriteLine(lineSeparator);
                for (int i = -26; i < 27; i++)
                {

                    string paddedIndex = i.ToString();

                    paddedIndex = paddedIndex.PadRight(5);  
                    
                    string result = method(input.Text, i);

                    result = result.PadRight(padding);

                    Console.WriteLine(string.Format(" | {0} | {1} |", paddedIndex, result));
                }
                Console.WriteLine(lineSeparator);
            }
        }
    }
}
