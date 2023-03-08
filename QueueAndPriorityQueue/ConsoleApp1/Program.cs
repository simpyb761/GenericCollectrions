using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {

            // Queue<T> Collection

            Queue<string> leagueQueue = new Queue<string>();
            string[] names = { "Luxanna Crownguard", "Garen Crownguard", "Jarvan Lightshield", "Fiora Laurent", "Quinn Buvelle" };
            for (int x = 0; x < 5; x++)
            {
                leagueQueue.Enqueue(names[x]);
            }
            WriteLine($"There are {leagueQueue.Count()} people in your queue");
            if (leagueQueue.Contains("Fiora Laurent"))
            {
                WriteLine("The queue contains Fiora Laurent! We will push through the queue to bring her up front!");
                while (leagueQueue.Peek() != "Fiora Laurent")
                {
                    leagueQueue.Dequeue();
                }
            }
            else
            {
                WriteLine("There is no Fiora Laurent in your queue!");
            }
            foreach (string name in leagueQueue)
            {
                WriteLine($"{name} is still left in the queue");
            }
            WriteLine();

            //PriorityQueue<T> Collection

            PriorityQueue<string, int> leaguePriority = new PriorityQueue<string, int>();
            int[] priority = { 1, 3, 4, 2, 3 };
            for (int x = 0; x < 5; x++)
            {
                leaguePriority.Enqueue(names[x], priority[x]);
            }
            WriteLine($"The highest priority in the que is {leaguePriority.Peek()}");
            leaguePriority.Dequeue();
            while (leaguePriority.Count > 0)
            {
                WriteLine($"The new highest priority is {leaguePriority.Peek()}");
                leaguePriority.Dequeue();
            }
            if (leaguePriority.Count == 0)
            {
                WriteLine("There are no more members in your queue!");
            }
            WriteLine();

            //Stack<T> Collection

            Stack<string> leagueStack = new Stack<string>();
            for (int x = 0; x < 5; x++)
            {
                leagueStack.Push(names[x]);
            }
            if (leagueStack.Contains("Garen Crownguard"))
            {
                WriteLine("Garen Crownguard was found in the stack");
            }
            leagueStack.Pop();
            leagueStack.Pop();
            WriteLine($"There are {leagueStack.Count} Members left in the stack");
            foreach (string name in leagueStack)
            {
                WriteLine(name);
            }
            WriteLine();

            //LinkedList<T> and LinkedNodeList<T> Collections

            LinkedList<string> leagueLinkedList = new LinkedList<string>();
            for (int x = 0; x < 5; x++)
            {
                leagueLinkedList.AddLast(names[x]);
            }
            var first = leagueLinkedList.First;
            WriteLine($"The first item in our linked list is {first.Value}");
            var last = leagueLinkedList.Last;
            WriteLine($"The last item in our linked list is {last.Value}");
            var target = leagueLinkedList.Find("Jarvan Lightshield");
            leagueLinkedList.AddAfter(target, "Katarina Du Couteau");
            leagueLinkedList.Remove("Quinn Buvelle");
            WriteLine($"There are {leagueLinkedList.Count} members in your linked list");
            foreach(string name in leagueLinkedList)
            {
                WriteLine(name);
            }
            WriteLine();

            // Dictionary<TKey, TValue> Collection

            Dictionary<string, string> leagueKeyValuePairs = new Dictionary<string, string>()
            {
                ["Luxanna Crownguard"] = "Demacia",
                ["Garen Crownguard"] = "Demacia",
                ["Ashe Avarosa"] = "Freljord",
                ["Xayah"] = "Ionia",
                ["Qiyana"] = "Ixtal"

            };
            WriteLine("The keys in this dictionary are: ");
            foreach (KeyValuePair<string, string> element in leagueKeyValuePairs)
            {
                
                WriteLine(element.Key);
            }
            WriteLine("The values in this dictionary are: ");
            foreach (KeyValuePair<string, string> element in leagueKeyValuePairs)
            {
                
                WriteLine(element.Value);
            }
            foreach (KeyValuePair<string, string>element in leagueKeyValuePairs)
            {
                WriteLine($"{element.Key} is from {element.Value}");
            }
            leagueKeyValuePairs.Remove("Garen Crownguard");
            WriteLine($"There are {leagueKeyValuePairs.Count} entries in the Dictionary");
            WriteLine();

            //SortedList<TKey, TValue> Collection

            SortedList<string, string> leagueSortedPairs= new SortedList<string, string>()
            {
                ["Luxanna Crownguard"] = "Demacia",
                ["Garen Crownguard"] = "Demacia",
                ["Ashe Avarosa"] = "Freljord",
                ["Xayah"] = "Ionia",
                ["Qiyana"] = "Ixtal"

            };
            WriteLine("Please enter the key you wish to search for: ");
            var userSearch = ReadLine();
            while (userSearch == null) 
            {
                WriteLine("There are no null Keys. Please enter a value: ");
                userSearch = ReadLine();
            }
            if(leagueSortedPairs.ContainsKey(userSearch))
            {
                WriteLine($"This sorted list contains the key {userSearch}");
                var index = leagueSortedPairs.IndexOfKey(userSearch);
                leagueSortedPairs.TryGetValue(userSearch, out string name);
                WriteLine($"{userSearch} is from {name}");
                WriteLine($"Would you like to delete {userSearch} from the list? y or n");
                var confirmDelete = Char.Parse(ReadLine());
                if(confirmDelete == 'n')
                {
                    WriteLine("That entry will not be deleted");
                }
                else
                {
                    leagueSortedPairs.Remove(userSearch);
                }
            }
            else
            {
                WriteLine($"{userSearch} is not within the Sorted List!");
            }
            foreach(KeyValuePair<string, string> element in leagueSortedPairs)
            {
                WriteLine($"{element.Key} is from {element.Value}");
            }
            WriteLine();

            //HashSet<T> Collection 

            HashSet<string> demaciaHash = new HashSet<string>();
            for(int x =0; x < 5; x++)
            {
                demaciaHash.Add(names[x]);
            }
            HashSet<string> demaciaHashTwo = new HashSet<string>(new string[] { "Sylas", "Galio", "Kayle", "Morgana", "Xin Zhao" });
            HashSet<string> magesHash= new HashSet<string>(new string[] {"Luxanna Crownguard", "Sylas", "Syndra", "Morgana", "Annie"});
            demaciaHash.UnionWith(demaciaHashTwo);
            WriteLine("These Individuals are from Demacia!");
            foreach(string name in demaciaHash)
            {
                WriteLine(name);
            }
            HashSet<string> huntedMages = new HashSet<string>();
            huntedMages = magesHash;
            huntedMages.IntersectWith(demaciaHash);
            WriteLine("These Mages are hunted, in jail or hiding!");
            foreach(string name in huntedMages)
            {
                WriteLine(name);
            }
            WriteLine();

            //List<T> Collection

            List<string> leagueList = new List<string>();
            string[] moreDemacians = { "Sylas", "Galio", "Kayle", "Morgana", "Xin Zhao" };
            for (int x=0; x < 5; x++)
            {
                leagueList.Add(names[x]);
            }
            leagueList.AddRange(moreDemacians);
            leagueList.Sort();
            WriteLine("List in sorted order");
            foreach (string name in leagueList) 
            {
                WriteLine(name);
            }
            leagueList.Remove("Galio");
            leagueList.Reverse();
            WriteLine("List in reverse sorted order");
            foreach(string name in leagueList)
            {
                WriteLine(name);
            }
        }

    }
}