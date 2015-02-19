using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
namespace ReadFileData
{
     delegate double MyDelegate(double t);
    public class CollectionRandom
    {
        private List<double> myOm;

        public List<double> om
        {
            get { return myOm; }
            set { myOm = listOM(); }
        }

        
        private List<double> myVar;
       
        public List<double> ol
        {
            get { return myVar; }
            set { myVar = listOL(); }
        }



        private double functionIneed(double arg)
        {


            for (int i = 0; i < om.Count;i++ )
            {
                for (int j = 0; j < ol.Count;j++ ) { 


                }
            }


            throw new NotImplementedException();
        }

        //Create OM Array 
        public List<double> listOM()
        {
          
            List<double> OM=new List<double>();
            for (double i = 0.0; i < 0.7;)
            {
                i += 0.005;
                 OM.Add(i);
            }
            return OM;
        }
        //Create OL Array 
        public List<double> listOL()
        {
            List<double> OL=new List<double>();
            for (double i = 0.0; i < 1; )
            {
                i += 0.005;
                OL.Add(i);
            }
            return OL;
        }

        
        public List<double> DistMode(List<double> zz,double om,double ol)
        {
            
            double ok = 1.0 - om - ol;
            double R0;
            List<double> dm = new List<double>();
            for (int i = 0; i < zz.Count; i++)
            {

                Hz myHz = new Hz();

                Func<double, double> myFunction = f1;
                
                double z = zz[i];
                myFunction(z);
                MathNet.Numerics.Integration.SimpsonRule.IntegrateComposite(myFunction,3.2,3.1,5);
                
            };

            if (ok < 0.0) {
                R0 = 1 / Math.Sqrt(-ok);
            }
            else
                if(ok>0.0){
                    R0 = 1 / Math.Sqrt(ok);
            }
                else{

            }
            return dm;

        }
        public static double f1(double x)
        {
            return 0;
        }
    }

    public class Hz
        {

            /*
             * this is the cosmological model we are testing, written in terms of z 
             *(redshift) instead of scale factor a
             */
            public double HzInverserse(double z, double om, double ol)
            {

                double Hz = Math.Sqrt(Math.Pow((1 + om) * z, 2) * ((om * z) + 1) - (ol * z * (z * 2)));
                double hZi = 1.0 / Hz;
                return hZi;

            }
        }
}
