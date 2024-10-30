using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;

    public void SpawnCubesFrom(Cube cube)
    {
        List<Cube> cubeList = new List<Cube>();

        int creatingCubeCount = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < creatingCubeCount; i++)
        {
            Cube createdCube = CreateCube(cube);
            cubeList.Add(createdCube);
        }

        _exploder.ExplodeCubes(cubeList);
    }
    
    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(_cubePrefab, cube.transform.position, Quaternion.identity);
        newCube.Init(this, cube.transform.localScale, cube.DivisionChance);
        return newCube;
    }
}
