using System.Collections.Generic;
using System.Linq;
using Code.Installers;
using Code.Maze;
using UnityEngine;

namespace Code
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private MapCreator _mapCreator;
        [SerializeField] private PlayerInstaller _playerInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;


        private List<NodeMarker> _nodeMarkers;
        
        private void Start()
        {
            _mapCreator.Create();
            FindNodeMarkers();

            _playerInstaller.SpawnPlayer(_nodeMarkers[Random.Range(0, _nodeMarkers.Count)].transform.position);
            _enemySpawner.StartSpawning(_nodeMarkers);
        }

        private void FindNodeMarkers()
        {
            _nodeMarkers = FindObjectsOfType<NodeMarker>().ToList();
        }
    }
}
