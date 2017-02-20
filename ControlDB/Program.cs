using System.Collections.Generic;

namespace ControlDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            List<Match> matches = task1.GetFullMatches(task1.GetMatches());
            task1.PrintSummaryInfo(matches);

            Task2 task2 = new Task2();
            List<int> matchesIds = task2.GetAllMatchesId();
            task2.PrintDataWhoScored(matchesIds);
        }
    }
}
