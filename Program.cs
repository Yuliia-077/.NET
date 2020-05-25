using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey consoleKey;
            DateTime now = DateTime.Now;
            if (now.DayOfWeek != DayOfWeek.Sunday)
            {
                Human hum = new Human();
                Human[] humans =
                {
                    new Student(),
                    new Botan(),
                    new Girl(),
                    new PrettyGirl(),
                    new SmartGirl()
                };

                do
                { 
                    Random random = new Random();
                    var firstIndex = random.Next(humans.Length);
                    var secondIndex = random.Next(humans.Length);

                    Console.WriteLine($"First member in couple: {humans[firstIndex].GetType().Name}");
                    Console.WriteLine($"Second member in couple: {humans[secondIndex].GetType().Name}\n");
                    try
                    {
                        Human.CheckCouple(humans[firstIndex], humans[secondIndex]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    IHasName child = hum.Couple(humans[firstIndex], humans[secondIndex]);
                    Console.WriteLine($"\nName: {child.GetType().GetProperty("Name")?.GetValue(child)}");
                    Console.WriteLine($"Surname: {child.GetType().GetProperty("Surname")?.GetValue(child)}");
                    Console.WriteLine($"ChildType: {child}");
                    consoleKey = Console.ReadKey(false).Key;
                } while (consoleKey != ConsoleKey.F10 && consoleKey != ConsoleKey.Q && consoleKey.ToString() != "q");
            }
            else
            {
                Console.WriteLine("Today is Sunday!");
            }
        }
    }
}
