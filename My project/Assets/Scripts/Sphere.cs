using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.forward * Time.deltaTime);
    }
}
