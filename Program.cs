public class Program
{
    private static void Main()
    {
        RollDice rd = new RollDice();
        int num = 0;

        System.Console.WriteLine("Welcome to the dice throwing simulator!"); 
        System.Console.WriteLine("\nHow many dice rolls would you like to simulate?");

        if (int.TryParse(System.Console.ReadLine(), out num) && num > 0)
        {
            rd.Roll(num); 
        }

        else
        {
            System.Console.WriteLine("Invalid Input. Please enter a positive number next time.");
        }
    }
}

public class RollDice
{
    Random random = new Random();

    public void Roll(int num)
    {
        if (num < 1)
        {
            System.Console.WriteLine("Please select a positive number next time.");
        }

        else
        {
            int[] results = new int[13]; 

            for (int i = 0; i < num; i++)
            {
                int dice1 = random.Next(1, 7); 
                int dice2 = random.Next(1, 7);
                int sum = dice1 + dice2;

                results[sum]++; 
            }

            PrintHistogram(results, num);
        }
    }

    private void PrintHistogram(int[] results, int num)
    {
        System.Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        System.Console.WriteLine("Each \"*\" respresents 1% of the total number of rolls.");
        System.Console.WriteLine($"Total number of rolls = {num}.\n");

        for (int i = 2; i <= 12; i++)
        {
            int percentage = results[i] * 100 / num;
            string astericks = new string('*', percentage); 
            System.Console.WriteLine($"{i}: {astericks}");
        }
    }
}
