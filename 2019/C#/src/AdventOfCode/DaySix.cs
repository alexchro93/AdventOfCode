using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
   public static class DaySix
   {
      public static int ProblemOne(IEnumerable<(string, string)> inp)
      {
         var orbits = inp.GroupBy(x => x.Item1)
            .ToDictionary(x => x.Key, x => x.Select(i => i.Item2).ToList());
        
         var com = new Planet("COM", 0);
         Add(com, orbits);
         
         return FindTotalOrbits(com);
      }

      public static int ProblemTwo(IEnumerable<(string, string)> inp)
      {
         var orbits = inp.GroupBy(x => x.Item1)
            .ToDictionary(x => x.Key, x => x.Select(i => i.Item2).ToList());

         var you = orbits.First(o => o.Value.Contains("YOU")).Key;
         var santa = orbits.First(o => o.Value.Contains("SAN")).Key;

         var com = new Planet("COM", 0);
         Add(com, orbits);

         var youPath = FindPath(com, you);
         var santaPath = FindPath(com, santa);

         var youUnique = youPath.Except(santaPath).Count();
         var santaUnique = santaPath.Except(youPath).Count();

         return youUnique + santaUnique;
      }

      private static List<string> FindPath(Planet start, string target)
      {
         if (start.Name == target)
            return new List<string> { start.Name };

         foreach (var desc in start.Orbiters)
         {
           var ret = FindPath(desc, target);
           if (ret.Count > 0) 
              return ret.Prepend(start.Name).ToList();
         }

         return new List<string>();
      }
      
      private static int FindTotalOrbits(Planet p)
      {
         var sum = 0;
         foreach (var o in p.Orbiters)
            sum += FindTotalOrbits(o);
         return sum + p.Depth;
      }
      
      private static void Add(Planet r, Dictionary<string, List<string>> orbits)
      {
         if (!orbits.ContainsKey(r.Name)) return;
         
         var planetsToAdd = orbits[r.Name].Select(x => new Planet(x, r.Depth + 1));
         foreach (var p in planetsToAdd)
         {
            r.Orbiters.Add(p);
            Add(p, orbits);
         }
      }
      
      private class Planet
      {
         public Planet(string name, int depth)
         {
            Name = name;
            Depth = depth;
         }
           
         public string Name { get; }
         public int Depth { get; }
         public List<Planet> Orbiters { get; } = new List<Planet>();
      }
   }
}
