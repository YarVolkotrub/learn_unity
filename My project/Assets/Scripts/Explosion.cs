using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private float _explosionForce = 500;
    private float _explosionRadius = 5;
    
    private void OnEnable()
    {
        _spawner.CubesSpawned += Explode;
    }

    private void OnDisable()
    {
        _spawner.CubesSpawned -= Explode;
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubs = new();

        foreach (Collider hit in hits)
        { 
            if (hit.attachedRigidbody != null)
            {
                cubs.Add(hit.attachedRigidbody);
            }
        }

        return cubs;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
