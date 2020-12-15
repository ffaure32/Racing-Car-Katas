using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard
{
    public class DriverResultComputer
    {
        public Dictionary<string, int> DriverResults(List<Race> _races)
        {
            var results = new Dictionary<string, int>();
            foreach (var race in _races)
            {
                foreach (var driver in race.Results)
                {
                    var driverName = race.GetDriverName(driver);
                    var points = race.GetPoints(driver);
                    if (results.ContainsKey(driverName))
                    {
                        results[driverName] = results[driverName] + points;
                    }
                    else
                    {
                        results.Add(driverName, 0 + points);
                    }
                }
            }
            return results;
        }

    }
}