using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    private int _minCountCubes = 2;
    private int _maxCountCubes = 6;
    private float _dividerScale = 2;

    public event Action CubesSpawned;

    private void OnEnable()
    {
        _cube.MouseClicked += Spawn;
    }

    private void OnDisable()
    {
        _cube.MouseClicked -= Spawn;
    }

    private void Spawn()
    {
        if (_cube.CanSeparated)
        {
            CreateCubes();
            CubesSpawned?.Invoke();
        }

        Destroy(gameObject);
    }

    private void CreateCubes()
    {
        int countCube = UnityEngine.Random.Range(_minCountCubes, _maxCountCubes + 1);
        transform.localScale /= _dividerScale;

        for (int i = 0; i < countCube; i++)
        {
            Instantiate(_cube);
        }
    }
}
