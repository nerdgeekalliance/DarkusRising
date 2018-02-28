using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkusRising.Characters
{
    public struct AttributePair
    {
        private int currentValue, maximumValue, duration;

        public int CurrentValue
        {
            get { return currentValue; }
        }

        public int MaximumValue
        {
            get { return maximumValue; }
        }

        public static AttributePair Zero
        {
            get { return new AttributePair(); }
        }

        public AttributePair(ushort maxValue, int duration)
        {
            this.currentValue = maxValue;
            this.maximumValue = maxValue;
            this.duration = duration;
        }

        public void InstantHeal(ushort value) //Method that gives full health amount back
        {
            currentValue += value;
            if (currentValue > maximumValue) //If the value is greater that the maximum then it's equal to maximum
            {
                currentValue = this.maximumValue;
            }
        }

        public void Damage(ushort value)
        {
            currentValue -= value;
            if (currentValue > maximumValue)
            {
                currentValue = this.maximumValue;
            }
        }

        public void NonInstantHeal(ushort fullvalue, int duration)
        {
            int amountPerSecond = (int)(fullvalue / duration);
            for (int i = 0; i < duration; i++)
            {
                currentValue += amountPerSecond;
            }

            if (currentValue > MaximumValue)
            {
                currentValue = this.maximumValue;
            }
        }

        public void DurationDamage(ushort value, int duration)
        {
            int amountPerSecond = (int)(value / duration);
            for (int i = 0; i < duration; i++)
            {
                currentValue -= amountPerSecond;
            }
            if (currentValue > MaximumValue)
            {
                currentValue = this.maximumValue;
            }
        }

        public void SetMaximum(ushort value)
        {
            this.maximumValue = value;
            if (currentValue > MaximumValue)
            {
                currentValue = this.maximumValue;
            }
        }
    }
}