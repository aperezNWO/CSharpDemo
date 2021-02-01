#define MAIN_VOID
#define MAIN_NO_ARGS

using _3_Basic_Concepts.Libraries;

namespace _3_Basic_Concepts
{
    public class Program
    {
        // 3.1 Application Startup
        #region "Different Entry Points"

        #region "MAIN_VOID"

        #if MAIN_VOID

        #if MAIN_ARGS
        //
        public static void Main(string[] args)
        {
            //  ...
            Tutorial.Run();
        }
        #else
        //
        public static void Main()
        {
            //  ...
            Tutorial.Run();
        }
        #endif

        #endif
        #endregion

        #region "MAIN_INT"

        #if MAIN_INT
        //
        public static int Main()
        {
            // ...
            Tutorial.Run();
            //
            return 0;
        }
        //
        public static int Main(string[] args)
        {
            // ...
            Tutorial.Run();
            //
            return 0;
        }
        #endif  

        #endregion

        #endregion
    }
}
