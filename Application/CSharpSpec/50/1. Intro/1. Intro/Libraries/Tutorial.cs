using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;
using Acme.Utilities;
using _1.Intro.Geometry;
using _1.Intro.Libraries;


namespace _1.Intro
{
    public class Tutorial
    {
        //private static readonly int SCREEN_SIZE = 50;
        delegate int TestDelegate(int x, int y);

        //1.1 Hello World
        public static void HelloWorld()
        {
            Console.WriteLine("Hello, World");
            Console.Read();
        }
        // 1.2 Program Structure
        public static void StackExample()
        {
            Acme.Collections.Stack s = new Acme.Collections.Stack();
            s.Push(1);
            s.Push(10);
            s.Push(100);
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.Read();
        }
        // 1.3 Types and Variables
        private static void TypesVarialblesExample()
        {
            int i = 123;
            object o = i;       // Boxing
            Console.WriteLine(i.GetType().ToString());
            int j = (int)o;     // Unboxing

            Console.Read();
        }
        // 1.4 Expressions
        private static void ExpressionsExample()
        {
            // Expression = Operator and Operands
            // Anonymous Type
            var myAnonymousType = new
            {
                firstProperty = "First",
                secondProperty = 2,
                thirdProperty = true,
                anotherAnonymousType = new { nestedProperty = "Nested" }
            };

            Console.Write(String.Format(" first Property : {0} \n second Property : {1} \n third property : {2} \n forth Property : {3}"
                , myAnonymousType.firstProperty
                , myAnonymousType.secondProperty
                , myAnonymousType.thirdProperty
                , myAnonymousType.anotherAnonymousType.nestedProperty
                ));
            // Anonymous Functions (Lambda Expressions).

            // expression / statement
            TestDelegate delegateInstance_1 = (x, y) => (x + y);
            Console.Write("\n Anonymous function result : {0} ", delegateInstance_1(1, 2));

            // block
            TestDelegate delegateInstance_2 = (x, y) =>
            {
                int result = x + y;
                return result;
            };
            Console.WriteLine("\n Anonymous function result : {0}", delegateInstance_2(1, 2));

            Console.ReadLine();
        }
        //1.5 Statements
        private static async Task<int> DownloadDocsMainPageAsync()
        {
            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

            var client = new HttpClient();
            // await unary operator
            string csharpSpec_60_url = @"https://opdhsblobprod02.blob.core.windows.net/contents/c6aea4f5457448ee818b7292ba695982/baa0fdc1df05050045bf92716d78ad8e?sv=2015-04-05&sr=b&sig=OsJ4g0SdJ%2FRlTDr7ymfPsUjAClzvPRfGZ80LC5Tk3q0%3D&st=2019-11-04T05%3A44%3A41Z&se=2019-11-05T05%3A54%3A41Z&sp=r";
            byte[] content = await client.GetByteArrayAsync(csharpSpec_60_url);

            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
            return content.Length;
        }
        //
        private void StatementsExample()
        {
            // lock statement (thread locking)
            lock (this)
            {
                // using statement
                using (Task<int> downloading = DownloadDocsMainPageAsync())
                {
                    Console.WriteLine($"{nameof(StatementsExample)}: Launched downloading.");
                    downloading.Wait();
                    int bytesLoaded = downloading.Result;
                    Console.WriteLine($"{nameof(StatementsExample)}: Downloaded {bytesLoaded} bytes.");
                    Console.ReadLine();
                }
                // checked / unchecked statement
                int i = int.MaxValue;
                Console.WriteLine("Original Value : {0}", i);
                checked
                {
                    try
                    {
                        Console.WriteLine(i + 1);       // Exception
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Managed Exception : {0} \n {1}", ex.Message, ex.StackTrace);
                    }
                }
                unchecked
                {
                    Console.WriteLine("Program not interrrupted (overflow) : {0}", (i + 1));       // Overflow
                }
                Console.ReadLine();
            }
        }
        // 1.6 Classes and Objects
        internal static void ClassesObjectsExample()
        {
            Point object_1 = new Point(1, 2);
            Point object_2 = new Point(3, 4);
            GC.Collect();
            Console.ReadLine();
        }
        // 1.6.1 Members
        internal static void MembersExample()
        {
            Box Box1 = new Box(6.0, 7.0, 5.0);    // Declare Box1 of type Box
            Box Box2 = new Box(12.0, 13.0, 10.0);   // Declare Box2 of type Box
            Box Box3 = new Box();                   // Declare Box3 of type Box
            Box3 = Box1 + Box2;

            Console.WriteLine("Box 1 : {0}", Box1.ToString());
            Console.WriteLine("Box 2 : {0}", Box2.ToString());
            // volume 3 = (6+12) * (7+13) * (5 + 10) = 18*20*15 = 5400
            Console.WriteLine("Box 3 : {0}", Box3.ToString());

            Console.ReadLine();
        }
        // 1.6.2 Accesibility
        // 1.6.3 Type Parameters
        internal static void TypeParametersExample()
        {
            TPoint<int   , string>   point_1 = new TPoint<int     , string>    { x = 1    , y = @"two" };
            TPoint<double, double>   point_2 = new TPoint<double  , double>    { x = 3.1  , y = 4.2    };
            TPoint<float , float>    point_3 = new TPoint<float   , float>     { x = 5.2F , y = 6.3F   };

            Console.Write("\nPoint 1 : ({0},{1})", point_1.x, point_1.y);
            Console.Write("\nPoint 2 : ({0},{1})", point_2.x, point_2.y);
            Console.Write("\nPoint 3 : ({0},{1})", point_3.x, point_3.y);

            Console.ReadLine();
        }
        // 1.6.4 Base Classes
        internal static void BaseClassExample()
        {
            // Definition of Base Class (Commonly used on interfaces)
            Point b = new Point3D(10, 20, 30);

            Console.Write("\nPoint 3d Example : ({0},{1},{2})", b.x, b.y, ((Point3D)b).z);

            Console.ReadLine();
        }
        // 1.6.7 Fields
        internal static void FieldsExample()
        {
            Color colorWhite_1 = Color.White;
            Color colorWhite_2 = new Color(255, 255, 255);

            Console.Write("\nColor Example #1 : ({0})", colorWhite_1.ToString());
            Console.Write("\nColor Example #2 : ({0})", colorWhite_2.ToString());

            Console.ReadLine();

        }
        // 1.6.6 Methods
        // 1.6.6.1 Parameters
        internal static void MethodParameterExample()
        {
            // a) Value Parameter default value example = 0;
            Color colorBlack_1 = new Color();

            // b) References Parameter (both input/output)
            int i         = 1;
            int j         = 2;
            string s      = string.Empty;
            object[] args = null;
             
            // d) Array Parameter
            s             = "Parameters before swap : i={0} j={1}";
            args          = new object[2];
            args[0]       = i;
            args[1]       = j;
            Console.WriteLine(s, args);

            // b) References Parameter (both input/output)
            ParameterExample.Swap(ref i, ref j);

            // d) Array Parameter
            s            = "Parameters after swap : i={0} j={1}";
            args         = new object[2];
            args[0]      = i;
            args[1]      = j;
            Console.WriteLine(s, args);

            // c) Output Parameter
            int operand_1 = 10;
            int operand_2 = 3;
            int result    = 0;
            int reminder  = 0;
            ParameterExample.Divide(operand_1, operand_2, out result, out reminder);

            // d) Array Parameter
            s        = " Output Parameters example : op_1={0}, op_2={1}, op_1/op_2={2}, op_1%op_2={3}";
            args     = new object[4];
            args[0]  = operand_1;
            args[1]  = operand_2;
            args[2]  = result;
            args[3]  = reminder;

            Console.WriteLine(s, args);

            Console.ReadLine();
        }
        // 1.6.6.2 Method Body and Local Variables
        internal static void MethodBodyLocalVarsExample()
        {
            int i = 0; /* Unassigned variable throws compiler error */
            int j;
            while (i < 10)
            {
                j = i * i;
                Console.WriteLine("{0} x {0} = {1}", i, j);
                i = i + 1;
            }
            Console.ReadLine();
        }
        // 1.6.6.3 Static and Instance Methods
        internal static void StaticInstanceMethodExample()
        {
            Entity.SetNextSerialNo(1000);
            Entity e1 = new Entity();
            Entity e2 = new Entity();
            Console.WriteLine(e1.GetSerialNo());                // Outputs "1000"
            Console.WriteLine(e2.GetSerialNo());                // Outputs "1001"
            Console.WriteLine(Entity.GetNextSerialNo());        // Outputs "1002"
            Console.ReadLine();
        }
        // 1.6.6.4 Virtual, Override,and abstract methods
        internal static void VirtualOverrideAbstractExample()
        {
            //------------------------------------
            // A METHOD MARKED AS ABSTRACT MUST BE OVERRIDEN
            // A METHOD MARKED AS VIRTUAL  CAN  BE OVERRIDEN
            //------------------------------------

            //------------------------------------
            // Evaluate the expression x *(y + 2)
            //------------------------------------
            Libraries.Math e = new Operation(
                        new VariableReference("x"),
                        '*',
                        new Operation(
                            new VariableReference("y"),
                            '+',
                            new Constant(2)
                        )
                    );
            Hashtable vars = new Hashtable();
            vars["x"] = 3;
            vars["y"] = 5;
            Console.WriteLine(string.Format("{0} * ({1} + 2)  = {2} ", vars["x"], vars["y"] ,e.Evaluate(vars)));        // Outputs "21"
            vars["x"] = 1.5;
            vars["y"] = 9;
            Console.WriteLine(string.Format("{0} * ({1} + 2)  = {2} ", vars["x"], vars["y"], e.Evaluate(vars)));        // Outputs "16.5"
            Console.ReadLine();
        }
        // 1.6.6.5 Method Overloading
        internal static void MethodOverloadingExample()
        {
            OverloadingExample.Run();
            Console.ReadLine();
        }
        // 1.6.7 Other function members
        // 1.6.7.1 Constructors
        internal static void ConstructorExample()
        {
            Console.WriteLine("LIST 0 ----------------------------------");

            DummyClassNoInstanceConstructor list0_1 = new DummyClassNoInstanceConstructor();    // callilng static constructor just one time.

            DummyClassNoInstanceConstructor list0_2 = new DummyClassNoInstanceConstructor();    // no callilng of static constructor.

            Console.WriteLine("LIST 1 ----------------------------------");

            ListExample<string>  list1;    // callilng instance constructor, no parameters.

            Console.WriteLine("LIST 2 ----------------------------------");

            ListExample<string>  list2;    // callling instance constructor with parameters.

            Console.WriteLine("LIST 1 ----------------------------------");

            list1 = new ListExample<string>();      // callilng instance constructor, no parameters.

            Console.WriteLine("LIST 2 ----------------------------------");

            list2 = new ListExample<string>(10);    // callling instance constructor with parameters.

            Console.WriteLine("LIST 3 ----------------------------------");

            InheritedListExample list3;      // calling  intance  base constructor, no parameters.

            Console.WriteLine("LIST 4 ----------------------------------");

            InheritedListExample list4;      // calling  intance  base constructor with parameters.

            Console.WriteLine("LIST 3 ----------------------------------");

            list3 = new InheritedListExample();      // calling  intance  base constructor, no parameters.

            Console.WriteLine("LIST 4 ----------------------------------");

            list4 = new InheritedListExample(4);     // calling  intance  base constructor with parameters.

            Console.WriteLine("----------------------------------");

            Console.ReadLine();

        }
        // 1.6.7.2 Properties
        internal static void PropertiesExample()
        {

            Console.WriteLine("----------------------------------");
            Console.WriteLine("-- 1.6.7.2 PROPERTIES           --");
            Console.WriteLine("----------------------------------");

            ListExample<string> names = new ListExample<string>();
            names.Capacity            = 100;                   // Invokes set accessor 
            int i                     = names.Count;           // Invokes get accessor 
            int j                     = names.Capacity;        // Invokes get accessor 

            Console.WriteLine("----------------------------------");

            Console.ReadLine();
        }
        // 1.6.7.3 Indexers
        // 1.6.7.4 Events
        internal static void IndexerEventExample()
        {

            Console.WriteLine("----------------------------------");
            Console.WriteLine("-- 1.6.7.3/4 INDEXERS / EVENTS  --");
            Console.WriteLine("----------------------------------");

            ListExample<string> names = new ListExample<string>();
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            for (int i = 0; i < names.Count; i++)
            {
                string s = names[i];
                names[i] = s.ToUpper();
                Console.WriteLine(" Array in position {0},{1}",i,names[i]);
            }

            Console.WriteLine("----------------------------------");

            Console.ReadLine();
        }
        // 1.6.7.5 Operator
        internal static void OperatorExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.6.7.5/6 OPERATORS/DESTRUCTORS --");
            Console.WriteLine("-------------------------------------");

            ListExample<int> a;
            ListExample<int> b;

            using (a = new ListExample<int>())
            {
                a.Add(1);
                a.Add(2);

                using (b = new ListExample<int>())
                {
                    b.Add(1);
                    b.Add(2);

                    Console.WriteLine("Comparing Lists before modification : {0}", (a == b));// Outputs "True"  
                    b.Add(3);
                    Console.WriteLine("Comparing Lists after  modification : {0}", (a == b));// Outputs "False"  
                }
            }

            Console.WriteLine("-------------------------------------");

            Console.ReadLine();
        }
        // 1.7 STRUCTS
        internal static void StructExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.7 STRUCTS                     --");
            Console.WriteLine("-------------------------------------");

            // CLASSES ARE ALLOCATED ON HEAP
            Point a = new Point(10, 10);
            Point b = a;
            a.x     = 20;
            Console.WriteLine("Class Property Value : {0}",b.x);

            // STRUCTS ARE ALLOCATED ON STACK
            TPoint c = new TPoint(10, 10);
            TPoint d = c;
            c.x      = 20;
            Console.WriteLine("Structs Property Value : {0}", d.x);

            Console.WriteLine("----------------------------------");

            Console.ReadLine();
        }
        // 1.8 ARRAYS
        internal static void ArrayExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.8 ARRAYS                      --");
            Console.WriteLine("-------------------------------------");

            // ARRAY INITIALIZATION ALTERNATIVES
            int[] a = new int[]  { 1, 2, 3 };
            int[] b = { 1, 2, 3 };
            int[] c = new int[3] { 1, 2, 3 };

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("Array Initialization : {0},{1},{2}", a[i], b[i], c[i]);
            }

            // JAGGED ARRAY

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1,2,3,4 };
            jaggedArray[1] = new int[5] { 1,2,3,4,5 };
            jaggedArray[2] = new int[6] { 1,2,3,4,5,6 };

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine("-------------------------------------");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine("Jagged Array  : {0}", jaggedArray[i][j]);
                }
                Console.WriteLine("-------------------------------------");
            }

            int [,,] multidimentionalArray = new int [2,2,3] 
                                       { 
                                           { { 1, 2, 3 }, { 4 , 5 , 6  } } 
                                           ,
                                           { { 7, 8, 9 }, { 10, 11, 12 } }
                                       };

            Console.WriteLine("Multidimentional Array Rank     : {0}", multidimentionalArray.Rank);

            Console.WriteLine("Multidimentional Array Elements :    ");

            foreach (int i in multidimentionalArray)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("-------------------------------------");

            Console.ReadLine();

        }
        // 1.9 Interfaces
        internal static void InterfacesExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.9 INTERFACES                  --");
            Console.WriteLine("-------------------------------------");


            Console.WriteLine(" DIRECT ASSIGMENT");

            EditBox editBox_1      = new EditBox();
            IControl control_1     = editBox_1;
            IDataBound dataBound_1 = editBox_1;

            control_1.Paint();
            dataBound_1.Bind(new Binder());

            Console.WriteLine(" DYNAMIC TYPE CASTING ");

            object editBox_2       = new EditBox();
            IControl control_2     = (IControl)editBox_2;
            IDataBound dataBound_2 = (IDataBound)editBox_2;

            control_2.Paint();
            dataBound_2.Bind(new Binder());

            Console.WriteLine(" INTERFACE METHOD ACCESS ");

            EditBox editBox_3  = new EditBox();
            // editBox_3.Paint();  // Error, no such method 
            // editBox_3.Bind();   // Error, no such method 

            Console.WriteLine("-------------------------------------");

            Console.ReadLine();
        }
        // 1.10 Enum 
        internal static void EnumExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.10 ENUM                       --");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine(" USING LITERALS ");
            TColor c_1 = TColor.Red;
            TestColor.Print(c_1);
            TestColor.Print(TColor.Blue);


            Console.WriteLine(" USING NUMBERS ");

            TColor c_2 = 0;                 // Color.Red
            int i      = (int)TColor.Green; // int i = 1; 
            TColor c_3 = (TColor)2;         // Color c = Color.Blue; 

            Console.WriteLine("{0},{1},{2}",c_2,i,c_3);

            Console.WriteLine("-------------------------------------");

            Console.ReadLine();

        }
        // 1.11 Delegates
        internal static void DelegateExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.11 DELEGATES                  --");
            Console.WriteLine("-------------------------------------");

            //  INITIALIZE 

            const double MULTIPLY_FACTOR = 2.0;
            double[] a                   = { 0.0, 0.5, 1.0 };

            for (int i = 0; i < a.Length; i++) Console.WriteLine("Array {0} : {1}",i, a[i]);

            // STATIC METHODS 
            double[] squares = MultiplierProxy.Apply(a, MultiplierProxy.Square);

            for (int i = 0; i < a.Length; i++) Console.WriteLine("Squares {0} : {1}", a[i], squares[i]);

            double[] sines   = MultiplierProxy.Apply(a, System.Math.Sin);

            for (int i = 0; i < a.Length; i++) Console.WriteLine("Sines   {0} : {1}", a[i], sines[i]);

            // INSTANCES METHODS 
            Multiplier m     = new Multiplier(MULTIPLY_FACTOR);
            double[] doubles = MultiplierProxy.Apply(a, m.Multiply);

            for (int i = 0; i < a.Length; i++) Console.WriteLine("Multiply by Factor {0}, {1} : {2}", MULTIPLY_FACTOR, a[i], doubles[i]);

            // ANONYMOUS / INLINE FUNCTIONS
            double[] doublesInline = MultiplierProxy.Apply(a, (double x) => x * x* x);

            for (int i = 0; i < a.Length; i++) Console.WriteLine("Cube {0} : {1} ", a[i], doublesInline[i]);

            Console.WriteLine("-------------------------------------");

            Console.ReadLine();

        }
        // 1.12 Attributes
        internal static void AttributesExample()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-- 1.12 ATTRIBUTES                 --");
            Console.WriteLine("-------------------------------------");

            AttributeProxy.ShowHelp(typeof(Widget));
            AttributeProxy.ShowHelp(typeof(Widget).GetMethod("Display"));

            Console.WriteLine("-------------------------------------");

            Console.ReadLine();
        }
    }
}
