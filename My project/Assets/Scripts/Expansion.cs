using UnityEngine;

public class Expansion : MonoBehaviour
{
    [SerializeField] private float _growthRate;

    private void Update()
    {
        Run(_growthRate);
    }

    private void Run(float rate)
    {
        Vector3 maxSize = new Vector3(3, 3, 3);
        transform.localScale = Vector3.Lerp(transform.localScale, maxSize, rate * Time.deltaTime);
    }
}
