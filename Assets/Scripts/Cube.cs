using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody), typeof(BoxCollider))]
[RequireComponent(typeof(Material))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Material _material;

    public float SplitChance => _splitChance;
    public Vector3 Position => transform.position;
    public Vector3 Scale => transform.localScale;

    public void Initialize(Vector3 position, Vector3 size, float splitChance)
    {
        transform.position = position;
        transform.localScale = size;
        transform.rotation = Random.rotation;
        _splitChance = splitChance;
        _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
