using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private float _startExplosionRadius = 10;
    [SerializeField] private float _startExplosionForce = 500;

    private Coroutine _countdownCoroutine;

    public float StartExplosionRadius => _startExplosionRadius;
    public float StartExplosionForce => _startExplosionForce;

    public void Explose(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_startExplosionForce, cube.Position, _startExplosionRadius);
    }

    public void Explose(Vector3 position, float explosionRadius, float explosionForce)
    {
        Collider[] targets = Physics.OverlapSphere(position, explosionRadius);

        foreach (Collider target in targets)
        {
            if (target.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explosionForce, position, explosionRadius);
            }
        }
    }
}