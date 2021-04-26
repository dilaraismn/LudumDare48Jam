using UnityEngine;

namespace Cagri.Scripts
{
    public interface IEnemy
    {
        public void OnPlayerHit();

        public void OnActive();

        public void OnDeActive();


    }
}
