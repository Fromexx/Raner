using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IUnitSpawnAndDelete
    {
        List<GameObject> SpawnUnits(int unitsCount);
        void DeleteUnits(int unitsCount, ref List<GameObject> units);
    }
}