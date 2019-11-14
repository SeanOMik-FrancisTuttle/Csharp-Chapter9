using System;

using static System.Console;

namespace TestCalssifiedAd {
    class ClassifiedAd {
        public ClassifiedAd(string category, int numberOfWords) {
            this.category = category;
            this.numberOfWords = numberOfWords;
            this.price = Math.Round(numberOfWords * 0.09 / 100d, 0) * 100;
        }
        public string category { get; set; }
        public int numberOfWords { get; set; }
        public double price { get; }
    }
    class Program {
        static void Main(string[] args) {
            ClassifiedAd ad = new ClassifiedAd("Experimental", 10);
            WriteLine("Category: {0, 10} Number of Words: {1, 3} Price: {2, 5} ", ad.category, ad.numberOfWords, ad.price);
        }
    }
}
