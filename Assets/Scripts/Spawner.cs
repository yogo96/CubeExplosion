using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;

    public List<Cube> CreateCubesFrom(Cube cube)
    {
        List<Cube> cubeList = new List<Cube>();

        int creatingCubeCount = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < creatingCubeCount; i++)
        {
            Cube createdCube = CreateCube(cube);
            cubeList.Add(createdCube);
        }

        return cubeList;
    }
    
    private Cube CreateCube(Cube cube)
    {
        Cube newCube = Instantiate(_cubePrefab, cube.transform.position, Quaternion.identity);
        newCube.Init(this,_exploder, cube.transform.localScale, cube.DivisionChance);
        return newCube;
    }
}
