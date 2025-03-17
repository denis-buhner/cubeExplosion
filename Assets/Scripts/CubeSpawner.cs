using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeDestroyer _destroyer;
    [SerializeField] private Material _material;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _maxChildCount;
    [SerializeField] private float _minChildCount;

    private PrimitiveType _primitiveType = PrimitiveType.Cube;
    private float _splitChanceScale = 2f;
    private float _sizeScale = 2f;

    private void OnEnable()
    {
        _destroyer.CubeDestroyed += Spawn;
    }

    private void OnDisable()
    {
        _destroyer.CubeDestroyed -= Spawn;
    }

    private void Spawn(CubeStats previousCubeStats, bool shooldSpawn)
    {
        if(shooldSpawn)
        {
            for (int i = 0; i < Random.Range(_minChildCount, _maxChildCount); i++)
            {
                GameObject cube = GameObject.CreatePrimitive(_primitiveType);
                CubeStats stats = cube.AddComponent<CubeStats>();
                Rigidbody rb = cube.AddComponent<Rigidbody>();
                cube.AddComponent<BoxCollider>();

                Vector3 newSize = previousCubeStats.Scale / _sizeScale;

                stats.Initialize(previousCubeStats.Position, newSize, _material, previousCubeStats.SplitChance / _splitChanceScale);
                rb.AddExplosionForce(_explosionForce, previousCubeStats.Position, _explosionRadius);
            }
        }
    }
}
