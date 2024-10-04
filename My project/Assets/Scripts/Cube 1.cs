using UnityEngine;

public class Cube1 : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        Rotate(_rotateSpeed);
    }

    private void Rotate(float speed)
    {
        transform.RotateAround(transform.position, Vector3.up, speed);
    }
}
