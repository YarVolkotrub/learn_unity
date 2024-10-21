using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool _isColorChange = false;
    private int _maxLifetime = 5;
    private int _minLifetime = 2;
    private int _lifetime;
    private Material _material;
    private Color _defaultColor;
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<MeshRenderer>();
        //MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        _material = GetComponent<Renderer>().material;
        _defaultColor = _material.color;
    }

    public bool IsColorChange()
    {
        return _isColorChange;
    }

    public void ChangeColor()
    {
        _material.color = UnityEngine.Random.ColorHSV();
        _isColorChange = true;
    }

    public void SetDefaultColor()
    {
        _material.color = _defaultColor;
        _isColorChange = false;
    }

    public int GetLifetime()
    {
        return Random.Range(_minLifetime, _maxLifetime);
    }

    public void EnableTrigger()
    {
        _collider.isTrigger = true;
    }

    public void DisableTrigger()
    {
        _collider.isTrigger = false;
    }
}