using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQLBD.Data;

namespace PostgreSQLBD.Data.Entitis{
    public static class Database{
        public static void SeedData(){
            using (Context context = new Context()){
                try{
                    if (!context.Users.Any()){
                        var users = new List<UserEntity>(){
                        new UserEntity { FName = "Іван", LName = "Мудрий", Phone="380660458699", Birthday = new DateOnly(2000,02,23)},
                        new UserEntity { FName = "Мальвіна", LName = "Деревяна", Phone="38095036831", Birthday = new DateOnly(2004,01,12)},
                        new UserEntity { FName = "Семен", LName = "Кличко", Email = "KlychkoSemen@gmail.com", Phone="380862957211", Birthday = new DateOnly(1998,06,10)},
                        new UserEntity { FName = "Раїса", LName = "Білка", Phone="380798478293", Birthday = new DateOnly(2006,08,05)},
                        new UserEntity { FName = "Петро", LName = "Святий", Email="Sviatiy88@ua.fm",Phone="380237889543", Birthday = new DateOnly(1988,01,14)}
                    };
                        context.Users.AddRange(users);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex){
                    Console.WriteLine($"Якась помилка: {ex.Message}");
                }
            }
        }
        public static void DeleteUsers(){
            using (Context context = new Context()){
                if (context.Users.Any()){
                    foreach (var user in context.Users){
                        context.Users.Remove(user);
                    }
                    context.SaveChanges();
                }
            }
        }
        public static void PrintUsers(){
            using (Context context = new Context()){
                foreach (var i in context.Users){
                    Console.WriteLine($"{i.Id} {i.FName}, {i.LName}, {i.Email}, {i.Phone}, {i.Birthday}");
                }
            }
        }
        public static void SearchId(int id){
            using (Context context = new Context()){
                var user = context.Users.Find(id);
                if (user != null){
                    Console.WriteLine($"Користувач: {user.FName} {user.LName}, {user.Email}, {user.Phone}, {user.Birthday} ");
                }
                else{
                    Console.WriteLine("Користувача не знайдено");
                }
            }
        }
        public static void UpdateUser(int id, string newFName, string newLName, string newEmail, string newPhone){
            using (Context context = new Context()){
                var user = context.Users.Find(id);
                if (user != null){
                    if (!string.IsNullOrEmpty(newFName)){
                        user.FName = newFName;
                    }
                    if (!string.IsNullOrEmpty(newLName)){
                        user.LName = newLName;
                    }
                    if (!string.IsNullOrEmpty(newEmail)){
                        user.Email = newEmail;
                    }
                    if (!string.IsNullOrEmpty(newPhone)){
                        user.Phone = newPhone;
                    }
                    context.SaveChanges();
                    Console.WriteLine("Користувач оновлений");
                }
                else{
                    Console.WriteLine("Користувача не знайдено");
                }
            }
        }
    }
}