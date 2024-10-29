using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;

    private int _factor = 2;

    public List<Cube> CreateCubesFrom(Vector3 position, Vector3 scale, int divisionChance)
    {
        List<Cube> cubeList = new List<Cube>();

        int creatingCubeCount = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < creatingCubeCount; i++)
        {
            Cube createdCube = CreateCube(position, scale, divisionChance);
            cubeList.Add(createdCube);
        }

        return cubeList;
    }
    
    private Cube CreateCube(Vector3 position, Vector3 scale, int divisionChance)
    {
        Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity);
        newCube.transform.localScale = new Vector3(
            scale.x / _factor,
            scale.y / _factor,
            scale.z / _factor
        );
        newCube.DivisionChance = divisionChance / _factor;

        return newCube;
    }
}
