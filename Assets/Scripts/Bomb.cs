using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody), typeof(BoxCollider))]    
public class Bomb : MonoBehaviour
{
    [SerializeField] private int _explosionDelay = 1;
    [SerializeField] private int _maxTargetCount = 10;
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 100; 

    private Coroutine _countdownCoroutine;

    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    public void Initialize(Vector3 position, float explosionRadius, float explosionForce)
    {
        transform.position = position;
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
        _countdownCoroutine = StartCoroutine(CountdownCoroutine(_explosionDelay));
    }

    private IEnumerator CountdownCoroutine(float explosionDelay)
    {
        yield return new WaitForSeconds(explosionDelay);
        Explose();
    }

    private void Explose()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, _explosionRadius);
        Vector3 explosionPosition = transform.position;

        foreach (Collider target in targets)
        {
            if(target.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
                Debug.Log($"boom {rigidbody.gameObject} {_explosionForce} {_explosionRadius}");
            }
        }

        Destroy(gameObject);
    }
}