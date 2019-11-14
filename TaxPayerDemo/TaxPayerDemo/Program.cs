﻿using System;
using System.Threading;

using static System.Console;

namespace TaxPayerDemo {
    class Taxpayer {
        public Taxpayer(int ssn, double yearGross) {
            this.ssn = ssn;
            this.yearGross = yearGross;
            owedIncomeTax = yearGross < 30000 ? yearGross - (yearGross * 0.15) : yearGross - (yearGross * 0.28);
        }

        public int ssn { get; set; }
        public double yearGross { get; set; }
        public double owedIncomeTax { get; }
    }
    class Program {
        static void Main(string[] args) {
            bool auto = true;
            Random random = new Random();

            Taxpayer[] taxpayers = new Taxpayer[10];
            for (int i = 0; i < 10; ++i) {
                int ssn;
                bool ssnValid = false;
                do {
                    Write("Enter Taxpayer #{0} ssn: ", i + 1);
                    if (auto) {
                        ssnValid = true;
                        ssn = random.Next(111111111, 999999999);
                        Thread.Sleep(550);
                        WriteLine("{0}", ssn);
                    }
                    else {
                        ssnValid = int.TryParse(ReadLine(), out ssn);
                    }
                } while (!ssnValid);

                double yearGross;
                bool yearGrossValid = false;
                do {
                    Write("Enter Taxpayer #{0} yearly gross income: ", i + 1);
                    yearGrossValid = true;
                    if (auto) {
                        yearGrossValid = true;
                        yearGross = random.Next(25000, 48000);
                        Thread.Sleep(550);
                        WriteLine("{0}", yearGross);
                    }
                    else {
                        yearGrossValid = double.TryParse(ReadLine(), out yearGross);
                    }
                } while (!yearGrossValid);

                Taxpayer taxpayer = new Taxpayer(ssn, yearGross);
                taxpayers[i] = taxpayer;
            }

            WriteLine("{0, 10} --------------- {1, 10} --------------- {2, 10}", "SSN", "Income", "Owed Tax");
            foreach (Taxpayer payer in taxpayers) {
                WriteLine("{0, 10}                 {1, 10}                 {2, 10}", payer.ssn, payer.yearGross, payer.owedIncomeTax.ToString("F"));
            }
        }
    }
}
