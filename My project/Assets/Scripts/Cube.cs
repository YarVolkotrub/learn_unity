using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private float _dividerChanceSeparation = 2;
    public event Action ClickMouse;

    public bool IsSeparation { get; private set; }

    private bool CalculateChanceSeparation()
    {
        float chance = UnityEngine.Random.value;

        if (chance <= _chanceSeparation)
        {
            _chanceSeparation /= _dividerChanceSeparation;

            return true;
        }

        return false;
    }

    private void Awake()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent(typeof(Rigidbody));
        }

        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _rigidbody.useGravity = true;
        _renderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        IsSeparation = CalculateChanceSeparation();
        ClickMouse?.Invoke();
    }
}
