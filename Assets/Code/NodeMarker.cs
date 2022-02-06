using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class NodeMarker : MonoBehaviour
    {
        public List<Vector2> _extraList;
        private List<Vector2> _availableDirections = new List<Vector2>();

        public IReadOnlyList<Vector2> AvailableDirections => _availableDirections;
        public void Configure(IReadOnlyList<Vector2> dirList)
        {
            _extraList = new List<Vector2>();
            foreach (var direction in dirList)
            {
                var newDir = new Vector2(direction.y, direction.x * -1f);
                _availableDirections.Add(newDir);
            }

            _extraList = _availableDirections;
        }
    }
}