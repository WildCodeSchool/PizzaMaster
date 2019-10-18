using System;
namespace PizzaMaster
{
    public class PizzaCart
    {
        private int _pizzaCount;
        public PizzaCart(int maxPizzas)
        {
            MaxPizzas = maxPizzas;
        }

        public int PizzaCount 
        {
            get
            {
                return _pizzaCount;
            }
            set {
                if (value < 0)
                {
                    _pizzaCount = 0;
                }
                else if (value > MaxPizzas)
                {
                    _pizzaCount = MaxPizzas;
                }
                else
                {
                    _pizzaCount = value;
                }
            } 
        }

        public int MaxPizzas
        {
            get; private set;
        }
    }
}
