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
    
    public void ExplodeAround(Vector3 position, Vector3 scale)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Cube>(out Cube cube))
            {
                Vector3 direction = position - cube.transform.position;
                float distance = direction.magnitude;

                float explosionForce = _explosionForce / Mathf.Max(distance, 0.1f);
                float explosionRadius = _explosionRadius / Mathf.Max(scale.x, 0.1f);
                explosionForce = explosionForce / Mathf.Max(scale.x, 0.1f);

                cube.Rigidbody.AddExplosionForce(explosionForce, position, explosionRadius);
            }
        }
    }
}
