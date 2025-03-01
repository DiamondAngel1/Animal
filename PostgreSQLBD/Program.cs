using System.Text;
using PostgreSQLBD.Data.Entitis;

namespace PostgreSQLBD{
    internal class Program{
        static void Main(string[] args){
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int option = 1;
            do{
                Console.WriteLine("Оберіть варіант: ");
                Console.WriteLine("1. Створити користувачів");
                Console.WriteLine("2. Вивести користувачів");
                Console.WriteLine("3. Пошук користувачів по Id");
                Console.WriteLine("4. Зміна коритувача");
                Console.WriteLine("5. Видалити всіх користувачів");
                Console.WriteLine("0. Вийти");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise){
                    case 0:
                        option = 0;
                        break;
                    case 1:
                        Console.WriteLine("Створення користувачів...");
                        Database.SeedData();
                        Console.WriteLine("Користувачі створені");
                        break;
                    case 2:
                        Console.WriteLine("Список користувачів");
                        Database.PrintUsers();
                        break;
                    case 3:
                        Console.WriteLine("Введіть Id користувача для пошуку: ");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        Database.SearchId(userId);
                        break;
                    case 4:
                        Console.WriteLine("Введіть Id користувача для заміни");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введіть імя користуваача для заміни");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введіть прізвище користувача для заміни");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Введіть емейл користувача");
                        string email = Console.ReadLine();
                        Console.WriteLine("Введіть номер телефону для заміни");
                        string phone = Console.ReadLine();
                        Database.UpdateUser(id, name, lname, email, phone);
                        break;
                    case 5:
                        Console.WriteLine("Видалення всіх користувачів...");
                        Database.DeleteUsers();
                        Console.WriteLine("Користувачі видалені");
                        break;
                    default:
                        Console.WriteLine("Ви обрали не існуючий варіант");
                        break;
                }
            }
            while (option != 0);
        }
    }
}