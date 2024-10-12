using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    public float ChanceSeparation = 1;

    private void Awake()
    {
        gameObject.AddComponent(typeof(Rigidbody));
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _rigidbody.useGravity = true;
        _renderer.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
