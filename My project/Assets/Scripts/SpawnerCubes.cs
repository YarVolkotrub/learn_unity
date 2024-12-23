using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _maxPositionZ;

    private float _minPositionX = 0;
    private float _minPositionZ = 0;
    private ObjectPool<Cube> _pool;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 5;
    private float _hightSpawn = 9f;
    private float _repeatRate = 1f;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(_repeatRate);
        while (true)
        {
            _pool.Get();
            yield return wait;
        }
    }

    private void ActionOnGet(Cube cube)
    {
        cube.CollisionEnter += CubeRelease;
        cube.Init(GetRandomStartPosition());
        cube.gameObject.SetActive(true);
    }

    private Vector3 GetRandomStartPosition()
    {
        return new Vector3(
            Random.Range(_minPositionX, _maxPositionX),
            _hightSpawn,
            Random.Range(_minPositionZ, _maxPositionZ)
            );
    }

    private void CubeRelease(Cube cube)
    {
        cube.CollisionEnter -= CubeRelease;
        _pool.Release(cube);
    }
}