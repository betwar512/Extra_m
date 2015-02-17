using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFileData
{
   public class Normaliz
    {
       const double HO = 7.0;
       const double c_H0 = 3.00 / HO;
      
       public double x {get;set;}
       public void normilizeList(){

           List<double> normolizeNumbers =new List<double>(); 
     double mscrGuess  = 5.0*((Math.Log10(c_H0)+25));
    double  mscrLo=mscrGuess - 0.05;
           double mscrHi=mscrGuess +0.05;
       double  mscr_step  = 0.005;
       for (double i = mscrLo; i < mscrHi;i+=mscr_step){
           normolizeNumbers.Add(i);
            }    
       }
    }
}
