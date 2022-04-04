using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_code_exam
{
    class Movie
    {
        //fields
        private string name;
        private int tickets;
        private int sales;

        //properties for each field
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int Tickets {
            get { return tickets; }
            set { tickets = value; }
        }

        public int Sales {
            get { return sales; }
            set { sales = value; }
        }
        /// <summary>
        /// constructor that creates a movie
        /// </summary>
        /// <param name="name">name of the movie</param>
        /// <param name="tickets">amount of tickets for the movie</param>
        public Movie(string name, int tickets) {
            this.name = name;
            this.tickets = tickets;
            this.sales = 0;
        }
        /// <summary>
        /// add the to the sales and detract to the amount of tickets
        /// </summary>
        /// <param name="value">amount of sales</param>
        public void AddSales(int value) {
            tickets -= value;
            sales += value;
            Console.WriteLine("You watch the movie..." + value + " times. It was good!");
        }
    }
}
