using System;

namespace Oblig1
{
    class Program
    {
        //enum ExitCode : int
        //{
        //    NoError = 0,
        //    InvalidInput = 1,
        //    UnknownError = 10
        //}

        static Random rnd = new Random();
        static int citiesSize = 5;
        static int programLoops = 1;
        static int[,] cities = new int[citiesSize, citiesSize];
        static int[,] citiesB = new int[citiesSize, citiesSize];
        
        static void Main(string[] args)
        {
            int startNode;
            int resultRandomTSP = 0;
            int resultIterativeRandomTSP = 0;
            int resultGreedyTSP = 0;

            Console.WriteLine("Choose start node!: ");
            startNode = int.Parse(Console.ReadLine());
            Algorithms myAlgorithm = new Algorithms();

            for (int i = 0; i < programLoops; i++)
            {
                fillTable();
                printCitiesTable();
                Console.Write("\n");
                printCitiesTableB();

                Console.Write("\n");
                Console.WriteLine("Current program iteration: {0}", i + 1);
                Console.WriteLine("RandomTSP:");
                resultRandomTSP = resultRandomTSP + myAlgorithm.randomTSP(startNode, cities);
                Console.WriteLine("RandomIterativeTSP:");
                resultIterativeRandomTSP = resultIterativeRandomTSP + myAlgorithm.iterativeRandomTSP(startNode, cities);
                Console.WriteLine("ResultGreedyTSP:");
                resultGreedyTSP = resultGreedyTSP + myAlgorithm.greedyTSP(startNode, cities);
                Console.Write("\n");
            }
            resultRandomTSP = resultRandomTSP / programLoops;
            resultIterativeRandomTSP = resultIterativeRandomTSP / programLoops;
            resultGreedyTSP = resultGreedyTSP / programLoops;
            Console.WriteLine("Average result RandomTSP: {0}", resultRandomTSP);
            Console.WriteLine("Average result IterativeRandomTSP: {0}", resultIterativeRandomTSP);
            Console.WriteLine("Average result GreedyTSP: {0}", resultGreedyTSP);

            printCitiesTable();
            Console.Write("\n");
            printCitiesTableB();
            Console.ReadLine();
        }//main

        static void fillTable()
        {
            for (int i = 0; i < cities.GetLength(0); i++)
            {
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    if (i == j)
                    {
                        cities[i, j] = -1;
                        citiesB[i, j] = cities[i,j];
                    }
                    else
                    {
                        cities[i, j] = rnd.Next(1, 100);//Creates a random number between 1 and 10
                        citiesB[i, j] = cities[i, j];
                    }
                }//for
            }//for
        }

       
        
        static void printCitiesTable()
        {
            for (int i = 0; i < cities.GetLength(0); i++)
            {
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    if (j == cities.GetLength(0)-1)
                    {
                        Console.Write("|{0} |",cities[i, j]);
                        Console.Write("\n");
                    }
                    else if(i == j){
                        Console.Write("|{0} ", cities[i, j]);
                    }
                    else
                    {
                        Console.Write("| {0} ",cities[i, j]);
                    }

                    
                }
            }
        }//printCitiesTable

        static void printCitiesTableB()
        {
            for (int i = 0; i < cities.GetLength(0); i++)
            {
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    if (j == cities.GetLength(0) - 1)
                    {
                        Console.Write("|{0} |", citiesB[i, j]);
                        Console.Write("\n");
                    }
                    else if (i == j)
                    {
                        Console.Write("|{0} ", citiesB[i, j]);
                    }
                    else
                    {
                        Console.Write("| {0} ", citiesB[i, j]);
                    }


                }
            }
        }//printCitiesTable

    }//Class program
}
