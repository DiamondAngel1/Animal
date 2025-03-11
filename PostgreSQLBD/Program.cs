using System.Text;
using Animal.infrastructure;
using Animal.infrastructure.Entitys;
using Microsoft.Extensions.DependencyInjection;
namespace PostgreSQLBD{
    internal class Program{
        static void Main(string[] args){
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            var sp = DIConfiguration.GetServiceProvider();
            var specieService = sp.GetService<SpecieService>();
            var animalService = sp.GetService<AnimalService>();
            int option = 1;
            do{
                Console.WriteLine("Оберіть варіант: ");
                Console.WriteLine("1. Створити вид");
                Console.WriteLine("2. Вивести всі види в таблиці");
                Console.WriteLine("3. Пошук виду по Id");
                Console.WriteLine("4. Зміна виду");
                Console.WriteLine("5. Видалити всі види");
                Console.WriteLine("6. Видалити вид за Id");
                Console.WriteLine("7. Створити тварину");
                Console.WriteLine("8. Вивести всіх тварин в таблиці");
                Console.WriteLine("9. Пошук тварини по Id");
                Console.WriteLine("10. Зміна тварини");
                Console.WriteLine("11. Видалити всіх тварин");
                Console.WriteLine("12. Видалити тварину за Id");
                Console.WriteLine("0. Вийти");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise){
                    case 0:
                        option = 0;
                        break;
                    case 1:
                        Console.WriteLine("Введіть вид для створення:");
                        string specie = Console.ReadLine();
                        var newSpecie = new Specie { Name = specie };
                        try{
                            specieService.CreateSpecie(newSpecie);
                            Console.WriteLine("Вид доданий");
                        }
                        catch (Exception e){
                            Console.WriteLine($"Помилка: {e.Message}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Список всіх видів тварин: ");
                        var list = specieService.GetAllSpecies();
                        foreach (var s in list){
                            Console.WriteLine($"{s.Id}. {s.Name}");
                        }
                        break;
                    case 3:
                        try{
                            Console.WriteLine("Введіть id виду для пошуку: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var specie2 = specieService.GetSpecieById(id);
                            if (specie2 != null){
                                Console.WriteLine($"Вид: {specie2.Name}");
                            }
                            else{
                                Console.WriteLine($"Вид за id \"{id}\" не знайдено");
                            }
                        }
                        catch (System.Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 4:
                        try{
                            Console.WriteLine("Введіть Id виду для зміни: ");
                            int uId = Convert.ToInt32(Console.ReadLine());
                            var specieToUpdate = specieService.GetSpecieById(uId);
                            if (specieToUpdate == null){
                                Console.WriteLine($"Вид за id \"{uId}\" не знайдено");
                                return;
                            }
                            Console.WriteLine($"Поточний вид: \"{specieToUpdate.Name}\"");
                            Console.WriteLine("Вкажіть назву виду на який хочете замінити:");
                            string newSpecieN = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newSpecieN) && specieService.IsNameUnique(newSpecieN)) {
                                specieToUpdate.Name = newSpecieN;
                                specieService.UpdateSpecie(specieToUpdate);
                                Console.WriteLine("Вид оновлено");
                            }
                            else{
                                Console.WriteLine("Помилка: Нова назва виду або не пуста або не унікальна");
                            }
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Видалення всіх видів...");
                        try{
                            specieService.DeleteAllSpecies();
                            Console.WriteLine("Всі види видалені");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Введіть Id виду для видалення: ");
                        try{
                            int idDel = Convert.ToInt32(Console.ReadLine());
                            specieService.DeleteSpecie(idDel);
                            Console.WriteLine("Вид видалено");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Введіть імя тварини для створення:");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Введіть Іd виду для створення:");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введіть вік для створення:");
                        int Age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введіть опис для створення:");
                        string Description = Console.ReadLine();
                        var newAnimal = new Animais { Name = Name, SpecieId = Id, Age = Age, Description = Description  };
                        try{
                            animalService.CreateAnimal(newAnimal);
                            Console.WriteLine("Тварина додана");
                        }
                        catch (Exception e){
                            Console.WriteLine($"Помилка: {e.Message}");
                        }
                        break;
                    case 8:
                        var list2 = animalService.GetAllAnimals();
                        Console.WriteLine("Список всіх тварин: ");
                        foreach (var s in list2){
                            var specie2 = specieService.GetSpecieById(s.SpecieId);
                            string specieName = specie2 != null ? specie2.Name : "Невідомий вид";
                            Console.WriteLine($"{s.Id}. Імя: {s.Name}, Вік: {s.Age}, Вид: {specieName}, Опис: {s.Description}");
                        }
                        break;
                    case 9:
                        try{
                            Console.WriteLine("Введіть id тварини для пошуку: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var animal = animalService.GetAnimalById(id);
                            if (animal != null){
                                Console.WriteLine($"Тварина: {animal.Name}, вік - {animal.Age}");
                            }
                            else{
                                Console.WriteLine($"Тварина за id \"{id}\" не знайдена");
                            }
                        }
                        catch (System.Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 10:
                        try{
                            Console.WriteLine("Введіть Id тварини для зміни: ");
                            int uId;
                            if (!int.TryParse(Console.ReadLine(), out uId) || uId <= 0){
                                Console.WriteLine("Помилка: Некоректний ID.");
                                break;
                            }
                            var animalToUpdate = animalService.GetAnimalById(uId);
                            if (animalToUpdate == null){
                                Console.WriteLine($"Тварина за id \"{uId}\" не знайдена");
                                break;
                            }
                            Console.WriteLine($"Поточна тварина: \"{animalToUpdate.Name}\"");
                            Console.WriteLine("Вкажіть нове ім'я (або натисніть enter, щоб залишити без змін):");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newName)){
                                animalToUpdate.Name = newName;
                            }
                            Console.WriteLine("Вкажіть новий ID виду (або 0, щоб залишити без змін):");
                            if (int.TryParse(Console.ReadLine(), out int newSpecieId) && newSpecieId > 0){
                                if (specieService.GetSpecieById(newSpecieId) != null){
                                    animalToUpdate.SpecieId = newSpecieId;
                                }
                                else{
                                    Console.WriteLine("Помилка: Виду з таким ID не існує");
                                    break;
                                }
                            }
                            Console.WriteLine("Вкажіть новий вік (або 0, щоб залишити без змін):");
                            if (int.TryParse(Console.ReadLine(), out int newAge) && newAge > 0){
                                animalToUpdate.Age = newAge;
                            }
                            Console.WriteLine("Вкажіть новий опис (або натисніть пробіл, щоб залишити без змін):");
                            string newDescription = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newDescription)){
                                animalToUpdate.Description = newDescription;
                            }
                            animalService.UpdateAnimal(animalToUpdate);
                            Console.WriteLine("Тварина оновлена в базі даних.");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;

                    case 11:
                        Console.WriteLine("Видалення всіх тварин...");
                        try{
                            animalService.DeleteAllAnimals();
                            Console.WriteLine("Всі тварини видалені");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;
                    case 12:
                        Console.WriteLine("Введіть Id тварини для видалення: ");
                        try{
                            int idDelAnimal = Convert.ToInt32(Console.ReadLine());
                            animalService.DeleteAnimal(idDelAnimal);
                            Console.WriteLine("Вид видалено");
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