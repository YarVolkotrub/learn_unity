using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _minCountCube = 2;
    private int _maxCountCube = 6;
    private float _chanceSeparation = 1;
    private float _dividerChanceSeparation = 2;
    private float _dividerScale = 2;
    private float _explosionForce = 500;
    private float _explosionRadius = 5;
    private List<Rigidbody> _colliders = new List<Rigidbody>();

    private void OnMouseUpAsButton()
    {
        if (CalculateChance())
        {
            CreateObjects();
            Explode();
        }
        
        Destroy(gameObject);
    }

    private bool CalculateChance()
    {
        float chance = UnityEngine.Random.value;
        float chanceSeparation = gameObject.GetComponent<Cube>().ChanceSeparation;

        if (chance <= chanceSeparation)
        {
            gameObject.GetComponent<Cube>().ChanceSeparation /= _dividerChanceSeparation;
            
            return true;
        }

        return false;
    }

    private void CreateObjects()
    {
        int countCube = UnityEngine.Random.Range(_minCountCube, _maxCountCube + 1);
        transform.localScale /= _dividerScale;

        for (int i = 0; i < countCube; i++)
        {
            GameObject a = Instantiate(gameObject);
            _colliders.Add(a.GetComponent<Collider>().attachedRigidbody);
        }
    }

    private void Explode()
    {
        foreach (Rigidbody collider in _colliders)
        {
            collider.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
