using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _divisionChance = 100;
    [SerializeField] private Spawner _spawner;

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
            _spawner.SpawnCubesFrom(this);
        }

        Destroy(gameObject);
    }

    public void Init(Spawner spawner, Vector3 previousScale, int previousDivisionChance)
    {
        _spawner = spawner;
        transform.localScale = new Vector3(
            previousScale.x / _factor,
            previousScale.y / _factor,
            previousScale.z / _factor
        );
        _divisionChance = previousDivisionChance / _factor;
    }
}