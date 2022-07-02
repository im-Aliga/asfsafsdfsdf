using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
            public static List<Person> People { get; set; } = new List<Person>();
        static void Main(string[] args)
           
          
        {

            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person");
            Console.WriteLine("/remove-all-person");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();
                    Addperson(name, lastName, fin);
                      

                }
                else if (command == "/remove-person")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();
                    RemovePeople(fin);

                }
                else if (command == "/remove-all-person")
                {
                    Console.Write("to remove all person:");
                    RemoveAllPeople();
                }
                else if (command =="/remove-person-by-ID")
                {
                    Console.Write("TO remove person,please enter his/her ID:");
                    uint id =Convert.ToUInt32 ( Console.ReadLine());
                    RemoveByID(id);
                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    ShowPeople();
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }
        public static void Addperson(string name, string lastname,string fin)
        {
            Person person = new Person(name,lastname, fin);
            People.Add(person);

            Console.WriteLine(person.GetInfo() + " - Added to system.");
        }
        public static void RemovePeople(string fin)
        {
            
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].FIN == fin)
                {
                    Console.WriteLine(People[i].GetInfo());
                    People.RemoveAt(i);
                    Console.WriteLine("Person removed successfully");
                }
            }
        }
        public static void RemoveAllPeople()
        {
            for (int i = 0; i <= People.Count; i++)
            {
                People.RemoveAt(0);

            }
            Console.WriteLine("all person has been deleted");
        }
        public static void ShowPeople()
        {
            foreach (Person person in People)
            {
                Console.WriteLine(person.GetInfo());
            }
        }
        public static void RemoveByID(uint id)
        {

            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Id == id)
                {
                    Console.WriteLine(People[i].GetInfo());
                    People.RemoveAt(i);
                    Console.WriteLine("Person removed successfully");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FIN { get; set; }
        public static uint CounterID = 1;
        public uint Id { get;private set; }
        public Person(string name, string lastName, string fin)
        {
            Id = CounterID;
            Name = name;
            LastName = lastName;
            FIN = fin;
            CounterID++;
            
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return Id+" "+ Name + " " + LastName + " " + FIN;
        }
    }
}