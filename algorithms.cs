using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    class Algorithms
    {
        static Random rnd = new Random();
        static int[] visited2, solution2;
        static int[] visited, solution;

        //public int getCurrentBest()
        //{
        //    return currentBest;
        //}

        public int randomTSP(int startNode, int[,] cities )
        {
            //pick a number between 1 and 10
            //pick the corresponding colonne to the number
            //if its taken, go again
            //int currentNode = startNode;
            //int nextNode;
            int cost;
            int totalCost = 0;
            visited = new int[cities.GetLength(0)];
            solution = new int[cities.GetLength(0)-1];
            int currentBest = 0;

            if (startNode < 0 || startNode > cities.GetLength(0))
            {
                return -1;
            }

            visited[0] = startNode;

            //fyller visisted[] med -1, slik at node 0 blir et gyldig valg
            for (int i = 1; i < visited.Length; i++)
            {
                visited[i] = -1;
            }

            for (int i = 1; i < cities.GetLength(0); i++)//GetLenght() gives the size of one dimension in the array(one row/colonne).
            {
                bool done = false;

                while (!done)
                {
                    bool found = false;

                    visited[i] = rnd.Next(0, cities.GetLength(0));

                    for (int j = 0; j < i; j++)
                    {
                        if (visited[i] == visited[j])
                        {
                            found = true;
                        }
                        //found = visited[i] == visited[j];
                    }
                    done = !found;

                }
            }

            for (int i = 1; i < visited.Length; i++)
            {
                cost = cities[visited[i - 1], visited[i]];
                solution[i-1] = cost;
                totalCost = totalCost + cost;
            }

            currentBest = totalCost;
            printResult(visited, solution, currentBest);

            return currentBest;
        }//RandomTSP

        public int iterativeRandomTSP(int startNode, int[,] cities)
        {
            int cost;
            int totalCost;
            visited = new int[cities.GetLength(0)];
            solution = new int[cities.GetLength(0) - 1];
            int currentBest = int.MaxValue;
            //int improvement = int.MaxValue;
            int counter = 100;
            do
            {
                totalCost = 0;

                if (startNode < 0 || startNode > cities.GetLength(0))
                {
                    return 1;
                }

                visited[0] = startNode;

                //fyller visisted[] med -1, slik at node 0 blir et gyldig valg
                for (int i = 1; i < visited.Length; i++)
                {
                    visited[i] = -1;
                }

                for (int i = 1; i < cities.GetLength(0); i++)//GetLenght() gives the size of one dimension in the array(one row/colonne).
                {
                    bool done = false;

                    while (!done)
                    {
                        bool found = false;

                        visited[i] = rnd.Next(0, cities.GetLength(0));

                        for (int j = 0; j < i; j++)
                        {
                            if (visited[i] == visited[j])
                            {
                                found = true;
                            }
                            //found = visited[i] == visited[j];
                        }
                        done = !found;

                    }
                }

                for (int i = 1; i < visited.Length; i++)
                {
                    cost = cities[visited[i - 1], visited[i]];
                    solution[i - 1] = cost;
                    totalCost = totalCost + cost;
                }

                if(totalCost < currentBest)
                {
                    //improvement = currentBest - totalCost;
                    currentBest = totalCost;
                }
                //Console.Write("{0}, ", totalCost);
                counter--;

            } while (counter > 0);

            printResult(visited, solution, currentBest);
            
            return currentBest;
        }//IterativeRandom

        public int greedyTSP(int startNode, int[,] cities)
        {
            int currentNode = startNode;
            int nextNode = 0;
            //int cost = int.MaxValue;
            int totalCost = 0;
            visited = new int[cities.GetLength(0)];
            solution = new int[cities.GetLength(0) - 1];
            int currentBest;
            int amountVisited = 1;
            int minRow = 0;
            int minColon = 0;

            visited[0] = currentNode;

            for (int i = 0; i < cities.GetLength(0)-1; i++)
            {
                int cost = int.MaxValue;
                /*cities[i, startNode] = -1;*/
                for (int j = 1; j <= amountVisited; j++)
                {
                    currentNode = visited[j - 1];

                    for (nextNode = 0; nextNode < cities.GetLength(0); nextNode++)
                    {
                        if (cities[currentNode,nextNode] < cost && cities[currentNode, nextNode] != -1)
                        {
                            cost = cities[currentNode, nextNode];
                            minRow = currentNode;
                            minColon = nextNode;
                        }
                    }
                }//For visited

                cities[minRow, minColon] = -1;
                cities[minColon, minRow] = -1;

                if (minColon != visited[i])
                {
                    visited[amountVisited] = minColon;
                    solution[amountVisited - 1] = cost;
                    totalCost = totalCost + cost;
                    amountVisited++;
                }
                else
                {
                    i--;
                    cities[currentNode, minColon] = -1;
                    cities[minColon, currentNode] = -1;
                }
            }

            currentBest = totalCost;
            printResult(visited, solution, currentBest);
            return currentBest;
        }//greedyTSP

        public int twoPointSwap(int cities)
        {
            int totalCost = 0;

            copyTable(visited, solution);

            for (int i = 0; i < solution.Length; i++)
            {
                totalCost = totalCost + solution[i];
            }



            return 0;
        }

        public void copyTable(int[] visited, int[] solution)
        {
            visited2 = new int[(visited.Length)];
            solution2 = new int[(solution.Length)];
            for (int i = 0; i < visited.Length; i++)
            {
                visited2[i] = visited[i];
            }

            for (int i = 0; i < solution.Length; i++)
            {
                solution2[i] = solution[i];
            }

            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write(visited2[i]);
            }

            Console.Write("\n");

            for (int i = 0; i < solution.Length; i++)
            {
                Console.Write(solution2[i]);
            }
            Console.Write("\n");
        }
        

        public void printResult(int[] visited, int[] solution, int currentBest)
        {
            Console.Write("Visited: ");
            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write("| {0} ", visited[i]);
            }
            Console.Write("|");
            Console.Write("\n");

            Console.Write("Solution: ");
            for (int i = 0; i < solution.Length; i++)
            {
                Console.Write("| {0} ", solution[i]);
            }
            Console.Write("|");
            Console.Write("\n");
            Console.WriteLine("CurrentBest: {0}", currentBest);
            Console.Write("\n");
        }
    }
}
