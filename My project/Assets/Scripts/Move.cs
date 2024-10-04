using UnityEngine;

public class Move : MonoBehaviour
{
    private void Update()
    {
        Run();
    }

    private void Run()
    {
        transform.Translate(transform.forward * Time.deltaTime);
    }
}
