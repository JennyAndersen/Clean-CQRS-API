using Domain.Models;
using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByIdAsync(Guid id);
        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(Guid id);
    }
}
