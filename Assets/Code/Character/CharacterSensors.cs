using UnityEngine;

namespace Code.Character
{
    public class CharacterSensors : MonoBehaviour
    {
        [SerializeField] float _maxDistanceRay;
        [SerializeField] private LayerMask _wallLayerMask;
        [SerializeField] private Transform[] _sensorPoints;
        [SerializeField] private Transform _sensorRoot;
    
        public bool CheckForWallInDirection(Vector2 direction)
        {
            /* Works better at high speeds
          
        var hit = Physics2D.BoxCast(transform.position, Vector2.one * _maxDistanceRay, 0f, direction, _maxDistanceRay, _wallLayerMask);
        Debug.DrawRay(transform.position, direction *_maxDistanceRay, Color.blue);
        if(hit.collider != null)
            Debug.Log(hit.collider.name);
        return hit.collider != null;
        */
                
            var angle = Mathf.Atan2(direction.y, direction.x) * 180f / Mathf.PI;
            _sensorRoot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            var hits = 0;
            foreach (var sensorPoint in _sensorPoints)
            {
                var raycastHit = Physics2D.Raycast(sensorPoint.position, direction, _maxDistanceRay, _wallLayerMask);
                Debug.DrawRay(sensorPoint.position, direction * _maxDistanceRay, Color.red);

                if (raycastHit.collider != null)
                    hits++;
            }
        
            _sensorRoot.rotation = Quaternion.identity;
            return hits > 0;
        }
    }
}