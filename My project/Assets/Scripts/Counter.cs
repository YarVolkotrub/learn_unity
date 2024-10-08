using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private int _step = 1;
    private int _displayedNumber = 0;
    private bool _isRunning = true;
    private IEnumerator _coroutine;

    void Start()
    {
        _text.text = string.Empty;
        _coroutine = Count(_step, _delay);
    }

    private void Update()
    {
        StartStopCoroutune();
    }

    private void StartStopCoroutune()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
        while (true)
        {
            Debug.Log($"{_displayedNumber} --- {Time.deltaTime}");
            DisplayCount(_displayedNumber += step);

            yield return new WaitForSeconds(delay);
        }
    }

    private void DisplayCount(float count)
    {
        _text.text = count.ToString();
    }
}