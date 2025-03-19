using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explose(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_explosionForce, cube.Position, _explosionRadius);
    }
}