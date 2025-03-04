using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.infrastructure.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Animal.infrastructure{
    public class SpecieService{
        private readonly AnimalContext _context;
        private readonly DbSet<Specie> _dbSet;
        public SpecieService(){
            _context = new AnimalContext();
            _dbSet = _context.Set<Specie>();
        }
        public bool IsNameUnique(string name){
            return !_dbSet.Any(s => s.Name == name);
        }
        public void CreateSpecie(Specie specie){
            if (string.IsNullOrEmpty(specie.Name)){
                throw new System.ArgumentException("Назва виду не може бути пустою");
            }

            if (!IsNameUnique(specie.Name))
            {
                throw new System.ArgumentException($"Назва виду повинна бути унікольною. Вид: \"{specie.Name}\" вже існує");
            }
            _dbSet.Add(specie);
            _context.SaveChanges();
        }
        public Specie? GetSpecieById(int id){
            return _dbSet.Find(id);
        }
        public IEnumerable<Specie> GetAllSpecies(){
            return _dbSet.ToList();
        }
        public void UpdateSpecie(Specie specie){
            if (string.IsNullOrEmpty(specie.Name)){
                throw new System.ArgumentException("Назва виду не може бути пустою");
            }
            if (!IsNameUnique(specie.Name)){
                throw new System.ArgumentException("Назва виду повинна бути унікольною. Вид: \"{specie.Name}\" вже існує");
            }
            _dbSet.Update(specie);
            _context.SaveChanges();
        }
        public void DeleteSpecie(int id){
            var specie = _dbSet.Find(id);
            if (specie == null){
                throw new System.ArgumentException("Вид не знайдено");
            }
            _dbSet.Remove(specie);
            _context.SaveChanges();
        }
        public void DeleteAllSpecies(){
            _dbSet.RemoveRange(_dbSet.ToList());
            _context.SaveChanges();
        }
    }
}
