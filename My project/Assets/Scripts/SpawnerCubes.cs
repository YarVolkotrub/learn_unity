using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;

    private ObjectPool<Cube> _pool;
    private int _poolCapacity = 8;
    private int _poolMaxSize = 5;
    private float _hightSpawn = 10f;
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
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = GetRandomStartPosition();
        cube.gameObject.SetActive(true);
    }

    private Vector3 GetRandomStartPosition()
    {
        return new Vector3(
            Random.Range(_minPositionX, _maxPositionX + 1),
            _hightSpawn,
            Random.Range(_minPositionZ, _maxPositionZ + 1)
            );
    }

    private void GetCube() => _pool.Get();

    private void OnTriggerEnter (Collider other)
    {
        _pool.Release(other.gameObject.GetComponent<Cube>());
    }
}
