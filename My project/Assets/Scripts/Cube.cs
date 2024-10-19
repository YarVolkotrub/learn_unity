using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Mesh _mesh;

    private GameObject _cube;
    private string _objectName = "Cube";

    private void Awake()
    {
        Create();
    }

    private void Create()
    {
        _cube = new GameObject(_objectName);
        Customization();
    }

    private void Customization()
    {
        _cube.AddComponent<MeshRenderer>();
        _cube.AddComponent<BoxCollider>();
        MeshFilter meshFilter = _cube.AddComponent<MeshFilter>();
        Rigidbody rigidbody = _cube.AddComponent<Rigidbody>();

        GetComponent<Renderer>().material = _material;
        rigidbody.useGravity = true;
        //renderer.material = _material;
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        meshFilter.mesh = _mesh;
    }
}
