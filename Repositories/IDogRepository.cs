using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetDogById(int id);
        void UpdateDog(Dog dog);
        void DeleteDog(int dogId);
        void AddDog(Dog dog);
        List<Dog> GetDogsByOwnerId(int ownerId);

    }
}
