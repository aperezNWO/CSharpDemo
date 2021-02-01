using System;
using System.Collections;

namespace _1.Intro.Libraries
{
    public abstract class Math
    {
        public abstract double Evaluate(Hashtable vars);
    }

    public class Constant : Math
    {
        double value;
        public Constant(double value)
        {
            this.value = value;
        }
        public override double Evaluate(Hashtable vars)
        {
            return value;
        }
    }

    public class VariableReference : Math
    {
        string name;
        public VariableReference(string name)
        {
            this.name = name;
        }
        public override double Evaluate(Hashtable vars)
        {
            object value = vars[name];
            if (value == null)
            {
                throw new Exception("Unknown variable: " + name);
            }
            return Convert.ToDouble(value);
        }
    }

    public class Operation : Math
    {
        Math left;
        char op;
        Math right;

        public Operation(Math left, char op, Math right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }

        public override double Evaluate(Hashtable vars)
        {
            double x = left.Evaluate(vars);
            double y = right.Evaluate(vars);
            switch (op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
            }
            throw new Exception("Unknown operator");
        }
    }

    delegate double Function(double x);

    class Multiplier
    {
        double factor;

        public Multiplier(double factor)
        {
            this.factor = factor;
        }

        public double Multiply(double x)
        {
            return x * factor;
        }
    }

    class MultiplierProxy
    {
        public static double Square(double x)
        {
            return x * x;
        }

        public static double[] Apply(double[] a, Function f)
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
            return result;
        }
    }
}
