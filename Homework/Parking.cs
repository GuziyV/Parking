﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return lazy.Value; } }

        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
        }

        public List<Car> Cars { get; private set; }
        public List<Transaction> Transactions { get; private set; }
        public decimal Balance { get; private set; }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public void ShowLastMinuteTransaction()
        {
            var lastMinuteTransactins = Transactions.Where<Transaction>(t => DateTime.Now - t.TransactionTime < new TimeSpan(0,1,0));
            foreach(var transaction in  lastMinuteTransactins)
            {
                Console.WriteLine(transaction);
            }
        }

        public void AddMoney(decimal amount)
        {
            Balance += amount;
        }

        public void AddCarMoney(uint carId, decimal value)
        {

            Car car = Cars.First<Car>(c => c.Id == carId); //TODO not found exception
            car.GiveMoney(value);
            

        }
    }
}
