using UnityEngine;

public class Expansion : MonoBehaviour
{
    [SerializeField] private float _growthRate;
    private Vector3 _maxSize;

    private Expansion()
    {
        _maxSize = new Vector3(3, 3, 3);
    }

    private void Update()
    {
        Run(_growthRate);
    }

    private void Run(float rate)
    {
        
        transform.localScale = Vector3.Lerp(transform.localScale, _maxSize, rate * Time.deltaTime);
    }
}
