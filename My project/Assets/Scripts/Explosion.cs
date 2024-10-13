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

    private void Explode()
    {
        foreach (Cube obj in _spawner.Cubes)
        {
            obj.Collider.attachedRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
