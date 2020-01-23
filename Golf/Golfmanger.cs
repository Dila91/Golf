using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class Golfmanger
    {
        public Golfmanger() /*constructor*/
        {
            InitializeCourseLength();
            Swings = new List<Swing>();
        }

        private int CourseLength;
        public int MaxAllowedStrikes = 10; /*field*/
        public double TotalDistanceTravelled { get; set; } /*properetis.*/
        public double DistanceToTarget { get; set; }

        public List<Swing> Swings { get; set; }


        private void InitializeCourseLength() /*method*/
        {
            Random rnd = new Random();
            CourseLength = rnd.Next(600, 800);

        }
        public void DisplayUserInfo()
        {
            Console.WriteLine("The length of te course is: {0}", CourseLength);
            Console.WriteLine("You have a total of {0} attempts to finish the course", MaxAllowedStrikes);

        }

        public void SimulateStrike()
        {

            int userVelocity = 0;
            Console.Write("Input the velocity: ");
            try
            {
                userVelocity = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("User velocity used is now equal to 10");
                userVelocity = 10;
            }

            Console.Write("Input the angle: ");
            int userAngle = int.Parse(Console.ReadLine());

            double angleInRedians = (Math.PI / 180) * userAngle;
            //Console.WriteLine(angleInRedians);
            double distance = Math.Pow(userVelocity, 2) / 9.8 * Math.Sin(2 * angleInRedians);
            Console.WriteLine("The glof ball travelled: {0:0.00}", distance);

            TotalDistanceTravelled = TotalDistanceTravelled + distance;

            Swing mySwing = new Swing(userAngle, userVelocity, distance);

            Swings.Add(mySwing);
            DistanceToTarget = CourseLength - TotalDistanceTravelled;
            if (DistanceToTarget < 0)
            {
                TotalDistanceTravelled = CourseLength + DistanceToTarget;
            }
            DisplayUsefulStatsToUser();

            //CreaTE SWING OBJECT AND SAVE DATA

        }

        public void DisplayUsefulStatsToUser()
        {
            //Console.Clear();
            Console.WriteLine("----------------------------------------------------------");
            Console.Write("Strike {0}. You have {1} swings left. ",Swings.Count, MaxAllowedStrikes - Swings.Count);
            if (DistanceToTarget < 0)
            {
                Console.WriteLine("Your strike was too hard. Distance to target: {0:0.00}", Math.Abs(DistanceToTarget));
            }
            else
            {
                Console.WriteLine("Distance to target: {0:0.00}", DistanceToTarget);
            }
        }

        public void PresentFinalResults()
        {
            Console.WriteLine("These are the hard facts");
            foreach (Swing item in Swings)
            {
                Console.WriteLine("Swing {0}: Velocity: {1}, Angle: {2}, Distance: {3:0.00}", Swings.IndexOf(item) + 1, item.Velocity, item.Angle, item.Distance);
            }
        }

    }
}
