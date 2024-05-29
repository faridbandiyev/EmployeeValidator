using System;

namespace EmployeeValidator
{
    internal class Program
    {
        private static bool ValidateName(string name, int minLength, int maxLength, string type)
        {
            while (true)
            {
                if (name.Length < minLength || name.Length > maxLength)
                {
                    Console.WriteLine(type + " length must be between " + minLength + " and " + maxLength + ".");
                }
                else if ((int)name[0] < 65 || (int)name[0] > 90)
                {
                    Console.WriteLine(type + " must start with an uppercase letter.");
                }
                else
                {
                    bool allLowercase = true;
                    for (int i = 1; i < name.Length; i++)
                    {
                        if ((int)name[i] < 97 || (int)name[i] > 122)
                        {
                            allLowercase = false;
                            break;
                        }
                    }
                    if (!allLowercase)
                    {
                        Console.WriteLine(type + " must consist only of letters, and the first letter must be uppercase while others must be lowercase.");
                    }
                    else
                    {
                        return true;
                    }
                }
                Console.Write($"Enter {type}: ");
                name = Console.ReadLine();
            }
        }

        private static bool ValidateFin(string fin)
        {
            while (true)
            {
                if (fin.Length != 7)
                {
                    Console.WriteLine("FIN must be 7 characters long.");
                }
                else
                {
                    bool valid = true;
                    for (int i = 0; i < fin.Length; i++)
                    {
                        if (!((int)fin[i] >= 65 && (int)fin[i] <= 90) && !((int)fin[i] >= 48 && (int)fin[i] <= 57))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                    {
                        Console.WriteLine("FIN must consist only of uppercase letters and digits.");
                    }
                    else
                    {
                        return true;
                    }
                }
                Console.Write("Enter FIN: ");
                fin = Console.ReadLine();
            }
        }

        private static bool ValidatePhone(string phone)
        {
            while (true)
            {
                if (phone.Length != 13 || (int)phone[0] != 43 || (int)phone[1] != 57 || (int)phone[2] != 57 || (int)phone[3] != 52)
                {
                    Console.WriteLine("Phone number must start with +994 and be 13 characters long.");
                }
                else
                {
                    bool valid = true;
                    for (int i = 4; i < phone.Length; i++)
                    {
                        if ((int)phone[i] < 48 || (int)phone[i] > 57)
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                    {
                        Console.WriteLine("Phone number must consist only of digits.");
                    }
                    else
                    {
                        return true;
                    }
                }
                Console.Write("Enter Phone Number: ");
                phone = Console.ReadLine();
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter employee information:");

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            ValidateName(firstName, 2, 20, "First name");

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            ValidateName(lastName, 2, 35, "Last name");

            Console.Write("Enter Father's Name: ");
            string fatherName = Console.ReadLine();
            ValidateName(fatherName, 2, 20, "Father's name");

            string fin;
            do
            {
                Console.Write("FIN: ");
                fin = Console.ReadLine();
            } while (!ValidateFin(fin));

            string phone;
            do
            {
                Console.Write("Phone Number: ");
                phone = Console.ReadLine();
            } while (!ValidatePhone(phone));

            Console.WriteLine("All validations passed. Employee information is valid.");
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║          Employee Information        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine($"║ First Name:    {firstName,-21} ║");
            Console.WriteLine($"║ Last Name:     {lastName,-21} ║");
            Console.WriteLine($"║ Father's Name: {fatherName,-21} ║");
            Console.WriteLine($"║ FIN:           {fin,-21} ║");
            Console.WriteLine($"║ Phone Number:  {phone,-21} ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
        }
    }
}