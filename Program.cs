using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace solve_matrix
{
    class Program
    {
       

        public static void PrintCharMatrix(char[] s)
        {
            Console.Write("{");
            for (int i = 0; i < s.Length; i++)
            {

                Console.Write(s[i]);
                if (i < (s.Length - 1)) Console.Write(",");//if its the last element dont put comma
            }
            Console.WriteLine("}");
        }

        public static void printmatrix(double[,] cords)
        {
            //find biggest number to get how many spaces needed
            double biggestnumber = 0;
            for (int i = 0; i < cords.GetLength(0); i++)
            {
                for (int j = 0; j < cords.GetLength(1); j++)
                {

                    if (cords[i, j] > biggestnumber) biggestnumber = cords[i, j];


                }
            }

            int bnumberlength = (int)Math.Log10(biggestnumber) + 1;



            for (int i = 0; i < cords.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < cords.GetLength(1); j++)
                {
                    int diff = bnumberlength - ((int)Math.Log10(cords[i, j]) + 1);
                    Console.Write(cords[i, j]);
                    for (int k = 0; k < diff; k++) { Console.Write(" "); }//space offset to align w/ biggestnum

                    if (j < (cords.GetLength(1) - 1)) Console.Write(" ");//if its the last element dont put comma
                }
                Console.WriteLine("}");


            }

            Console.WriteLine();
        }

        public static void printintmatrix(int[,] cords)
        {
            //find biggest number to get how many spaces needed
            double biggestnumber = 0;
            for (int i = 0; i < cords.GetLength(0); i++)
            {
                for (int j = 0; j < cords.GetLength(1); j++)
                {

                    if (cords[i, j] > biggestnumber) biggestnumber = cords[i, j];


                }
            }

            int bnumberlength = (int)Math.Log10(biggestnumber) + 1;



            for (int i = 0; i < cords.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < cords.GetLength(1); j++)
                {
                    int diff = bnumberlength - ((int)Math.Log10(cords[i, j]) + 1);
                    Console.Write(cords[i, j]);
                    for (int k = 0; k < diff; k++) { Console.Write(" "); }//space offset to align w/ biggestnum

                    if (j < (cords.GetLength(1) - 1)) Console.Write(" ");//if its the last element dont put comma
                }
                Console.WriteLine("}");


            }

            Console.WriteLine();
        }

        public static int pow(int number, int raisedto)
        {
            if (raisedto == 0)
            {
                return 1;
            }
            int result = number;
            for (int i = 0; i < raisedto - 1; i++)
            {
                result = result * number;
            }
            return result;
        }

        public static double getdeterminit(double[,] a)
        {
            double determinit = 0;

            if (a.GetLength(0) > 2)
            {

                for (int j = 0; j < a.GetLength(0); j++)
                {

                    int countk = 0;
                    int countl = 0;
                    double[,] b = new double[a.GetLength(0) - 1, a.GetLength(1) - 1];


                    for (int k = 0; k < a.GetLength(0); k++)
                    {
                        for (int l = 0; l < a.GetLength(1); l++)
                        {

                            //ignore the ith row and jth col
                            if ((k != 0) && (l != j))
                            {

                                //if 4x4 then we need 3x3 so greatest index=2
                                if (countl > (a.GetLength(0) - 2))
                                {
                                    countk = countk + 1;
                                    countl = 0;

                                }

                                b[countk, countl] = a[k, l];
                                countl = countl + 1;

                            }

                        }

                    }
                    printmatrix(b);


                    determinit = determinit + (pow(-1, j) * a[0, j] * getdeterminit(b)); // (-1^j) determinit needs to alternate + - +...


                }
                return determinit;

            }
            determinit = (a[0, 0] * a[1, 1]) - (a[0, 1] * a[1, 0]);
            return determinit;

        }

        public static double[,] getinverse(double[,] a)
        {


            double[,] inverse = new double[a.GetLength(0), a.GetLength(1)];
            double determinita = 1 / getdeterminit(a);



            Console.WriteLine("matrix a is ......");
            printmatrix(a);
            Console.WriteLine(a.GetLength(0) > 2);

            if (a.GetLength(0) > 2)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {

                        int countk = 0;
                        int countl = 0;
                        double[,] b = new double[a.GetLength(0) - 1, a.GetLength(1) - 1];

                        for (int k = 0; k < a.GetLength(0); k++)
                        {
                            for (int l = 0; l < a.GetLength(1); l++)
                            {
                                //ignore the ith row and jth col
                                if ((k != i) && (l != j))
                                {
                                    //if 4x4 then we need 3x3 so greatest index=2
                                    if (countl > (a.GetLength(0) - 2))
                                    {
                                        countk = countk + 1;
                                        countl = 0;
                                    }
                                    b[countk, countl] = a[k, l];
                                    countl = countl + 1;
                                }
                            }
                        }


                        Console.WriteLine("get determinit of....");
                        printmatrix(b);
                        inverse[i, j] = determinita * (pow(-1, (i + j))) * getdeterminit(b);


                    }
                }




                double[,] transpose = new double[a.GetLength(0), a.GetLength(1)];

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        transpose[i, j] = inverse[j, i];
                    }
                }

                //transpose matrix

                return transpose;
            }

            /*
            inverse of
            [a,b] --> (1/determinit) [d,-b]
            [c,d]                    [-c,a]

            */

            inverse[0, 0] = a[1, 1];
            inverse[1, 1] = a[0, 0];

            inverse[1, 0] = -a[1, 0];
            inverse[0, 1] = -a[0, 1];

            return inverse;

        }

        public static double[,] matrixmult(double[,] a, double[,] b)
        {
            int countx = 0;
            int county = 0;
            double[,] result = new double[a.GetLength(0), b.GetLength(1)];

            Console.WriteLine(a.GetLength(0));
            for (int i = 0; i < a.GetLength(0); i++)//for each row in matrix a 
            {

                for (int k = 0; k < b.GetLength(1); k++)//for each col in matrix b
                {
                    double sum = 0;
                    for (int j = 0; j < a.GetLength(1); j++)//for each element in each row of a
                    {
                        sum = sum + (a[i, j] * b[j, k]);
                        Console.WriteLine("sum + a[i,j] * b[j,k]= " + sum + " + " + a[i, j] + " * " + b[j, k]);
                    }
                    if (countx > (b.GetLength(1) - 1))
                    {
                        county = county + 1;
                        countx = 0;
                    }
                    result[county, countx] = sum;
                    countx = countx + 1;
                }



            }

            return result;
        }

        public static double[,] solve(String equ)//"3x+404y+5z=65, 2x+y+3z=20 "
        {
            char[] chars = {'a','b','c','d','e','f','g',
                    'h','i','j','k','l','m','n','o','p','q','r',
                    's','t','u','v','w','x','y','z','A','B','C',
                    'D','E','F','G','H','I','J','K','L','M','N',
                    'O','P','Q','R','S','T','U','V','W','X','Y','Z'};

            
            int index = 0;
            int varcount = 0;
            while (equ[index] != ',')//find number of variabls in equation
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (equ[index] == chars[i])
                    {
                        varcount++;
                    }

                }
                index++;
            }

            char[] varmatrix = new char[varcount];
            int matrixindex = 0;
            index = 0;

            while (equ[index] != ',')//make array of variables in equation
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (equ[index] == chars[i])
                    {
                        varmatrix[matrixindex] = equ[index];
                        matrixindex++;
                    }
                }

                index++;
            }

            //***************************//

            int rowcount = 0;
            int[,] coefficientmatrix = new int[varcount, varcount];

            for (int i = 0; i < varmatrix.Length; i++)//for each of the variables
            {

                Console.WriteLine(varmatrix[i]);
                rowcount = 0;


                for (int j = 0; j < equ.Length; j++)//go over the equations and get the coefficients for the selected variable
                {

                    if (varmatrix[i] == equ[j])
                    {

                        int index1 = j;
                        String coefficient = "";

                        //check from right and left if there is number

                        //make sure adding/subtracting from index1 doesnt go out of bounds

                   
                        if ((!((index1 + 1) > (equ.Length - 1))) && char.IsNumber(equ[index1 + 1]))
                        // if it is not the case that (index1+1) is greater than max index AND if right char is a number

                        {//right
                            while (char.IsNumber(equ[index1 + 1]))
                            {

                                index1++;
                                coefficient = coefficient + equ[index1];

                                if ((index1 + 1) > (equ.Length - 1)) break;// a.Length=2 --> a[0],a[1]

                            }
                        }
                        else if ((!((index1 - 1) < 0)) && char.IsNumber(equ[index1 - 1]))
                        // if it is not the case that (index1-1) is less than min index AND if left char is a number

                        { //left

                            while (char.IsNumber(equ[index1 - 1]))
                            {

                                index1--;
                                coefficient = equ[index1] + coefficient;

                                if ((index1 - 1) < 0) break;
                            }
                        }
                        else coefficient = "1";
                    

                        Console.WriteLine("coefficient = " + coefficient);

                        coefficientmatrix[rowcount, i] = Int32.Parse(coefficient);
                        rowcount++;

                    }
                }
            }





            int[,] numbermatrix = new int[varcount, 1];
            rowcount = 0;
            for (int i = 0; i < equ.Length; i++)
            {//get number matrix
                if (equ[i] == '=')
                {
                    int index1 = i;
                    String number = "";

                    if (char.IsNumber(equ[index1 + 1]))
                    {//right
                        while (char.IsNumber(equ[index1 + 1]))
                        {

                            index1++;
                            number = number + equ[index1];

                            if ((index1 + 1) > (equ.Length - 1)) break;
                        }
                    }
                    else if (char.IsNumber(equ[index1 - 1]))
                    {//left
                        while (char.IsNumber(equ[index1 - 1]))
                        {
                            index1--;
                            number = equ[index1] + number;

                            if ((index1 - 1) < 0) break;
                        }
                    }
                    numbermatrix[rowcount, 0] = Int32.Parse(number);
                    rowcount++;
                }
            }

           


            //cast coefficient matrix to double
            double[,] doublecoefficientmatrix = new double[coefficientmatrix.GetLength(0), coefficientmatrix.GetLength(1)];
            double[,] doublenumbermatrix = new double[numbermatrix.GetLength(0), numbermatrix.GetLength(1)];
            for (int i = 0; i < coefficientmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < coefficientmatrix.GetLength(1); j++)
                {
                    doublecoefficientmatrix[i,j] = (double)coefficientmatrix[i,j];

                }
            }

            for (int i = 0; i < numbermatrix.GetLength(0); i++)
            {
                for (int j = 0; j < numbermatrix.GetLength(1); j++)
                {
                    doublenumbermatrix[i,j] = (double)numbermatrix[i,j];

                }
            }

            printintmatrix(numbermatrix);
            printintmatrix(coefficientmatrix);



            double[,] result = matrixmult( getinverse(doublecoefficientmatrix) , doublenumbermatrix );
            return result;

        }



        static void Main(string[] args)
        {
            
            printmatrix(solve("3x+y=27,5x+7y=35"));
            Console.ReadKey();



        }




    }
}


    

