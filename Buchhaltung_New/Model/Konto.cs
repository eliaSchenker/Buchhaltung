using System;
using System.Collections.Generic;
using System.Text;

namespace Buchhaltung_New.Model
{
    public class Konto
    {
        public string name;
        public bool isActive;
        public float currentValue;

        public Konto(string name, bool isActive, float currentValue)
        {
            this.name = name;
            this.isActive = isActive;
            this.currentValue = currentValue;
        }

        /// <summary>
        /// Process a Buchung by checking if the Konto is passive or active and subtracting/adding the value
        /// </summary>
        /// <param name="betrag">The amount of the Buchung</param>
        /// <param name="leftSide">Is the Konto on the left or right side of the Buchung</param>
        public void buchung(float betrag, bool leftSide)
        {
            if (leftSide)
            {
                currentValue += (isActive) ? betrag : -betrag;
            }
            else
            {
                currentValue += (isActive) ? -betrag : betrag;
            }
        }
    }
}
