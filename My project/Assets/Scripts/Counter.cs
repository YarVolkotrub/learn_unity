using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _step = 1;
    private bool _isRunning = true;
    private IEnumerator _coroutine;
    private KeyCode _isClickMouse = KeyCode.Mouse0;

    public event Action NumberChanged;
    public int DisplayedNumber { get; private set; }

    private void Start()
    {
        _coroutine = Count(_step, _delay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_isClickMouse))
        {
            if (_isRunning)
            {
                _isRunning = false;
                StartCoroutine(_coroutine);
            }
            else
            {
                _isRunning = true;
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator Count(int step, float delay)
    {
        WaitForSeconds coroutuneDelay = new WaitForSeconds(delay);

        while (_isRunning == false)
        {
            DisplayedNumber += step;
            NumberChanged?.Invoke();

            yield return coroutuneDelay;
        }
    }
}