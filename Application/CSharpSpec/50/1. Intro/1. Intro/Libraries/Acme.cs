using System;

// 1.2 Program Structure
namespace Acme.Collections
{
    public class Stack
    {
        Entry top;

        public void Push(object data)
        {
            top = new Entry(top, data);
        }

        public object Pop()
        {
            if (top == null) throw new InvalidOperationException();
            object result = top.data;
            top           = top.next;
            return result; 
        }

        class Entry
        {
            public Entry  next;
            public object data;

            public Entry(Entry next, object data)
            {
                this.next = next;
                this.data = data; 
            }    
        }
    }
}

namespace Acme.Utilities
{
    internal struct ParameterExample
    {
        internal static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        internal static void Divide(int x, int y, out int result, out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }
    }

    internal class Entity
    {
        static int nextSerialNo;
        int serialNo;

        public Entity()
        {
            serialNo = nextSerialNo++;
        }
        public int GetSerialNo()
        {
            return serialNo;
        }
        public static int GetNextSerialNo()
        {
            return nextSerialNo;
        }
        public static void SetNextSerialNo(int value)
        {
            nextSerialNo = value;
        }
    }

    internal class OverloadingExample
    {
        static void F()
        {
            Console.WriteLine("F()");
        }

        static void F(object x)
        {
            Console.WriteLine("F(object)");
        }

        static void F(int x)
        {
            Console.WriteLine("F(int)");
        }

        static void F(double x)
        {
            Console.WriteLine("F(double)");
        }

        static void F<T>(T x)
        {
            Console.WriteLine("F<T>(T)");
        }

        static void F(double x, double y)
        {
            Console.WriteLine("F(double, double)");
        }

        public static void Run()
        {
            F();                    // Invokes F()
            F(1);                   // Invokes F(int)
            F(1.0);             // Invokes F(double)
            F("abc");           // Invokes F(object)
            F((double)1);       // Invokes F(double)
            F((object)1);       // Invokes F(object)
            F<int>(1);          // Invokes F<T>(T)
            F(1, 1);                // Invokes F(double, double)	}
        }
    }

    public class ListExample<T> : IDisposable
    {
        // Constant
        public const int defaultCapacity = 4;
        // Fields
        T[] items;
        int count;
        // Static Constructor 
        static ListExample()
        {
            Console.WriteLine("-- Static Constructor.");
            Console.WriteLine("-- Always invoked where no parameters on constructor or inherited constructor.");
        }
        //
        public ListExample()
        {
            this.Changed += new EventHandler(ListChanged);
            items        = new T[defaultCapacity];
            Console.WriteLine("--- Instance Constructor, no parameters.");
        }
        // Instance Constructors
        public ListExample(int capacity = defaultCapacity)
        {
            // 
            items = new T[capacity];
            Console.WriteLine("---- Instance Constructor with parameters.");
        }
        // Destructor
        ~ListExample()
        {
            Console.WriteLine("Calling Destructor.");
        }
        // 
        public void Dispose()
        {
            Console.WriteLine("Calling dispose method.");
        }
        // Properties
        public int Count
        {
            get {

                Console.WriteLine("Count : {0}",count);

                return count;

            }
        }
        // Properties
        public int Capacity
        {
            get
            {
                Console.WriteLine("Capacity : {0}", items.Length);

                return items.Length;
            }
            set
            {
                if (value < count) value = count;
                if (value != items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(items, 0, newItems, 0, count);
                    items = newItems;
                }
            }
        }
        // Indexer
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
                OnChanged();
            }
        }
        // Methods
        public void Add(T item)
        {
            if (count == Capacity) Capacity = count * 2;
            items[count] = item;
            count++;
            OnChanged();
        }
        //
        protected virtual void OnChanged()
        {
            if (Changed != null) Changed(this, EventArgs.Empty);
        }
        //
        public override bool Equals(object other)
        {
            return Equals(this, other as ListExample<T>);
        }
        //
        static bool Equals(ListExample<T> a, ListExample<T> b)
        {
            //if (a == null) return b == null;
            //if (b == null || a.count != b.count) return false;

            if (object.Equals(a, null)) return object.Equals(b, null);
            if (object.Equals(b, null) || (a.count != b.count)) return false;

            for (int i = 0; i < a.count; i++)
            {
                if (!object.Equals(a.items[i], b.items[i]))
                {
                    return false;
                }
            }
            return true;
        }
        // Event
        public event EventHandler Changed;
        // Delegate
        void ListChanged(object sender, EventArgs e)
        {
            Console.WriteLine("List changed. Count : {0}",this.count);
        }
        // Operators
        public static bool operator ==(ListExample<T> a, ListExample<T> b)
        {
            return Equals(a, b);
        }
        //
        public static bool operator !=(ListExample<T> a, ListExample<T> b)
        {
            return !Equals(a, b);
        }
    }
    //
    public class InheritedListExample :  ListExample<object>
    {
        public InheritedListExample(int aCapacity) : base(aCapacity)
        {
            // INSTANCE CONSTRUCTORS ARE NOT INHERITED
            // MUST BE CALLED SPLICITLY
            Console.WriteLine("----- Inherited Class.");
            Console.WriteLine("----- Calling base constructor with parameters");
        }

        public InheritedListExample() : base(defaultCapacity)
        {
            // INSTANCE CONSTRUCTORS ARE NOT INHERITED
            // MUST BE CALLED SPLICITLY
            Console.WriteLine("------ Inherited Class.");
            Console.WriteLine("------ Calling base constructor, no parameters");
        }
    }
    //
    public class DummyClassNoInstanceConstructor
    {
        // STATIC CONSTRUCTOR ARE CALLED JUST ONCE AMONG MULTIPLE INVOCATION
        static DummyClassNoInstanceConstructor()
        {
            Console.WriteLine("- Static Constructor");
        }
    }
}