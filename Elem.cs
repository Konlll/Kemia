using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Elem
    {
        private string year;
        private string name;
        private string sign;
        private string plateNumber;
        private string explorer;

        public Elem(string year, string name, string sign, string plateNumber, string explorer)
        {
            this.year = year;
            this.name = name;
            this.sign = sign;
            this.plateNumber = plateNumber;
            this.explorer = explorer;
        }

        public string Year { get => year; }
        public string Name { get => name; }
        public string Sign { get => sign; }
        public string PlateNumber { get => plateNumber; }
        public string Explorer { get => explorer; }


    }
}
