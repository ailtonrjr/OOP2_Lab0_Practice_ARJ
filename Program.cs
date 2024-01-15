using System;
using System.IO;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Lab01Practice;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lab 0: Basics of C#\n");

        Console.WriteLine("\nTask 1: Creating Variables\n");

        int intLowerNumber = LowerNumber();
        int intHigherNumber = HigherNumber(intLowerNumber);

        int difference = intHigherNumber - intLowerNumber;
        Console.WriteLine($"The difference between {intHigherNumber} and {intLowerNumber} is: {difference}");


        Console.WriteLine("\nTask 2: Looping and Input Validation\n");

        while (intLowerNumber < 0)
        {
            Console.WriteLine($"{intLowerNumber} is an invalid number. Please enter a valide positive number: ");
            intLowerNumber = LowerNumber();
        }

        if (intLowerNumber > 0)
        {
            Console.WriteLine($"Validation 2.1: 'low' number ({intLowerNumber}) is positive\n");
        }

        while (intHigherNumber < intLowerNumber)
        {
            Console.WriteLine($"These character is invalid. Enter the 'high' number: ");
            intHigherNumber = HigherNumber(intHigherNumber);

        }

        if (intHigherNumber > intLowerNumber)
        {
            Console.WriteLine($"Validation 2.2: 'high'({intHigherNumber}) is greater than 'low' number ({intLowerNumber})\n");
        }

        Console.WriteLine("Task3: Using Arrays and File I/O\n");

        string myFile = "C:\\Users\\ailto\\OneDrive\\Documentos\\Software Development\\CPRG-211 - Object-Oriented Programming 2\\Test 1\\numbers.txt";

        int[] setOfNumbers = NewArray(intLowerNumber, intHigherNumber);

        TransferInfoToTxt(myFile, setOfNumbers);

        SumOfNumbers(myFile);

        List<int> newList = new List<int>(setOfNumbers);//creating a variable newList (type 'int list') and inputting the array 'setOfNumbers' as the parameter

        List<double> doubleNewList = ConvertNewListToDouble(newList); //invoking the method ConvertNewListToDouble (newList as argument)

        CheckPrimeNumbers(intLowerNumber, intHigherNumber);


    }
    static int LowerNumber()
    {
        int userLower;
        Console.WriteLine("Enter the 'low' number: ");
        string low = Console.ReadLine();

        while (!int.TryParse(low, out userLower))
        {
            Console.WriteLine("These character is invalid. Enter the 'low' number: ");
            low = Console.ReadLine();
        }

        return userLower;

    }

    static int HigherNumber(int lower)
    {
        int userHigher;
        Console.WriteLine("Enter the 'high' number: ");
        string high = Console.ReadLine();

        while (!int.TryParse(high, out userHigher) || userHigher <= lower)
        {
            Console.WriteLine("These character is invalid. Enter the 'high' number: ");
            high = Console.ReadLine();
        }
        return userHigher;
        
    }


    static int[] NewArray(int smaller, int greater)
    {
        int[] array1 = new int[(greater - smaller) + 1];
        for (int i = 0, addNumber = smaller; i < array1.Length; i++, addNumber++)
        {
            array1[i] = addNumber;
        }
        return array1;
    }

    static void TransferInfoToTxt(string fileName, int[] numbers)
    {
        Array.Reverse(numbers);
        File.WriteAllLines(fileName, Array.ConvertAll(numbers, n => n.ToString()));
        Console.WriteLine($"Number written to {fileName} as required.");
    }

    static int SumOfNumbers(string fileName)
    {
        string[] numbers = File.ReadAllLines(fileName);
        int sum = 0;
        foreach (string number in numbers)
        {
            if (int.TryParse(number, out int intNumber))
            {
                sum += intNumber;
            }
        }
        Console.WriteLine($"The sum of all numbers is equal to {sum}.");
        return sum;
    }
    static List<double> ConvertNewListToDouble(List<int> intList)
    {
        return intList.ConvertAll<double>(x => x);
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void CheckPrimeNumbers(int low, int high)
    {
        Console.WriteLine($"Prime numbers between {low} and {high}: ");
        for (int i = low; i <= high; i++)
        {
            if (IsPrime(i))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }

}




//int intMenu;

//while (true)
//{

//Console.WriteLine("Choose the number of the task:\n1. Creating Variables\n2. Looping and Input Validation\n\t2.1. Get a 'low' number\n\t2.2. 'high'number should be greater than 'low' number\n3. Using Arrays and File I/O\n4. 'additional' tasks\n9. Exit");
//string strMenu = Console.ReadLine();

//if (int.TryParse(strMenu, out intMenu))
//{

//    if (intMenu == 1)
//    {
//        Task1();
//    }

//    else if (intMenu == 2)
//    {
//        Task2();
//    }

//    else if (intMenu == 3)
//    {

//        Task3(intLow, intHigh);

//    }

//else if (intMenu == 4)
//{
//    Task4();
//    break;
//}

//                else if (intMenu == 9)
//                {
//                    Console.WriteLine("Finishing the program. See you!");
//                    break;
//                }

//            }
//        }
//    }
//    static void Task1()
//    {
//        Console.WriteLine("\nTask 1: Creating Variables\n");

//        int newLow;
//        int newHigh;


//        while (true)
//        {

//            Console.WriteLine($"Enter the 'low' number: ");
//            string low = Console.ReadLine();

//            while (!int.TryParse(low, out newLow))
//            {
//                Console.WriteLine($"These character is invalid. Enter the 'low' number: ");
//                low = Console.ReadLine();
//            }

//            Console.WriteLine($"the int representation of low: {newLow}");
//            break;
//        }
//        //if (int.TryParse(low, out newLow)) //insert a while to keep asking a valid number if it wasn't possible to convert the readline to int
//        //{
//        //    Console.WriteLine($"the int representation of low: {newLow}");
//        //    break;
//        //}
//        //else
//        //{
//        //    Console.WriteLine("Invalid number");
//        //}

//        Console.WriteLine($"Enter the 'high' number: ");
//        string high = Console.ReadLine();

//        while (true)
//        {
//            while (!int.TryParse(high, out newHigh))
//            {
//                Console.WriteLine($"These character is invalid. Enter the 'high' number: ");
//                high = Console.ReadLine();
//            }
//            if (int.TryParse(high, out newHigh) && newHigh <= newLow)
//            {
//                Console.WriteLine("'High' number must be bigger than the 'low'. Please enter a bigger number: ");
//                high = Console.ReadLine();
//            }
//            else
//            {
//                Console.WriteLine($"Now the number ({newHigh}) is bigger");
//                break;
//            }
//        }

//        Console.WriteLine($"The int representation of high: {newHigh}");
//        int difference = newHigh - newLow;
//        Console.WriteLine($"The difference between {newHigh} and {newLow} is: {difference}");

//    }


//    static int Task2()
//    {
//        Console.WriteLine("\nTask 2: Looping and Input Validation\n");

//        int low_Number = lowNumber();
//        int high_Number = highNumber(low_Number);

//            //Item 1
//            static int lowNumber()
//            {
//                int intLow;
//                Console.WriteLine("Enter a positive number: ");
//                string low = Console.ReadLine();
//                while (!int.TryParse(low, out intLow) || intLow <= 0)
//                {
//                    Console.WriteLine($"{intLow} is an invalid number. Please enter a valide positive number: ");
//                    low = Console.ReadLine();
//                }

//                Console.WriteLine($"{intLow} is a positive number.");
//                return intLow;
//            }

//            //Item 2
//            static int highNumber(int intLow)
//            {
//                int intHigh;
//                Console.WriteLine("Enter a number greater than the 'low' number: ");
//                string high = Console.ReadLine();
//                while (!int.TryParse(high, out intHigh))
//                {
//                    Console.WriteLine($"{high} are invalid characters. Please enter a valid number: ");
//                    high = Console.ReadLine();
//                }
//                if (int.TryParse(high, out intHigh))
//                {
//                    while (intHigh <= intLow)
//                    {
//                        Console.WriteLine($"{intHigh} is lower than {intLow}. Please insert a number greater than {intLow}");
//                        high = Console.ReadLine();
//                        int.TryParse(high, out intHigh);
//                    }

//                    Console.WriteLine($"{intHigh} is greater than {intLow}");

//                }
//            return intHigh;

//        }
//        }
//    static void Task3(int Low, int High)
//    {
//        Console.WriteLine("Task3: Using Arrays and File I/O");

//        //double task_2 = Task2();
//        //int lowTask3 = task_2.lowNumber

//        int low = 5;
//        int high = 10;
//        int[] array1 = new int[(high - low) + 1];
//        for (int i = 0, addNumber = low; i < array1.Length; i++, addNumber++)
//        {
//            array1[i] = addNumber;
//        }

//        foreach (var elem in array1)
//        {
//            Console.WriteLine(elem + "point");
//        }

//        //int file = File.WriteAllText("newfile.txt", array1); // 

//    }


//}



//        //static void PrintArray(int[] array)
//        //{
//        //    foreach (var element in array)
//        //    {
//        //        Console.Write(element + " ");
//        //    }
//        //    Console.WriteLine();
//        //}








//    //static int highNumber(int intLow)
//    //{
//    //    int intHigh;
//    //    Console.WriteLine("Enter a number greater than the 'low' number: ");
//    //    string high = Console.ReadLine();
//    //    while (!int.TryParse(high, out intHigh))
//    //    {
//    //        Console.WriteLine($"{high} are invalid characters. Please enter a valid number: ");
//    //        high = Console.ReadLine();
//    //    }
//    //    if (int.TryParse(high, out intHigh))
//    //    {
//    //        while (intHigh <= intLow)
//    //        {
//    //            Console.WriteLine($"{intHigh} is lower than {intLow}. Please insert a number greater than {intLow}");
//    //            high = Console.ReadLine();
//    //            int.TryParse(high, out intHigh);
//    //        }

//    //        Console.WriteLine($"{intHigh} is greater than {intLow}");

//    //    }
//    //    return intHigh;
//    //}
//    //while (true)
//    //    {
//    //        string high = Console.ReadLine();
//    //        if (int.TryParse(high,out newHigh) && newHigh > intLow)
//    //        {
//    //            Console.WriteLine($"{newHigh} is greater than {newLow}");
//    //        }




//            //Console.WriteLine($"Enter the 'low' number: ");
//            //string low = Console.ReadLine();
//            //if (int.TryParse(low, out newLow)) //insert a while to keep asking a valid number if it wasn't possible to convert the readline to int
//            //{
//            //    Console.WriteLine($"the int representation of low: {newLow}");
//            //}
//            //else
//            //{
//            //    Console.WriteLine("Invalid number");
//            //}

//            //Console.WriteLine($"Enter the 'high' number: ");
//            //string high = Console.ReadLine();
//            //if (int.TryParse(high, out newHigh))
//            //{
//            //    while (newHigh <= newLow)
//            //    {
//            //        Console.WriteLine("'High' number must be bigger than the 'low'. Please enter a bigger number: ");
//            //        high = Console.ReadLine();

//            //        if (int.TryParse(high, out newHigh))
//            //        {
//            //            if (newHigh > newLow)
//            //            {
//            //                Console.WriteLine($"Now the number ({newHigh}) is bigger");
//            //                break;
//            //            }
//            //        }
//            //        else
//            //        {
//            //            Console.WriteLine("Invalid number. Please enter a valid number: "); //insert a while to keep asking a valid number if it wasn't possible to convert the readline to int
//            //        }
//            //    }



