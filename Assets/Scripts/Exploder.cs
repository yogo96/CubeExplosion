using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void ExplodeCubes(List<Cube> cubeToExplosion)
    {
        foreach (Cube cube in cubeToExplosion)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
