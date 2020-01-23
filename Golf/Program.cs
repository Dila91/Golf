using System;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            Golfmanger gm = new Golfmanger();
            gm.DisplayUserInfo();

            while (gm.Swings.Count < gm.MaxAllowedStrikes)
            {
                gm.SimulateStrike();
                // The type cast truncates the decimal part of the number so we only get the integer part
                // Numbers smaller than 1 become 0, which mean our golf ball is inside a 1 meter radius from the target.
                if ((int)gm.DistanceToTarget == 0)
                {
                    Console.WriteLine("You play like a true legend. You completd the course in {0} strikes.",gm.Swings.Count);
                    break;
                }              

            }
            if (gm.Swings.Count > 10)
            {
                Console.WriteLine("Better luck next time!");
            }
            gm.PresentFinalResults();
            Console.WriteLine("Win or not, I hope you had fun!");
            Console.ReadKey();

        }
    }
}
