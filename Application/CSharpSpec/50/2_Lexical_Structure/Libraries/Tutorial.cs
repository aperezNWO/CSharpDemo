using System;
using System.Collections.Generic;

namespace _2_Lexical_Structure.Libraries
{
    public class Tutorial
    {
        // 2.4.1 Unicode character escape sequences
        internal static void UnicodeCharacterEscapeExample()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("-- 2.4.1 UNICODE CHARACTER ESCAPE SEQUENCES         ----- ");
            Console.WriteLine("----------------------------------------------------------");

            bool f = true;
            Unicode.TestUnicode(f);
            f      = !f;
            Unicode.TestNonUnicode(f);

            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
        }
        // 2.4.2 Identifiers
        internal static void IdentifierExample()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("-- 2.4.2 IDENTIFIERS                                ----- ");
            Console.WriteLine("----------------------------------------------------------");

            bool f = true;
            Unicode.@static(f);
            f      = !f;
            Unicode.CallVerbation(f);

            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
        }
        // 2.4.3. Keywords
        internal static void KeywordsExample()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("-- 2.4.3 KEYWORDS                                   ----- ");
            Console.WriteLine("----------------------------------------------------------");

            // INTELLISENSE CALLS THE RELATED "SUMMARY" TAG
            Unicode.@static(true);

            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
        }
        // 2.4.4. Literals
        internal static void LiteralsExample()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("-- 2.4.4 LITERALS                                   ----- ");
            Console.WriteLine("----------------------------------------------------------");

            // 2.4.4.1  Boolean Literals
            bool value = false;
            Console.WriteLine("-- 2.4.4.1 Boolean Literal : {0}|{1}", value,!value);

            // 2.4.4.2  Integer Literals
            int  a    = int.MaxValue;
            a         = System.Int32.MaxValue;
            int a_a   = 10;
            uint b    = uint.MaxValue;
            b         = System.UInt32.MaxValue;
            uint b_b  = 100U;
            long c    = long.MaxValue;
            c         = System.Int64.MaxValue;
            long c_c  = 1000L;
            c_c       = 10000U;
            ulong d   = ulong.MaxValue;
            d         = System.UInt64.MaxValue;
            ulong d_d  = 1000000LU;
            short e    = short.MaxValue;
            e          = Int16.MaxValue;
            ushort f   = ushort.MaxValue;
            f          = UInt16.MaxValue;

            Console.WriteLine("-- 2.4.4.2 Integer Literal : ");

            Console.WriteLine("--- {1} : {0} ", e, e.GetType().ToString());
            Console.WriteLine("--- {1} : {0} ", f, f.GetType().ToString());
            Console.WriteLine("--- {1} : {0} ", a, a.GetType().ToString());
            Console.WriteLine("--- {1} : {0} ", b, b.GetType().ToString());
            Console.WriteLine("--- {1} : {0} ", c, c.GetType().ToString());
            Console.WriteLine("--- {1} : {0} ", d, d.GetType().ToString());

            Console.WriteLine("-- Hexadecimal Literal From : ");

            e   = 0x7FF;
            f   = 0xFFFF;
            a_a = 0xA;
            b_b = 0x64;
            c_c = 0x2710;
            d_d = 0xF4240;

            Console.WriteLine("--- Short          : {0:X} ", e);
            Console.WriteLine("--- Unsigned Short : {0:X} ", f);
            Console.WriteLine("--- Int            : {0:X} ", a_a);
            Console.WriteLine("--- Unsigned Int   : {0:X} ", b_b);
            Console.WriteLine("--- Long           : {0:X} ", c_c);
            Console.WriteLine("--- Unsigned Long  : {0:X} ", d_d);

            // 2.4.4.3  Real Literals
            Console.WriteLine("-- 2.4.4.3 Real Literal : ");

            decimal decimalValue_1 = decimal.MaxValue;
            decimal decimalValue_2 = 1m;
            decimal decimalValue_3 = 1.5m;
            decimal decimalValue_4 = 10e10m;

            float floatValue_1   = float.MaxValue;
            float floatValue_2   = 1F;
            float floatValue_3   = 1.5F;
            float floatValue_4   = 10e10F;

            double doubleValue_1   = double.MaxValue;
            double doubleValue_2   = 1d;
            double doubleValue_3   = 1.5d;
            double doubleValue_4   = 10e10d;

            Console.WriteLine("--- {0} : {1:F}  ", decimalValue_1.GetType(), decimalValue_1);
            Console.WriteLine("--- {0} : {1:f}  ", decimalValue_2.GetType(), decimalValue_2);
            Console.WriteLine("--- {0} : {1:F}  ", decimalValue_3.GetType(), decimalValue_3);
            Console.WriteLine("--- {0} : {1:F}  ", decimalValue_4.GetType(), decimalValue_4);

            Console.WriteLine("--- {0} : {1:f}  ", floatValue_1.GetType()  , floatValue_1);
            Console.WriteLine("--- {0} : {1:f}  ", floatValue_2.GetType()  , floatValue_2);
            Console.WriteLine("--- {0} : {1:f}  ", floatValue_3.GetType()  , floatValue_3);
            Console.WriteLine("--- {0} : {1:f}  ", floatValue_4.GetType()  , floatValue_4);

            Console.WriteLine("--- {0} : {1:f}  ", doubleValue_1.GetType(), doubleValue_1);
            Console.WriteLine("--- {0} : {1:f}  ", doubleValue_1.GetType(), doubleValue_2);
            Console.WriteLine("--- {0} : {1:f}  ", doubleValue_1.GetType(), doubleValue_3);
            Console.WriteLine("--- {0} : {1:f}  ", doubleValue_1.GetType(), doubleValue_4);


            // 2.4.4.4 Character Literals
            Console.WriteLine("-- 2.4.4.4 Character Literals : ");

            char singleQuote           = '\'';
            char singleQuoteHexUnicode = '\x0027';
            char alert                 = '\a';
            char alertHexUnicode       = '\x0007';

            Console.WriteLine("--- singleQuote          : {0}", singleQuote);
            Console.WriteLine("--- singleQuoteUnicode   : {0}", singleQuoteHexUnicode);
            Console.WriteLine("--- alert                : {0}", alert);
            Console.WriteLine("--- alertHexUnicode      : {0}", alertHexUnicode);

            // 2.4.4.5 String Literals
            Console.WriteLine("-- 2.4.4.5 String Literal : ");

            string string_1 =  "hello, world";                 // hello, world
            string string_2 = @"hello, world";                 // hello, world
            string string_3 =  "hello \t world";               // hello 	 world
            string string_4 = @"hello \t world";               // hello \t world
            string string_5 =  "Joe said \"Hello\" to me";     // Joe said "Hello" to me
            string string_6 = @"Joe said ""Hello"" to me";     // Joe said "Hello" to me
            string string_7 =  "\\\\server\\share\\file.txt";  // \\server\share\file.txt
            string string_8 = @"\\server\share\file.txt";      // \\server\share\file.txt
            string string_9 =  "\n\rone\n\rtwo\n\rthree";
            string string_0 = @"\n\rone\n\rtwo\n\rthree";

            Console.WriteLine("--- String 2      : {0}", string_2);
            Console.WriteLine("--- String 1      : {0}", string_1);
            Console.WriteLine("--- String 4      : {0}", string_4);
            Console.WriteLine("--- String 3      : {0}", string_3);
            Console.WriteLine("--- String 6      : {0}", string_6);
            Console.WriteLine("--- String 5      : {0}", string_5);
            Console.WriteLine("--- String 8      : {0}", string_8);
            Console.WriteLine("--- String 7      : {0}", string_7);
            Console.WriteLine("--- String 0      : {0}", string_0);
            Console.WriteLine("--- String 9      : {0}", string_9);


            object string_left  = "hello";
            object string_right = "hello";
            System.Console.WriteLine("String Comparison : (\"{0}\"==\"{1}\")? :{2} ", string_left,string_right,(string_left == string_right));

            // 2.4.4.6 Null Literals
            Console.WriteLine("-- 2.4.4.5 Null Literal : ");

            int? nullValueTest;

            nullValueTest      = 10;

            Console.WriteLine("--- Integer with null value : {0} ", (nullValueTest is null));

            nullValueTest      = null;

            Console.WriteLine("--- Integer with null value : {0} " , (nullValueTest is null));



            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
        }
        // 2.4.5  Operators and Punctuators
        internal static void OperatorsPunctuatorsExample()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("-- 2.4.5  Operators and Punctuators                 ----- ");
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("-- Null Coalescing Operator Example");

            string nullValueTest;
            string nullValueResult;


            nullValueTest   = null;
            nullValueResult = nullValueTest ?? "True";

            Console.WriteLine("--- Null Value ? {0} ", nullValueResult);


            nullValueTest   = "False";
            nullValueResult = nullValueTest ?? "True";


            Console.WriteLine("--- Null Value ? {0} ", nullValueResult);


            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
        }
        // 2.5 PREPROCESSING DIRECTIVES
        internal static void PreProcessingDirectivesExample()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("-- 2.5  PREPROCESSING DIRECTIVES                    ----- ");
            Console.WriteLine("----------------------------------------------------------");

            PreProcessingTest.Run();

            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
