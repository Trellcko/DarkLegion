using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkLegion.Unit 
{
    public static class UnitExtension
    {
        public static List<ComponentStorage> SortByInitiative(List<ComponentStorage> units)
        {
            var sorted = units.OrderByDescending(x => x.Reaction.Value).ToList();
            return sorted;
        }
    }
}