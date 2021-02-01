
namespace _2_Lexical_Structure.Libraries
{
    public class Unicode
    {
        // evaluate 'f' character
        public static void TestUnicode(bool \u0066)
        {
            char c = '\u0066';
            if (\u0066)
                System.Console.WriteLine(c.ToString());
        }
        // evaluate 'f' character
        public static void TestNonUnicode(bool f)
        {
            char c = 'f';
            if (!f)
                System.Console.WriteLine(c.ToString());
        }
        // @ = VERBATION IDENTIFIER
        /// <summary>VERBATION IDENTIFIER
        /// Calling a method with the name of a keyword using the @ character
        /// </summary>
        public static void @static(bool @bool)
        {
            // 
            if (@bool)
                System.Console.WriteLine("true");
            else
                System.Console.WriteLine("false");
        }
        //
        public static void CallVerbation(bool _bool)
        {
            // \u0061 = 'a';
            st\u0061tic(_bool);
            //
            @static(_bool);
        }
    }
}
