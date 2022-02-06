using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Character;
using Code.Character.Input;
using Code.EventQueue;
using UnityEngine;

namespace Code
{
    public class EnemySpawner : MonoBehaviour, IEventObserver
    {
        [SerializeField] private GameUnitController _enemyPrefab;
        [SerializeField] private int _amountOfEnemies = 4;
    
        private List<NodeMarker> _nodeMarkers;

        private List<GameUnitController> _enemies;

        public void StartSpawning(List<NodeMarker> nodeMarkers)
        {
            _nodeMarkers = nodeMarkers;
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            _enemies = new List<GameUnitController>();
            
            for (var i = 0; i < _amountOfEnemies; i++)
            {
                var nodeMarkerToSpawn = GetRandomNodeMarker();
                var enemy = Instantiate(_enemyPrefab, nodeMarkerToSpawn.transform.position, Quaternion.identity);

                var initialDirection = nodeMarkerToSpawn.AvailableDirections[UnityEngine.Random.Range(0, nodeMarkerToSpawn.AvailableDirections.Count)];

                var randomInput = enemy.gameObject.AddComponent<EnemyRandomInput>();
                randomInput.Configure(initialDirection);
            
                enemy.Configure(randomInput, initialDirection);
                _enemies.Add(enemy);
            }
        }
        private NodeMarker GetRandomNodeMarker() => _nodeMarkers[UnityEngine.Random.Range(0, _nodeMarkers.Count)];
        public void Process(LocalEventData eventData)
        {
            if(eventData.EventId != EventIds.OnEndGame)
                return;

            foreach (var enemy in _enemies)
            {
                enemy.StopActions();
            }
        }
    }
}