using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _spawnCountMin = 2;
    [SerializeField] private int _spawnCountMax = 6;
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    
    public int DivisionChance = 100;

    private int _maxPercent = 100;

    public void Explode()
    {
        bool isDivisionSuccess = Random.Range(0, _maxPercent + 1) <= DivisionChance;

        if (isDivisionSuccess == true)
        {
            List<Cube> cubeToExplosion = new List<Cube>();
            int creatingCubeCount = Random.Range(_spawnCountMin, _spawnCountMax + 1);

            for (int i = 0; i < creatingCubeCount; i++)
            {
                Cube createdCube = CreateCube();
                cubeToExplosion.Add(createdCube);
            }

            ExplodeCubes(cubeToExplosion);
        }
        
        Destroy(gameObject);
    }

    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    private void ExplodeCubes(List<Cube> cubeToExplosion)
    {
        foreach (Cube cube in cubeToExplosion)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private Cube CreateCube()
    {
        Cube newCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
        var currentScale = transform.localScale;
        newCube.transform.localScale = new Vector3(
            currentScale.x / 2,
            currentScale.y / 2,
            currentScale.z / 2
        );
        newCube.DivisionChance = DivisionChance / 2;

        return newCube;
    }
}