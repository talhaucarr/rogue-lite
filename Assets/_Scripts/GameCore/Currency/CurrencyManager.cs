using UnityEngine;
using Utilities;

namespace _Scripts.GameCore.Currency
{
    public class CurrencyManager : AutoSingleton<CurrencyManager>
    {
        [SerializeField] private int orbCurrency;

        public int OrbCurrency => orbCurrency;
        
        public void AddCurrency(int amount)
        {
            orbCurrency += amount;
        }
        
        public void RemoveCurrency(int amount)
        {
            orbCurrency -= amount;
            if(orbCurrency < 0)
                orbCurrency = 0;
        }
    }
}
