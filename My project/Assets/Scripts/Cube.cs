using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material _material;
    private Color _defaultColor;
    private bool _isColorChange = false;
    private int _maxLifetime = 5;
    private int _minLifetime = 2;
    private int _lifetime;


    private void Awake()
    {
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<MeshRenderer>();
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

    public void DisableTrigger()
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
}
