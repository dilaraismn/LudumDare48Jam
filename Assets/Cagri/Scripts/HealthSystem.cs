using UnityEngine;

namespace Cagri.Scripts
{
    public class HealthSystem : MonoBehaviour
    {
        private int _health;
        private int _healtMax;
        
        public HealthSystem(int target)
        {
            this._healtMax = target;
            _health = target;
        }
        
        public int GetHealth()
        {
            return _health;
        }

        public float GetHealthPercent()
        {
            return _health / _healtMax;
        }

        public void TakeDamage(int target)
        {
            _health -= target;
            if (_health<0)
            {
                _health = 0;
            }
        }

        public void Heal(int target)
        {
            _health += target;
            if (_health > _healtMax)
            {
                _health = _healtMax;
            }
        }
    }
}
