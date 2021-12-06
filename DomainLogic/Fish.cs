using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLogic
{
    public class Fish
    {
        private int internalTimer;
        private List<Fish> schoolOfFish;
        public Fish(int internalTimer, List<Fish> schoolOfFish)
        {
            this.internalTimer = internalTimer;
            this.schoolOfFish = schoolOfFish;
            this.schoolOfFish.Add(this);
        }

        public int Timer => internalTimer;

        public void LiveADay()
        {
            internalTimer -= 1;
            if (internalTimer < 0)
            {
                internalTimer = 6;
                var newFish = new Fish(8, schoolOfFish);
            }
        }
    }
}
