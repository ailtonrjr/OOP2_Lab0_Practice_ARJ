using System;

public class Class1
{
	public Class1()
	{
        Console.WriteLine("Enter the 'low' number: ");
        int low = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the 'high' number: ");
        int high = int.Parse(Console.ReadLine());

        // Validate that high is greater than low
        if (high <= low)
        {
            Console.WriteLine("Error: 'high' number must be greater than 'low' number.");
            return;
        }

        // Create an array to hold every number between low and high
        int[] numbersArray = new int[high - low + 1];

        // Populate the array with values
        for (int i = 0; i < numbersArray.Length; i++)
        {
            numbersArray[i] = low + i;
        }

        // Print the array
        Console.WriteLine("Array of numbers between low and high:");
        
    }
}
