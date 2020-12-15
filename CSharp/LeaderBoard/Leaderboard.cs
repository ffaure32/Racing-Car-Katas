using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard
{
    public class Leaderboard
    {
        private readonly List<Race> _races = new List<Race>();

        public Leaderboard(params Race[] races)
        {
            _races.AddRange(races);
        }

        public Dictionary<string, int> DriverResults()
        {
            return new DriverResultComputer().DriverResults(_races);
        }

        public List<string> DriverRankings()
        {
            var results = DriverResults();
            var resultsList = new List<string>(results.Keys);
            resultsList.Sort();
            return resultsList;
        }
    }
}