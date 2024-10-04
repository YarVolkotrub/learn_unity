using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _growthRate;

    private void Update()
    {
        Expansion(_growthRate);
    }

    private void Expansion(float rate)
    {
        Vector3 maxSize = new Vector3(3, 3, 3);
        transform.localScale = Vector3.Lerp(transform.localScale, maxSize, rate * Time.deltaTime);
    }
}
