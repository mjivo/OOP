namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Pizza
    {
        private string _name;
        private double _totalCal;
        private Dough _dough;
        private List<Toppings> _toppings;
        public Pizza(string _name)
        {
            this.Name = _name;
            this._toppings = new List<Toppings>();
        }
        public Dough Dough
        {
            private get => this._dough;
            set
            {
                this._dough = value;
                this._totalCal += _dough.CaloriesPerGram;
            }
        }
        public string Name
        {
            get => this._name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this._name = value;
            }
        }
        public int NumOfToppings => this.Toppings.Count;
        public IReadOnlyList<Toppings> Toppings { get => this._toppings; }
        public double TotalCalories { get => _totalCal; }
        public void AddToppings(Toppings _toppings)
        {
            if (this.NumOfToppings == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this._toppings.Add(_toppings);
            this._totalCal += _toppings.CaloriesPerGram; 
        }
    }
}
