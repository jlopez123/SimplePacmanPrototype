using Code.EventQueue;
using UnityEngine;

namespace Code.Installers
{
    public class EnemySpawnerInstaller : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Start()
        {
            EventQueueImpl.Instance.Subscribe(EventIds.OnEndGame, _enemySpawner);
        }
    }
}