using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestTrip;

namespace ConsoleBestTrip
{
    class Program
    {
        static void Main(string[] args)
        {
          
         VertexReader reader = null;
         Graph g = null;
         try
          {
              reader = new VertexReader("trips.txt", '\t');
              g = new Graph(reader, 6);
          }
          catch (Exception ex)
          {
              HandleError(ex.Message);
              Console.ReadKey();
              Environment.Exit(Environment.ExitCode);
          }
           
            string flag = "yes";
            while (flag == "yes")
            {
                int start;
                int end;
                double distance;
                BestTripSearch bts;
                try
                {
                    Console.WriteLine("Enter start city");
                    start = reader.GetIndex(Console.ReadLine());
                 
                    Console.WriteLine("Enter end city");
                    end = reader.GetIndex(Console.ReadLine());
                
                    Console.WriteLine("Enter max distance");
                    while (!double.TryParse(Console.ReadLine(), out distance))
                    {
                        HandleError("Please enter correct distance");
                    }
                   bts = new BestTripSearch(g, start, end, distance);
                }
                catch (ArgumentException ex)
                {
                    HandleError(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    HandleError(ex.Message);
                    break;
                }
               
              ConsoleColor originalColor = Console.ForegroundColor;
                if (bts.HasPath())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The best trip from {0} to {1} with max distance {2}: ", reader.GetName(start), reader.GetName(end), distance);
                        Console.WriteLine();
                        foreach (var id in bts.BestPath())
                        {
                            Console.WriteLine("{0} ", reader.GetName(id));
                        }
                        Console.WriteLine();
                        Console.WriteLine("Distance: {0}; Profit: {1}", bts.BestDistance(), bts.BestProfit());
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Impossible:   {0}  {1}    {2}  ", reader.GetName(start), reader.GetName(end), distance);
                    }
             
                Console.ForegroundColor = originalColor;              
                Console.WriteLine();
                while (true)
                {
                    Console.WriteLine("Do you want to continue!(yes/no)");
                    flag = Console.ReadLine().ToLower();
                    if (flag != "yes" && flag != "no")
                        continue;
                    else
                        break;
                }

            }
        }
            private static void  HandleError(string message)
            {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = originalColor;
            }

            private static void DisplayInfo(string message)
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = originalColor;
            }
        }
    }

