using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation;
    private float _dividerChanceSeparation = 2;

    public event Action ClickMouse;

    public bool CanBeSeparated { get; private set; }
    public Collider Collider { get; }

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        CanBeSeparated = IsChanceSeparation();
        ClickMouse?.Invoke();
    }

    private bool IsChanceSeparation()
    {
        float chance = UnityEngine.Random.value;

        if (chance <= _chanceSeparation)
        {
            _chanceSeparation /= _dividerChanceSeparation;

            return true;
        }

        return false;
    }
}
