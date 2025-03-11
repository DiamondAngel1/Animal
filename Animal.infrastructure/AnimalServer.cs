using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.infrastructure.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Animal.infrastructure{
    public class AnimalService{
        private readonly AnimalContext _context;
        private readonly DbSet<Animais> _dbSet;
        private readonly DbSet<Specie> _dbSetSpecie;
        public AnimalService(AnimalContext context){
            _context = context;
            _dbSet = _context.Set<Animais>();
            _dbSetSpecie = _context.Set<Specie>();
        }
        public bool IsAnimalNameUnique(string name){
            return !_dbSet.Any(a => a.Name == name);
        }
        public bool IsValidSpeciesId(int? speciesId){
            return speciesId == null || _dbSetSpecie.Any(s => s.Id == speciesId.Value);
        }
        public void CreateAnimal(Animais animal){
            if (string.IsNullOrEmpty(animal.Name)){
                throw new ArgumentException("Назва тварини не може бути пустою");
            }
            if (!IsAnimalNameUnique(animal.Name)){
                throw new ArgumentException($"Назва тварини повинна бути унікальною. Тварина з назвою \"{animal.Name}\" вже існує");
            }
            if (!IsValidSpeciesId(animal.SpecieId)){
                throw new ArgumentException("Вказаний вид не існує");
            }
            if (animal.Age < 0){
                throw new ArgumentException("Вік тварини не може бути від'ємним");
            }
            _dbSet.Add(animal);
            _context.SaveChanges();
        }
        public Animais? GetAnimalById(int id){
            return _dbSet.Find(id);
        }
        public IEnumerable<Animais> GetAllAnimals(){
            return _dbSet.ToList();
        }
        public void UpdateAnimal(Animais animal){
            if (string.IsNullOrEmpty(animal.Name)){
                throw new ArgumentException("Назва тварини не може бути пустою");
            }
            if (!IsAnimalNameUnique(animal.Name)){
                throw new ArgumentException($"Назва тварини повинна бути унікальною. Тварина з назвою \"{animal.Name}\" вже існує");
            }
            if (!IsValidSpeciesId(animal.SpecieId)){
                throw new ArgumentException("Вказаний вид не існує");
            }
            if (animal.Age < 0){
                throw new ArgumentException("Вік тварини не може бути від'ємним");
            }
            _dbSet.Update(animal);
            _context.SaveChanges();
        }
        public void DeleteAnimal(int id){
            var animal = _dbSet.Find(id);
            if (animal == null){
                throw new ArgumentException("Тварину не знайдено");
            }
            _dbSet.Remove(animal);
            _context.SaveChanges();
        }
        public void DeleteAllAnimals(){
            _dbSet.RemoveRange(_dbSet.ToList());
            _context.SaveChanges();
        }
    }
}
