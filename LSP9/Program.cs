
using System;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace _09_OverloadOperators
{
    class Square
    {
        private int a;

        public int A
        {
            get { return a; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Side cannot be negative!");

                a = value;
            }
        }

        public Square() : this(0) { }

        public Square(int a)
        {
            A = a;
        }

        public override string ToString()
        {
            return $"Square: A = {A}";
        }

        public override bool Equals(object obj)
        {
            return obj is Square square && A == square.A;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode();
        }

        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }

        public static Square operator --(Square s)
        {
            if (s.A > 0)
                s.A--;

            return s;
        }

        public static Square operator +(Square s1, Square s2)
        {
            return new Square(checked(s1.A + s2.A));
        }

        public static Square operator -(Square s1, Square s2)
        {
            return new Square(checked(s1.A - s2.A));
        }

        public static Square operator *(Square s1, Square s2)
        {
            return new Square(checked(s1.A * s2.A));
        }

        public static Square operator /(Square s1, Square s2)
        {
            if (s2.A == 0)
                throw new DivideByZeroException();

            return new Square(s1.A / s2.A);
        }

        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }

        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }

        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }

        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A <= s2.A;
        }

        public static bool operator ==(Square s1, Square s2)
        {
            if (ReferenceEquals(s1, s2))
                return true;

            if (s1 is null || s2 is null)
                return false;

            return s1.Equals(s2);
        }

        public static bool operator !=(Square s1, Square s2)
        {
            return !(s1 == s2);
        }

        
        public static bool operator true(Square s)
        {
            return s != null && s.A != 0;
        }

        public static bool operator false(Square s)
        {
            return s == null || s.A == 0;
        }

        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.A, s.A);
        }

        public static implicit operator int(Square s)
        {
            return checked(s.A * s.A);
        }
    }


    class Rectangle
    {
        private int a;
        private int b;

        public int A
        {
            get { return a; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Side A cannot be negative!");

                a = value;
            }
        }

        public int B
        {
            get { return b; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Side B cannot be negative!");

                b = value;
            }
        }

        public Rectangle() : this(0, 0) { }

        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }

        public override string ToString()
        {
            return $"Rectangle: A = {A}, B = {B}";
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
                   A == rectangle.A &&
                   B == rectangle.B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }

        public static Rectangle operator ++(Rectangle r)
        {
            r.A++;
            r.B++;
            return r;
        }

        public static Rectangle operator --(Rectangle r)
        {
            if (r.A > 0)
                r.A--;

            if (r.B > 0)
                r.B--;

            return r;
        }

        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(
                checked(r1.A + r2.A),
                checked(r1.B + r2.B));
        }

        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(
                checked(r1.A - r2.A),
                checked(r1.B - r2.B));
        }

        public static Rectangle operator *(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(
                checked(r1.A * r2.A),
                checked(r1.B * r2.B));
        }

        public static Rectangle operator /(Rectangle r1, Rectangle r2)
        {
            if (r2.A == 0 || r2.B == 0)
                throw new DivideByZeroException();

            return new Rectangle(
                r1.A / r2.A,
                r1.B / r2.B);
        }
        public static bool operator >(Rectangle r1, Rectangle r2) 
        {
            return r1.A + r1.B > r2.A + r2.B;
        }

        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B < r2.A + r2.B;
        }

        public static bool operator >=(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B >= r2.A + r2.B;
        }

        public static bool operator <=(Rectangle r1, Rectangle r2)
        {
            return r1.A + r1.B <= r2.A + r2.B;
        }

        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            if (ReferenceEquals(r1, r2))
                return true;

            if (r1 is null || r2 is null)
                return false;

            return r1.Equals(r2);
        }

        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }

        public static bool operator true(Rectangle r)
        {
            return r != null && r.A != 0 && r.B != 0;
        }

        public static bool operator false(Rectangle r)
        {
            return r == null || r.A == 0 || r.B == 0;
        }

        public static explicit operator Square(Rectangle r)
        {
            return new Square(r.A);
        }

        public static explicit operator int(Rectangle r)
        {
            return checked(r.A * r.B);
        }

       
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Square:");

                Console.Write("Enter side A: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Square s1 = new Square(a);

                Console.WriteLine("\nEnter second Square:");

                Console.Write("Enter side A: ");
                int a2 = Convert.ToInt32(Console.ReadLine());

                Square s2 = new Square(a2);

                Console.WriteLine("\nEnter Rectangle:");

                Console.Write("Enter side A: ");
                int b = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter side B: ");
                int c = Convert.ToInt32(Console.ReadLine());

                Rectangle r1 = new Rectangle(b, c);

                Console.WriteLine("\nEnter second Rectangle:");

                Console.Write("Enter side A: ");
                int b2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter side B: ");
                int c2 = Convert.ToInt32(Console.ReadLine());

                Rectangle r2 = new Rectangle(b2, c2);

                Console.WriteLine("\nSQUARES:");
                Console.WriteLine(s1);
                Console.WriteLine(s2);

                Console.WriteLine("\nRECTANGLES:");
                Console.WriteLine(r1);
                Console.WriteLine(r2);

                Console.WriteLine("\nSQUARE OPERATORS:");

                Console.WriteLine("s1 + s2 = " + (s1 + s2));
                Console.WriteLine("s1 - s2 = " + (s1 - s2));
                Console.WriteLine("s1 * s2 = " + (s1 * s2));
                Console.WriteLine("s1 / s2 = " + (s1 / s2));

                Console.WriteLine("\ns1 > s2: " + (s1 > s2));
                Console.WriteLine("s1 < s2: " + (s1 < s2));
                Console.WriteLine("s1 >= s2: " + (s1 >= s2));
                Console.WriteLine("s1 <= s2: " + (s1 <= s2));

                Console.WriteLine("s1 == s2: " + (s1 == s2));
                Console.WriteLine("s1 != s2: " + (s1 != s2));

                s1++;
                Console.WriteLine("s1++: " + s1);

                s1--;
                Console.WriteLine("s1--: " + s1);

                if (s1)
                    Console.WriteLine("Square is true");
                else
                    Console.WriteLine("Square is false");

                Console.WriteLine("\nRECTANGLE OPERATORS:");

                Console.WriteLine("r1 + r2 = " + (r1 + r2));
                Console.WriteLine("r1 - r2 = " + (r1 - r2));
                Console.WriteLine("r1 * r2 = " + (r1 * r2));
                Console.WriteLine("r1 / r2 = " + (r1 / r2));

                Console.WriteLine("\nr1 > r2: " + (r1 > r2));
                Console.WriteLine("r1 < r2: " + (r1 < r2));
                Console.WriteLine("r1 >= r2: " + (r1 >= r2));
                Console.WriteLine("r1 <= r2: " + (r1 <= r2));

                Console.WriteLine("r1 == r2: " + (r1 == r2));
                Console.WriteLine("r1 != r2: " + (r1 != r2));

                r1++;
                Console.WriteLine("r1++: " + r1);

                r1--;
                Console.WriteLine("r1--: " + r1);

                if (r1)
                    Console.WriteLine("Rectangle is true");
                else
                    Console.WriteLine("Rectangle is false");

                Console.WriteLine("\nTYPE CONVERSIONS:");

                Rectangle r3 = s1;
                Console.WriteLine("Square to Rectangle: " + r3);

                Square s3 = (Square)r1;
                Console.WriteLine("Rectangle to Square: " + s3);

                int squareArea = s1;
                Console.WriteLine("Square area: " + squareArea);

                int rectangleArea = (int)r1;
                Console.WriteLine("Rectangle area: " + rectangleArea);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

}

