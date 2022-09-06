using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.HealthSystem
{
    public class HpSlider
    {
        private Image hpBar;
        
        public HpSlider(Image hpBar)
        {
            this.hpBar = hpBar;
        }

        public void SetHp(float hp)
        {
            hpBar.fillAmount = hp;
        }
        
        public void ResetSlider()
        {
            hpBar.fillAmount = 1f;
        }
    }
}