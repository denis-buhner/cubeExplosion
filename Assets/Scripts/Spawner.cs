using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Bomb _bombPrefab;

    private float _splitChanceDivider = 2f;
    private float _sizeDivider = 2f;

    public Cube SpawnCube(Cube previousCube)
    {
        Cube newCube = Instantiate(_cubePrefab);
        Vector3 newSize = previousCube.Scale / _sizeDivider;
        float newSplitChance = previousCube.SplitChance / _splitChanceDivider;
        newCube.Initialize(previousCube.Position, newSize, newSplitChance, previousCube.ReductionMultiplier * _sizeDivider);

        return newCube;
    }

    public Bomb SpawnBomb(Cube previousCube)
    {
        Bomb bomb = Instantiate(_bombPrefab);
        float newExplosionRadius = _bombPrefab.ExplosionRadius * previousCube.ReductionMultiplier;
        float newExplosionForce = _bombPrefab.ExplosionForce * previousCube.ReductionMultiplier;
        bomb.Initialize(previousCube.Position, newExplosionRadius, newExplosionForce);

        return bomb;
    }
}
