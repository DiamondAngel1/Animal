using System.Text;
using Animal.infrastructure;
using Animal.infrastructure.Entitys;
using Animal.infrastructure.Services;

namespace PostgreSQLBD{
    internal class Program{
        static void Main(string[] args){
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            var specieService = new SpecieService();
            int option = 1;
            do{
                Console.WriteLine("Оберіть варіант: ");
                Console.WriteLine("1. Створити вид");
                Console.WriteLine("2. Вивести всі види в таблиці");
                Console.WriteLine("3. Пошук виду по Id");
                Console.WriteLine("4. Зміна виду");
                Console.WriteLine("5. Видалити всі види");
                Console.WriteLine("6. Видалити вид за Id");
                Console.WriteLine("0. Вийти");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        option = 0;
                        break;
                    case 1:
                        Console.WriteLine("Введіть вид для створення:");
                        string specie = Console.ReadLine();
                        var newSpecie = new Specie {Name = specie};
                        try{
                            specieService.CreateSpecie(newSpecie);
                            Console.WriteLine("Вид доданий");
                        }
                        catch (Exception e){
                            Console.WriteLine($"Помилка: {e.Message}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Список всіх тварин: ");
                        var allSpecies = specieService.GetAllSpecies();
                        foreach (var s in allSpecies) {
                            Console.WriteLine($"{s.Id}. {s.Name}");
                        }
                        break;
                    case 3:
                        try{
                            Console.WriteLine("Введіть id тварини для пошуку: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var specie2 = specieService.GetSpecieById(id);
                            if (specie2 != null){
                                Console.WriteLine($"Тварина: {specie2.Name}");
                            }
                            else{
                                Console.WriteLine($"Тварини за id \"{id}\" не знайдено");
                            }
                        }
                        catch (System.Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 4:
                        try{
                            Console.WriteLine("Введіть Id тварини для зміни: ");
                            int uId = Convert.ToInt32(Console.ReadLine());
                            var specieToUpdate = specieService.GetSpecieById(uId);
                            if (specieToUpdate == null){
                                Console.WriteLine($"Тварини за id \"{uId}\" не знайдено");
                                return;
                            }
                            Console.WriteLine($"Поточна тварина: \"{specieToUpdate.Name}\"");
                            Console.WriteLine("Вкажіть назву тварини на яку хочете замінити:");
                            string newSpecieN = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newSpecieN) && specieService.IsNameUnique(newSpecieN)){
                                specieToUpdate.Name = newSpecieN;
                                specieService.UpdateSpecie(specieToUpdate);
                                Console.WriteLine("Тварина оновлена");
                            }
                            else{
                                Console.WriteLine("Помилка: Нова назва тварини або не пуста або не унікальна");
                            }
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Видалення всіх тварин...");
                        try{
                            specieService.DeleteAllSpecies();
                            Console.WriteLine("Всі тварини видалені");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Введіть Id Тварини для видалення: ");
                        try{
                            int idDel = Convert.ToInt32(Console.ReadLine());
                            specieService.DeleteSpecie(idDel);
                            Console.WriteLine("Тварина видалена");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
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