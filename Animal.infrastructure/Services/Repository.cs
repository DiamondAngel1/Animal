using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Animal.infrastructure.Services{
    public class Repository<T> : IRepository<T> where T : class{
        private readonly AnimalContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AnimalContext context){
            _context = context;
            _dbSet = context.Set<T>();
        }
        public T? GetById(int id){
            return _dbSet.Find(id);
        }
        public IEnumerable<T> GetAll(){
            return _dbSet.ToList();
        }
        public void Add(T entity){
            _dbSet.Add(entity);
        }
        public void Update(T entity){
            _dbSet.Update(entity);
        }
        public void Delete(T entity){
            _dbSet.Remove(entity);
        }
        public void SaveChanges(){
             _context.SaveChanges();
        }
    }
}
