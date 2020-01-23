using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class Swing
    {
        public Swing(int ang, int vel, double dist)
        {
            Angle = ang;
            Velocity = vel;
            Distance = dist;
        }
        public int Angle { get; set; }
        public int Velocity { get; set; }
        public double Distance { get; set; }
    }
}
