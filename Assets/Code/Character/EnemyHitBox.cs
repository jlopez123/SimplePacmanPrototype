using UnityEngine;

namespace Code.Character
{
    public class EnemyHitBox : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var hittable = other.GetComponentInParent<ITakeHit>();
            if(hittable == null)
                return;
            
            if (hittable.CanTakeHit == false)
                return;

            
            hittable.TakeHit(_damage);
        }
    }
}