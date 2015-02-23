using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;
using System.Xml.Serialization;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public double omI { get; set; }
        public double olI { set; get; }

        public List<double> om { get; set; }
        public List<double> ol { get; set; }

        public double selectedZ { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
            //dmList init here to have keep data 
            List<double> myList = new List<double>();
            xmlSerialiser serelize = new xmlSerialiser();

            List<double> myZZ = new List<double>();
            var myData = serelize.deserilizer("d:/temp/new2.xml");
            foreach (var w in myData)
            {
                string t = w.Z;
                double b = Convert.ToDouble(t);
                myZZ.Add(b);
               
            }
            om = listOM();
            ol = listOL();
        //for(int i=0,j=0;i<om.Count&&ol.Count;i++,j++)
            for (int i = 0; i < om.Count; i++)
            {
                for (int j = 0; j < ol.Count; j++)
                {
                    omI = om[i];
                    olI = ol[j];
                  
                    double muModel = DistMode(myZZ, omI, olI, myList);
                    Normaliz normal = new Normaliz();
                    List<double> mscr = normal.normilizeList();
                  //var m = Matrix<double>.Build.Random(ol.Count, om.Count);
                 // var mu_model = Matrix<double>.Build.Random(myZZ.Count, myZZ.Count);

                   
                    for (int k = 0; k < mscr.Count; k++)
                    {

                     double  mu_model_norm = muModel + mscr[k];
                     


                    }
                }
            }

            Assert.IsNotNull(myList.Count);
        }

        //DisMode
        public double DistMode(List<double> zz, double om, double ol, List<double> dm)
        {

            double ok = 1.0 - om - ol;
            double R0;
            double D;
            double X = 0;

            for (int i = 0; i < zz.Count; i++)
            {


                //delegate pointer for function f
                Func<double, double> myFunction = f;
                //pointer
                selectedZ = zz[i];
                X = MathNet.Numerics.Integration.SimpsonRule.IntegrateComposite(myFunction, selectedZ, 4, 20);

            };

            if (ok < 0.0)
            {
                R0 = 1 / Math.Sqrt(-ok);
                D = R0 * Math.Sin(X / R0);
            }
            else
                if (ok > 0.0)
                {
                    R0 = 1 / Math.Sqrt(ok);
                    D = R0 * Math.Sinh(X / R0);
                }
                else
                {
                    D = X;
                }
            double lumDist = D * (1 + selectedZ);
            double DM = 5 * Math.Log10(lumDist);
            dm.Add(DM);
            return DM;
        }
        //Function f
        public double f(double z)
        {
            var x = omI;
            var y = olI;

            double t = HzInverserse(z, x, y);
            return t;
        }

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
        //Create OM Array 
        public List<double> listOM()
        {

            List<double> OM = new List<double>();
            for (double i = 0.0; i < 0.7; )
            {
                i += 0.005;
                OM.Add(i);
            }
            return OM;
        }
        //Create OL Array 
        public List<double> listOL()
        {
            List<double> OL = new List<double>();
            for (double i = 0.0; i < 1; )
            {
                i += 0.005;
                OL.Add(i);
            }
            return OL;
        }

    }

    public class Normaliz
    {

        const double H0 = 7.0;
        double c_H0 = 3.0 * Math.Exp(5) / H0;

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

    public class xmlSerialiser
    {
        /*
         * xml serilizer method to create xml file from our text file typeOf (dataModel)
         *methos 2 input 
         *path= text file path
         *xmlPath = xml file path 
         */
        public void seriliser(string path, string xmlPath)
        {

            List<DataModel> myList = new List<DataModel>();
            //int counter = 0;
            //string line;

            // Read the file all the lines
            string[] lines = File.ReadAllLines(path);
            //create file 
            //System.IO.StreamWriter file = new System.IO.StreamWriter(
            //          @"d:\temp\newXml.xml");

            foreach (string s in lines)
            {
                var temp = new List<string>();
                string[] x = s.Split(null);
                foreach (var z in x)
                {
                    //delete space in Array
                    if (!string.IsNullOrEmpty(z))
                        temp.Add(z);
                }
                x = temp.ToArray();


                DataModel myObject = new DataModel();
                //  CID Z ZERR MU MUERR AV AVERR DELTA DELTAERR PKMJD PKMJDERR RV RVERR CHI2 NDOF IDTEL
                myObject.CID = x[1];
                myObject.Z = x[2];
                myObject.ZERR = x[3];
                myObject.MU = x[4];
                myObject.MUERR = x[5];
                myObject.AV = x[6];
                myObject.AVERR = x[7];
                myObject.DELTA = x[8];
                myObject.DELTAERR = x[9];
                myObject.PKMJD = x[10];
                myObject.PKMJDERR = x[11];
                myObject.RV = x[12];
                myObject.RVERR = x[13];
                myObject.CHI2 = x[14];
                myObject.NDOF = x[15];
                myObject.IDTEL = x[16];

                ////write to the file from model 
                //    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DataModel), new XmlRootAttribute("slabs"));
                //    writer.Serialize(file, myObject);
                myList.Add(myObject);

            }//end of for loop
            //close file 
            //file.Close();
            //create the serialiser to create the xml
            using (var stream = File.Create(xmlPath))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(List<DataModel>));
                // Create the TextWriter for the serialiser to use
                serialiser.Serialize(stream, myList);
            }

        }
        /*
         * Deserializer for DataModel -> xml to Array list in memory 
         *path == xml file path
         */
        public List<DataModel> deserilizer(string path)
        {
            //   DataModel myO;
            List<DataModel> myObjects = null;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<DataModel>));
            // read file
            StreamReader reader = new StreamReader(path);
            // Call the Deserialize method and cast to the object type.
            myObjects = (List<DataModel>)mySerializer.Deserialize(reader);
            return myObjects;
        }

    }

    public class DataModel
    {
        //  CID Z ZERR MU MUERR AV AVERR DELTA DELTAERR PKMJD PKMJDERR RV RVERR CHI2 NDOF IDTEL

        public string CID { get; set; }
        public string Z { get; set; }
        public string ZERR { get; set; }
        public string MU { get; set; }
        public string MUERR { get; set; }
        public string AV { get; set; }
        public string AVERR { get; set; }
        public string DELTA { get; set; }
        public string DELTAERR { get; set; }
        public string PKMJD { get; set; }
        public string PKMJDERR { get; set; }
        public string RV { get; set; }
        public string RVERR { get; set; }
        public string CHI2 { get; set; }
        public string NDOF { get; set; }
        public string IDTEL { get; set; }
        public DataModel()
        {

        }

    }
}
