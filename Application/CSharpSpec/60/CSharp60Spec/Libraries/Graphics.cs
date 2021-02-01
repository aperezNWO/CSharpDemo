using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp60Spec.Libraries
{
    /// <summary>Class <c>Point</c> models a point in a two-dimensional plane.
    /// </summary>
    public class Point
    {
        /// <summary>Instance variable <c>x</c> represents the point's
        /// x-coordinate.</summary>
        private int x;
        /// <summary>Instance variable <c>y</c> represents the point's
        /// y-coordinate.</summary>
        private int y;
        /// <value>Property <c>X</c> represents the point's x-coordinate.</value>
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        /// <value>Property <c>Y</c> represents the point's y-coordinate.</value>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        /// <summary>This constructor initializes the new Point to
        /// (0,0).</summary>
        public Point() : this(0, 0) { }
        /// <summary>This constructor initializes the new Point to
        /// (<paramref name="xor"/>,<paramref name="yor"/>).</summary>
        /// <param><c>xor</c> is the new Point's x-coordinate.</param>
        /// <param><c>yor</c> is the new Point's y-coordinate.</param>
        public Point(int xor, int yor)
        {
            X = xor;
            Y = yor;
        }
        /// <summary>This method changes the point's location to
        /// the given coordinates.</summary>
        /// <param><c>xor</c> is the new x-coordinate.</param>
        /// <param><c>yor</c> is the new y-coordinate.</param>
        /// <see cref="Translate"/>
        public void Move(int xor, int yor)
        {
            X = xor;
            Y = yor;
        }
        /// <summary>This method changes the point's location by
        /// the given x- and y-offsets.
        /// <example>For example:
        /// <code>
        /// Point p = new Point(3,5);
        /// p.Translate(-1,3);
        /// </code>
        /// results in <c>p</c>'s having the value (2,8).
        /// </example>
        /// </summary>
        /// <param><c>xor</c> is the relative x-offset.</param>
        /// <param><c>yor</c> is the relative y-offset.</param>
        /// <see cref="Move"/>
        public void Translate(int xor, int yor)
        {
            //
            int xant = xor;
            int yant = yor;
            //
            X += xor;
            Y += yor;
            //
            Console.WriteLine(@"Translating Point from [{0},{1}] to [{2},{3}] ",xant,yant,X,Y);
        }
        /// <summary>This method determines whether two Points have the same
        /// location.</summary>
        /// <param><c>o</c> is the object to be compared to the current object.
        /// </param>
        /// <returns>True if the Points have the same location and they have
        /// the exact same type; otherwise, false.</returns>
        /// <seealso cref="operator=="/>
        /// <seealso cref="operator!="/>
        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (this == o)
            {
                return true;
            }
            if (GetType() == o.GetType())
            {
                Point p = (Point)o;
                return (X == p.X) && (Y == p.Y);
            }
            return false;
        }
        /// <summary>Report a point's location as a string.</summary>
        /// <returns>A string representing a point's location, in the form (x,y),
        /// without any leading, training, or embedded whitespace.</returns>
        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
        /// <summary>This operator determines whether two Points have the same
        /// location.</summary>
        /// <param><c>p1</c> is the first Point to be compared.</param>
        /// <param><c>p2</c> is the second Point to be compared.</param>
        /// <returns>True if the Points have the same location and they have
        /// the exact same type; otherwise, false.</returns>
        /// <seealso cref="Equals"/>
        /// <seealso cref="operator!="/>
        public static bool operator ==(Point p1, Point p2)
        {
            if (p1 is null || p2 is null)
            {
                return false;
            }
            if (p1.GetType() == p2.GetType())
            {
                return (p1.X == p2.X) && (p1.Y == p2.Y);
            }
            return false;
        }
        /// <summary>This operator determines whether two Points have the same
        /// location.</summary>
        /// <param><c>p1</c> is the first Point to be compared.</param>
        /// <param><c>p2</c> is the second Point to be compared.</param>
        /// <returns>True if the Points do not have the same location and the
        /// exact same type; otherwise, false.</returns>
        /// <seealso cref="Equals"/>
        /// <seealso cref="operator=="/>
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        /// <summary>This is the entry point of the Point class testing
        /// program.
        /// <para>This program tests each method and operator, and
        /// is intended to be run after any non-trivial maintenance has
        /// been performed on the Point class.</para></summary>
        public void Run()
        {
            // VISUAL STUDIO AUTOCOMPLETE/HOVER REFLECTS CODE COMMENTS
            this.Translate(xor : 10, yor : 10);
        }
    }
}
