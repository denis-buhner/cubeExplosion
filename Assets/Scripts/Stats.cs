using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public float SplitChance => _splitChance;
    public Vector3 Position => transform.position;
    public Vector3 Scale => transform.localScale;

    public void Initialize(Vector3 position, Vector3 size, Material material, float splitChance)
    {
        GetComponent<MeshRenderer>().material = material;

        transform.localScale = size;
        transform.position = position;
        transform.rotation = Quaternion.Euler(Random.value, Random.value, Random.value);
        _splitChance = splitChance;

        SetRandomColor();
    }

    private void SetRandomColor()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
    }
}
