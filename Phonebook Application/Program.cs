using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;

namespace PhonebookApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string> ();

            bool loop = true;

            while (loop)
            {
                if(!(phonebook.Count() == 0))
                {
                    Console.WriteLine("\nTo Add a new contact - 1, To Delete a contact - 2, To Search for a contact - 3, To Display all contacts - 3");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                        addContact(phonebook);
                    else if (choice == 2)
                        deleteContact(phonebook);
                    else if(choice == 3)
                        searchContact(phonebook);
                    else
                        loop = false;
                }

                else
                {
                    Console.WriteLine("Your phonebook is currently empty.");
                    Console.WriteLine("Do you want to add a contact? (Yes/No)");
                    string answer = Console.ReadLine();

                    if (answer.Equals("Yes"))
                        addContact(phonebook);
                    else
                        loop = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach(KeyValuePair<string, string> item in phonebook) 
            {
                Console.WriteLine($"{item.Key}, {item.Value}");
            }
        }

        public static void addContact(Dictionary<string, string> phonebook)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEnter a contact's name:");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Enter {name}'s phone number:");
            Console.ResetColor();
            string pNumber = Console.ReadLine();

            phonebook.Add(name, pNumber);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contact was successfully added!");
            Console.ResetColor();
        }

        public static void deleteContact(Dictionary<string, string> phonebook)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the name of the contact you would like to delete:");
            Console.ResetColor();

            string deleteName = Console.ReadLine();
            phonebook.Remove(deleteName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Contact was successfully deleted!\n");
            Console.ResetColor();
        }

        public static void searchContact(Dictionary<string, string> phonebook)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the name of the contact you would like to find:");
            Console.ResetColor();
            string findName = Console.ReadLine();

            if (phonebook[findName] != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{findName}, {phonebook[findName]}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This contact doesn't exist!");
                Console.ResetColor();
            }
        }
    }
}