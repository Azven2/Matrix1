// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Azven.com">
//   (C) Steven Digby
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Matrix1
{
    using System;
    using System.Drawing;

    /// <summary>The program.</summary>
    public class Program
    {
        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var aa = new double[2, 3];
            aa[0, 0] = 1;
            aa[0, 1] = 2;
            aa[0, 2] = 3;
            aa[1, 0] = 4;
            aa[1, 1] = 5;
            aa[1, 2] = 6;

            var bb = new double[3, 2];
            bb[0, 0] = 7;
            bb[0, 1] = 8;
            bb[1, 0] = 9;
            bb[1, 1] = 10;
            bb[2, 0] = 11;
            bb[2, 1] = 12;

            var bi = new int[3, 2];
            bi[0, 0] = 7;
            bi[0, 1] = 8;
            bi[1, 0] = 9;
            bi[1, 1] = 10;
            bi[2, 0] = 11;
            bi[2, 1] = 12;

            var pp = new Point[4];
            pp[0] = new Point(6, 20);
            pp[1] = new Point(20, 6);
            pp[2] = new Point(34, 20);
            pp[3] = new Point(20, 34);

            var ss = new double[3, 3];
            ss[0, 0] = 6;
            ss[0, 1] = 7;
            ss[0, 2] = 8;
            ss[1, 0] = 9;
            ss[1, 1] = 10;
            ss[1, 2] = 11;
            ss[2, 0] = 12;
            ss[2, 1] = 13;            
            ss[2, 2] = 14;

            var ii = ss.IdentityMatrix();

            var e1 = new double[3, 3];
            e1[0, 0] = -3;
            e1[0, 1] = 2;
            e1[0, 2] = -5;
            e1[1, 0] = -1;
            e1[1, 1] = 0;
            e1[1, 2] = -2;
            e1[2, 0] = 3;
            e1[2, 1] = -4;
            e1[2, 2] = 1;

            var s1 = new double[2, 2];
            s1[0, 0] = 3;
            s1[0, 1] = 1;
            s1[1, 0] = 5;
            s1[1, 1] = 2;

            var s2 = new double[4, 4];
            s2[0, 0] = 5;
            s2[0, 1] = -2;
            s2[0, 2] = 2;
            s2[0, 3] = 7;
            s2[1, 0] = 1;
            s2[1, 1] = 0;
            s2[1, 2] = 0;
            s2[1, 3] = 3;
            s2[2, 0] = -3;
            s2[2, 1] = 1;
            s2[2, 2] = 5;
            s2[2, 3] = 0;
            s2[3, 0] = 3;
            s2[3, 1] = -1;
            s2[3, 2] = -9;
            s2[3, 3] = 4;

            Console.WriteLine("A = ");
            MatrixDisplay(aa);
            Console.WriteLine("B = ");
            MatrixDisplay(bb);

            Console.WriteLine("S = ");
            MatrixDisplay(ss);

            Console.WriteLine("S1 = ");
            MatrixDisplay(s1);

            var rslt = aa.MultiplyMatrix(bb);
            Console.WriteLine("A·B = ");
            MatrixDisplay(rslt);

            rslt = bb.MultiplyMatrix(aa);
            Console.WriteLine("B·A = ");
            MatrixDisplay(rslt);

            rslt = bb.Transpose(); 
            Console.WriteLine("Transpose of B = ");
            MatrixDisplay(rslt);

            Console.WriteLine(string.Empty);

            Console.WriteLine("B is " +
                (bb.IsIdentity() ? string.Empty : "not ") + "an identity matrix");

            Console.WriteLine("I = ");
            MatrixDisplay(ii);
            Console.WriteLine("I is " +
                (ii.IsIdentity() ? string.Empty : "not ") + "an identity matrix");

            Console.WriteLine(string.Empty);

            Console.WriteLine("Rotate clockwise P by 45 degrees, about a point at (6, 20); P = ");
            var pr = pp.RotateByDegrees(-45, new Point(6, 20));
            Console.WriteLine("P1 was {0} now {1} ", pp[0], pr[0]);
            Console.WriteLine("P2 was {0} now {1} ", pp[1], pr[1]);
            Console.WriteLine("P3 was {0} now {1} ", pp[2], pr[2]);
            Console.WriteLine("P4 was {0} now {1} ", pp[3], pr[3]);
            
            Console.WriteLine(string.Empty);

            Console.WriteLine("Are these two matrixes equal?");
            MatrixDisplay(bb);
            Console.WriteLine("... and ...");
            MatrixDisplay(bi);
            Console.WriteLine(bb.IsEqual(bi) ? "Yes" : "No");

            Console.WriteLine(string.Empty);

            try
            {
                Console.WriteLine("Determinant of S = {0}", ss.Determinant());

                Console.WriteLine("The inverse matrix of A = ");
                MatrixDisplay(aa.InverseMatrix());            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);    
            }


            Console.WriteLine(string.Empty);

            Console.WriteLine("The inverse matrix of S1 = ");
            MatrixDisplay(s1.InverseMatrix());

            Console.WriteLine(s1.InverseMatrix().MultiplyMatrix(s1).IsIdentity() ? "verified." : "fail.");
            
            Console.WriteLine(string.Empty);

            //Console.WriteLine("The inverse matrix of S = ");
            //MatrixDisplay(ss.InverseMatrix());

            // Console.WriteLine(ss.InverseMatrix().MultiplyMatrix(ss).IsIdentity() ? "verified." : "fail.");

            Console.WriteLine(string.Empty);

            Console.WriteLine("The matrix E = ");
            MatrixDisplay(e1);
            Console.WriteLine("... has an adjunt, adj(E), = ");
            MatrixDisplay(e1.Adjunct());

            Console.WriteLine(string.Empty);

            Console.WriteLine("The matrix S2 = ");
            MatrixDisplay(s2);

            //Console.WriteLine("The minor matrix S2(0,0) = ");
            //MatrixDisplay(s2.SubMatrix(0, 0));

            //Console.WriteLine("The cofactor matrix S2(0,0) = ");
            //MatrixDisplay(s2.SubMatrix(0, 0).CoFactorMatrix());

            //Console.WriteLine("The minor matrix S2(0,1) = ");
            //MatrixDisplay(s2.SubMatrix(0, 1));

            //Console.WriteLine("The cofactor matrix S2(0,1) = ");
            //MatrixDisplay(s2.SubMatrix(0, 1).CoFactorMatrix());

            Console.WriteLine("   adj(S2), = ");
            MatrixDisplay(s2.Adjunct());

            Console.WriteLine("   det(S2), = {0}", s2.Determinant());

            Console.WriteLine(string.Empty);

            Console.WriteLine("The inverse matrix of S2 = ");
            MatrixDisplay(s2.InverseMatrix());
            MatrixDisplay(s2.InverseMatrix().MultiplyMatrix(s2));
            Console.WriteLine(s2.InverseMatrix().MultiplyMatrix(s2).IsIdentity() ? "verified." : "fail.");

            Console.ReadLine();
        }

        /// <summary>The matrix display.</summary>
        /// <typeparam name="T">Type ro return.</typeparam>
        /// <param name="arrayToDisplay">The array to display.</param>
        private static void MatrixDisplay<T>(T[,] arrayToDisplay)
        {
            // /          \     /  7  8 \     /       \
            // |  1  2  3 |  x  |  9 10 |  =  | 58 ?? |
            // |  4  5  6 |     | 11 12 |     | ?? ?? |
            // \          /     \       /     \       /
            var rowUpperBound = arrayToDisplay.GetUpperBound(0);
            var colUpperBound = arrayToDisplay.GetUpperBound(1);

            for (var r = 0; r <= rowUpperBound; r++)
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write(r == 0 ? "    /" : (r == rowUpperBound ? "    \\" : "    |"));
                Console.ForegroundColor = ConsoleColor.White; 
                for (var c = 0; c <= colUpperBound; c++)
                {
                    Console.Write(arrayToDisplay[r, c].ToString().PadLeft(5));
                }
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(r == 0 ? " \\" : (r == rowUpperBound ? " /" : " |"));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
