using System;
using System.Collections.Generic;

namespace PersonList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            personList = PopulateList();

            DisplayList(personList);
            if(!FindDuplicates(personList))
                Console.WriteLine("No duplicates found.");
            personList.Add(new Person("Fred Rogers", "freddy99@yahoo.com"));
            if(FindDuplicates(personList))
                Console.WriteLine("Duplicates found!");

            personList = InsertionSort(personList);
            
            DisplayList(personList);

        }

        static List<Person> InsertionSort(List<Person> unsorted)
        {
            Person temp = unsorted[0];
            int sortIndex = 1;
            for(int i = 0; i < unsorted.Count; i++)
            {
                for(int j = 0; j < sortIndex; j++)
                {
                    if(string.Compare(unsorted[j].ToString(), unsorted[i].ToString()) > 0)
                    {
                        temp = unsorted[i];
                        unsorted[i] = unsorted[j];
                        unsorted[j] = temp;
                    }
                    
                
                }
                sortIndex++;
            }
            return unsorted;
                
        }

        static bool FindDuplicates(List<Person> personList)
        {
            for(int i = 0; i < personList.Count-1; i++)
                for(int j = i+1; j < personList.Count; j++)
                {
                    if(string.Equals(personList[i].ToString(),personList[j].ToString()))
                        return true;
                }
            return false;
        }

        static void DisplayList(List<Person> personList)
        {
            Console.WriteLine("List of Personnel:");
            for(int i = 0; i < personList.Count; i++)
            {
                Console.WriteLine(personList[i].ToString());
            }
        }
        static List<Person> PopulateList()
        {
            List<Person> populatedList = new List<Person>();
            populatedList.Add(new Person("Fred Rogers", "fred123@yahoo.com"));
            populatedList.Add(new Person("Bob Stucker","stuck76@gmail.com"));
            populatedList.Add(new Person("Ranger Rick", "Hooahh@nortvoods.net"));
            populatedList.Add(new Person("Francis", "francisca555.alternent.net"));
            populatedList.Add(new Person("Angelica Houston","AngeHoustBaby.gmail.com"));

            return populatedList;
        }
    }
}
