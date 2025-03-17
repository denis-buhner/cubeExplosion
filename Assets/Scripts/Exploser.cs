using UnityEngine;

[RequireComponent(typeof(CubeLifecycle))]
public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private CubeLifecycle _lifecycle;

    private void OnEnable()
    {
        _lifecycle.Explosing += Explose;
    }

    private void OnDisable()
    {
        _lifecycle.Explosing -= Explose;
    }

    private void Explose(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_explosionForce, cube.Position, _explosionRadius);
    }
}
