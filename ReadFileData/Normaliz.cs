﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;


namespace ReadFileData
{
   public class Normaliz
    {
    
       const double H0 = 7.0;
       double c_H0 = 3.0 * Math.Exp(5)/H0;

        public List<double> normilizeList()
        {

            List<double> normolizeNumbers = new List<double>();

            double mscrGuess = 5 * ((Math.Log10(c_H0) + 25));
            double mscrLo = mscrGuess - 0.05;
            double mscrHi = mscrGuess + 0.05;
         const double mscr_step = 0.005;

            for (double i = mscrLo; i < mscrHi; i += mscr_step)
            {
                normolizeNumbers.Add(i);
            }
            return normolizeNumbers;
        }




    }
}
