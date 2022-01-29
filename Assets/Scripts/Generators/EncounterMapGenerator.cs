using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators
{
    public class EncounterMapGenerator : MonoBehaviour
    {
        [SerializeField] int dimension;
        [SerializeField] float size;
        [SerializeField] float maxWallHeight;
        [SerializeField] GameObject floorTilePrefab;
        [SerializeField] GameObject wallTilePrefab;
        [SerializeField] Transform tileContainer;

        void Start()
        {
            var map = new bool[dimension, dimension];

            var initialX = dimension / 2;
            var initialY = dimension / 2;

            map[initialX, initialY] = true;
            CheckNeighbours(map, initialX, initialY);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (map[i, j])
                    {
                        var tile = Instantiate(floorTilePrefab, tileContainer);
                        tile.transform.localPosition = new Vector3(i, 0, j);
                    }
                    else
                    {
                        var wall = Instantiate(wallTilePrefab, tileContainer);
                        wall.transform.localPosition = new Vector3(i, 0, j);

                        var scale = Vector3.one;
                        scale.y += Random.Range(0f, maxWallHeight);
                        wall.transform.localScale = scale;
                    }

                }
            }
            
        }

        void CheckNeighbours(bool[,] map, int x, int y)
        {
            OpenNeighbour(map, x - 1, y);
            OpenNeighbour(map, x + 1, y);
            OpenNeighbour(map, x, y - 1);
            OpenNeighbour(map, x, y + 1);
        }

        void OpenNeighbour(bool[,] map, int x, int y)
        {
            if (x > 0 && y > 0 && x < dimension-1 && y < dimension-1)
            {
                if (!map[x, y] && Random.value > Chance(x,y))
                {
                    map[x, y] = true;
                    CheckNeighbours(map, x, y);
                }
            }
        }

        float Chance(int x, int y)
        {
            var origin = new Vector2(dimension / 2, dimension / 2);
            var target = new Vector2(x,y);

            return Mathf.InverseLerp(0, dimension/2, Vector2.Distance(origin, target) / size);
        }
    }
}
