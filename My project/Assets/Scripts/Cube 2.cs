using UnityEngine;

public class Cube2 : MonoBehaviour
{
    private float _growthRate;
    private float _rotateSpeed;

    private void Start()
    {
        _growthRate = 0.0001f;
        _rotateSpeed = 1f;
    }

    private void Update()
    {
        Expansion(_growthRate);
        Rotate(_rotateSpeed);
        Move();
    }

    private void Rotate(float speed)
    {
        transform.RotateAround(transform.position, Vector3.up, speed);
    }

    private void Expansion(float rate)
    {
        Vector3 maxSize = new Vector3(3, 3, 3);
        transform.localScale = Vector3.Lerp(transform.localScale, maxSize, rate * Time.deltaTime);
    }
    private void Move()
    {
        transform.Translate(transform.forward * Time.deltaTime);
    }
}
