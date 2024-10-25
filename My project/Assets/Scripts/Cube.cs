using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private int _maxLifetime = 5;
    private int _minLifetime = 2;
    private Material _material;
    private Color _defaultColor;
    private Platform _collisionObject;
    private bool _isPlatformTouched;

    public event Action<Cube> CollisionEnter;

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _material = GetComponent<Renderer>().material;
        _defaultColor = _material.color;
    }

    public void Init(Vector3 startPosition)
    {
        ResetColor();
        _isPlatformTouched = false;
        transform.position = startPosition;
        gameObject.SetActive(true);
    }
    private void ResetColor()
    {
        _material.color = _defaultColor;
    }

    private int GetLifetime()
    {
        return UnityEngine.Random.Range(_minLifetime, _maxLifetime);
    }

    private Color GetNewColor()
    {
        return UnityEngine.Random.ColorHSV();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isPlatformTouched) return;

        if (collision.gameObject.TryGetComponent(out _collisionObject) == false) return;

        _isPlatformTouched = true;
        int lifetime = GetLifetime();
        _material.color = GetNewColor();

        StartCoroutine(CountdownLife(lifetime));
    }

    private IEnumerator CountdownLife(int lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        CollisionEnter?.Invoke(this);
    }
}