using DogGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAllWalks();
        List<Walk> GetWalksByWalkerId(int walkerId);
        //void UpdateWalk(Walk owner);
        //void DeleteWalk(int ownerId);
        //void AddWalk(Owner owner);

    }
}
