using UnityEngine;

namespace Code.Character
{
    public class SpriteRandomColor : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = UnityEngine.Random.ColorHSV();
        }
    }
}