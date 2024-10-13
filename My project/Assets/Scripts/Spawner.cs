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
    private List<Cube> _cubes = new();
    public event Action NewCubes;

    public List<Cube> Cubes => _cubes.ToList();

    public void OnEnable()
    {
        _cube.ClickMouse += Run;
    }

    public void OnDisable()
    {
        _cube.ClickMouse -= Run;
    }
    private void Run()
    {
        if (_cube.IsSeparation)
        {
            CreateCubes();
            NewCubes?.Invoke();
        }

        Destroy(gameObject);
    }

    private void CreateCubes()
    {
        int countCube = UnityEngine.Random.Range(_minCountCubes, _maxCountCubes + 1);
        transform.localScale /= _dividerScale;

        for (int i = 0; i < countCube; i++)
        {
            _cubes.Add(Instantiate(_cube));
        }
    }
}
