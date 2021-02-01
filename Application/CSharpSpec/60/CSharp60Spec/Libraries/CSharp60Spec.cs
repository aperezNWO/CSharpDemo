using System;
using CSharp60Spec.Libraries;

namespace CSharp60pec
{ 
    public class CSharp60Spec
    {
        public static void DocumentationCommentsTest()
        {
            try
            {
                //
                Console.WriteLine("[Documentation Comments]");
                //
                Console.WriteLine("[VISUAL STUDIO AUTOCOMPLETE REFLECTS CODE COMMENTS]");
                // VISUAL STUDIO AUTOCOMPLETE REFLECTS CODE COMMENTS
                Point point = new Point(xor: 1, yor: 1);
                //
                point.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Ha ocurrido un error : {0}]", string.Concat(new string[] { ex.Message, ex.StackTrace }));
            }
        }
    }
}