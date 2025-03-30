using UnityEngine;

[RequireComponent(typeof(CubeSelector), typeof(Spawner), typeof(Exploser))]
public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private CubeSelector _inputReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploser _exploser;
    [SerializeField][Min(1)] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;

    private void OnValidate()
    {
        if (_minSplitCount > _maxSplitCount)
        {
            _maxSplitCount = _minSplitCount;
        }
    }

    private void OnEnable()
    {
        _inputReader.CubeSelected += SplitCube;
    }

    private void OnDisable()
    {
        _inputReader.CubeSelected -= SplitCube;
    }

    private void SplitCube(Cube cube)
    {
        bool canSplit = Random.value <= cube.SplitChance;

        if(canSplit )
        {
            int splitCount = Random.Range(_minSplitCount, _maxSplitCount);

            for (int i = 0; i < splitCount; i++)
            {
                _exploser.Explose(_spawner.SpawnCube(cube));
            }
        }
        else
        {
            float newExplosionRadius = _exploser.StartExplosionRadius * cube.ReductionMultiplier;
            float newExplosionForce = _exploser.StartExplosionForce * cube.ReductionMultiplier;
            _exploser.Explose(cube.Position, newExplosionRadius, newExplosionForce);
        }

        cube.Destroy();
    }
}
