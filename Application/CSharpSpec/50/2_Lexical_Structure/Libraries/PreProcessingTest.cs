#define A
#undef  B

#warning Warning 1
#warning Warning 2
#warning Warning 3

#if A && B
#error Cannot Define both A and B simultaneously
#endif

// TODO: Item 1
// TODO: Item 2
// TODO: Item 3
namespace _2_Lexical_Structure.Libraries
{
    public class C
    {
        #if A
            public static void F() { }
        #else
            public static void G() {}
        #endif

        #if B
            public static void H() {}
        #else
            public static void I() { }
        #endif
    }
    public class PreProcessingTest
    {
        public static void Run()
        {
            C.F();
            //C.I();
        }
    }
}
