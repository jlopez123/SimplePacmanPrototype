using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Maze
{
    public class MapCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Transform _initialPosition;
        [SerializeField] private float _tileSize = 1f;
        [SerializeField] private NodeMarker _nodeMarker;
        [SerializeField] private Transform _nodesContainer;


        private Vector2[] _directions = new Vector2[4] {new Vector2(0, 1) ,
                                                        new Vector2(-1,0),
                                                        new Vector2(0,-1) , 
                                                        new Vector2(1,0)};

        private char[,] _maze;
        public void Create()
        {
            _maze = new PrefabMaze().GenerateMaze();
            
            CreateMap();
            CreateNodeMarkers();
        }
        private void CreateMap()
        {
            var initialPos = _initialPosition.position;

            for (var i = 0; i < _maze.GetLength(0); i++)
            {
                for (var j = 0; j < _maze.GetLength(1); j++)
                {
                    var current = _maze[i, j];

                    if (current == '*')
                        Instantiate(_wallPrefab, initialPos, Quaternion.identity, transform);

                    else if (current == '.')
                        Instantiate(_coinPrefab, initialPos, Quaternion.identity, transform);

                    initialPos.x += _tileSize;
                }

                initialPos.x = _initialPosition.position.x;
                initialPos.y -= _tileSize;
            }
        }
        private void CreateNodeMarkers()
        {
            for (var i = 0; i < _maze.GetLength(0); i++)
            {
                for (var j = 0; j < _maze.GetLength(1); j++)
                {
                    var current = _maze[i, j];
                    
                    if(current == '*' || current == ' ')
                        continue;

                    var currentPosition = new Vector2(i, j);
                    var dirIndexList = new List<int>();
                    for (var index = 0; index < _directions.Length; index++)
                    {
                        var direction = _directions[index];
                        
                        if (!IsValidPosition(currentPosition + direction))
                            continue;
                        
                        dirIndexList.Add(index);
                    }

                    if (!ShouldInstantiateNodeMarker(dirIndexList))
                        continue;
                    
                    var nodeMarker = Instantiate(_nodeMarker,new Vector3(_initialPosition.position.x + _tileSize*j, 
                            _initialPosition.position.y - i*_tileSize), Quaternion.identity, _nodesContainer);
                        
                    var directionList = dirIndexList.Select(t => _directions[t]).ToList();

                    nodeMarker.Configure(directionList);
                }
            }
        }

        private bool ShouldInstantiateNodeMarker(IReadOnlyList<int> directionIndexList)
        {
            return directionIndexList.Count > 0 && directionIndexList.Count != 2 || 
                   directionIndexList.Count == 2 && (directionIndexList[0] % 2 != directionIndexList[1] % 2);
        }

        private bool IsValidPosition(Vector2 position)
        {
            if (position.x < 0 || position.x >= _maze.GetLength(0) 
                               || position.y < 0 || position.y >= _maze.GetLength(1))
                return false;

            return _maze[(int) position.x, (int) position.y] != '*';
        }

    }
}
