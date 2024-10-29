using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _divisionChance = 100;

    private Spawner _spawner;
    private Exploder _exploder;
    private Rigidbody _rb;
    private int _maxPercent = 100;

    public int DivisionChance
    {
        get { return _divisionChance; }
        set { _divisionChance = value; }
    }
    
    public Rigidbody Rigidbody => _rb;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _exploder = FindObjectOfType<Exploder>();
        _rb = gameObject.GetComponent<Rigidbody>();
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public void Divide()
    {
        bool isDivisionSuccess = Random.Range(0, _maxPercent + 1) <= _divisionChance;

        if (isDivisionSuccess == true)
        {
            List<Cube> cubeToExplosion = _spawner.CreateCubesFrom(transform.position, transform.localScale, _divisionChance);

            _exploder.ExplodeCubes(cubeToExplosion);
        }

        Destroy(gameObject);
    }

}