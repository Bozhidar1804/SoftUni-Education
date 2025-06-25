using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;
        public int Year { get { return year; } set { year = value; } }
        public double Pressure { get { return pressure; } set { pressure = value; } }

        public List<int> GetYearInfo(string[] splitted)
        {
            List<int> yearInfo = new List<int>();
            for (int i = 0; i < splitted.Length; i+=2)
            {
                yearInfo.Add(int.Parse(splitted[i]));
            }
            return yearInfo;
        }

        public List<double> GetPressureInfo(string[] splitted)
        {
            List<double> pressureInfo = new List<double>();
            for (int i = 1; i < splitted.Length; i += 2)
            {
                pressureInfo.Add(double.Parse(splitted[i]));
            }
            return pressureInfo;
        }

        public double GetTotalPressure(List<List<double>> listPressureInfo, int tiresIndex)
        {
            double totalPressure = 0;

            foreach (double pressure in listPressureInfo[tiresIndex])
            {
                totalPressure += pressure;
            }

            return totalPressure;
        }
    }
}
