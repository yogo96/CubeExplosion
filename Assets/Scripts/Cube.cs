using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _divisionChance = 100;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private int _maxPercent = 100;
    private int _factor = 2;

    public Rigidbody Rigidbody { get; private set; }
    public int DivisionChance => _divisionChance;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public void Divide()
    {
        bool isDivisionSuccess = Random.Range(0, _maxPercent + 1) <= _divisionChance;

        if (isDivisionSuccess == true)
        {
            List<Cube> cubeList = _spawner.CreateCubesFrom(this);
            _exploder.ExplodeCubes(cubeList);
        }
        else
        {
            _exploder.ExplodeAround(transform.position, transform.localScale);
        }

        Destroy(gameObject);
    }

    public void Init(Spawner spawner, Exploder exploder, Vector3 previousScale, int previousDivisionChance)
    {
        _spawner = spawner;
        _exploder = exploder;
        transform.localScale = new Vector3(
            previousScale.x / _factor,
            previousScale.y / _factor,
            previousScale.z / _factor
        );
        _divisionChance = previousDivisionChance / _factor;
    }
}