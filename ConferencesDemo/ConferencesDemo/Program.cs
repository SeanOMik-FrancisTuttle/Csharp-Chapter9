using System;
using System.Threading;

using static System.Console;

namespace ConferencesDemo {
    class Conference : IComparable<Conference> {
        public Conference(string group, string startingDate, int attendees) {
            this.group = group;
            this.startingDate = startingDate;
            this.attendees = attendees;
        }

        public string group { get; set; }
        public string startingDate { get; set; }
        public int attendees { get; set; }

        public int CompareTo(Conference that) {
            if (this.attendees > that.attendees) return -1;
            if (this.attendees == that.attendees) return 0;
            return 1;
        }
    }

    class Program {
        static DateTime RandomDay() {
            Random gen = new Random();
            DateTime start = new DateTime(2015, 8, 21);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        static void Main(string[] args) {
            bool auto = true;
            string autoConferenceName = "E3 2019 - ";
            Random random = new Random();
            int msWait = 0;
            if (auto) WriteLine("RUNNING AUTO, DON'T TYPE ANYTHING!");

            Conference[] conferences = new Conference[5];
            for (int i = 0; i < 5; ++i) {
                string conference;
                Write("Enter Conference #{0} Name: ", i + 1);
                if (auto) {
                    Thread.Sleep(msWait);
                    conference = autoConferenceName + (i + 1);
                    WriteLine("{0}", conference);
                } else {
                    conference = ReadLine();
                }

                string date;
                Write("Enter Conference #{0} Date: ", i + 1);
                if (auto) {
                    Thread.Sleep(msWait);
                    date = RandomDay().ToString();
                    WriteLine("{0}", date);
                }
                else {
                    date = ReadLine();
                }

                int amount;
                bool amountValid = false;
                do {
                    Write("Enter Conference #{0} Amount of Attendees: ", i + 1);
                    if (auto) {
                        amountValid = true;
                        Thread.Sleep(msWait);
                        amount = random.Next(25, 250);
                        WriteLine("{0}", amount);
                    }
                    else {
                        amountValid = int.TryParse(ReadLine(), out amount);
                    }
                } while (!amountValid);

                Conference conferenceObj = new Conference(conference, date, amount);
                conferences[i] = conferenceObj;
            }

            WriteLine("CompareTo key: (> = -1 | < = 1 | == = 0)");
            WriteLine("{0, 12} ---------------{1, 22} --------------- {2, 10} --------------- CompareTo:", "Conference", "------------------- Date", "Attendees");
            Conference last = null;
            foreach (Conference conference in conferences) {
                int isLarger = 0;
                if (last != null) {
                    isLarger = conference.CompareTo(last);
                }
                WriteLine("{0, 12}                 {1, 22}                 {2, 10}                 {3, 3}", conference.group, conference.startingDate, conference.attendees, isLarger);
                last = conference;
            }
        }
    }
}
