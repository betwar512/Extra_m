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


        public List<double> DistMod(List<double> zz, double om, double ol)
        {

            double ok = 1.0 - om - ol;
            double R0;

            List<double> x = new List<double>();
            //list D
            List<double> DM = new List<double>();
            double X = 0;

            for (int i = 0; i < zz.Count; i++)
            {


                //delegate pointer for function f
                Func<double, double> myFunction = f;
                //pointer
                selectedZ = zz[i];
                X = MathNet.Numerics.Integration.SimpsonRule.IntegrateComposite(myFunction, selectedZ, 4, 20);
                var roundedX = Math.Round(X, 4);
                x.Add(roundedX);
            };

            if (ok < 0.0)
            {
                R0 = 1 / Math.Sqrt(-ok);
                x.ForEach(delegate(double t)
                {
                    double y = R0 * Math.Sin(t / R0);
                });

            }
            else
                if (ok > 0.0)
                {
                    R0 = 1 / Math.Sqrt(ok);
                    x.ForEach(delegate(double t)
                    {
                        double y = R0 * Math.Sinh(t / R0);
                    });
                    //  D = R0 * Math.Sinh(X / R0);
                }
            //else
            //{

            //   D = X;
            //}

            for (int i = 0; i < zz.Count; i++)
            {
                double ran = x[i] * (1 + zz[i]);

                double y = 5 * Math.Log10(ran);
                DM.Add(y);
            }


            //    double lumDist = D * (1 + selectedZ);
            //   double DM = 5 * Math.Log10(lumDist);
            //   dm.Add(DM);
            return DM;
        }
        public double f(double z)
        {
            var x = omI;
            var y = olI;

            double t = HzInverserse(z, x, y);
            return t;
        }

        public double HzInverserse(double z, double om, double ol)
        {

            double Hz = Math.Sqrt(Math.Pow((1 + om) * z, 2) * ((om * z) + 1) - (ol * z * (z * 2)));
            double hZi = 1.0 / Hz;
            return hZi;

        }

        public double selectedZ { get; set; }
        public double omI { get; set; }
        public double olI { set; get; }
    }

   
}
