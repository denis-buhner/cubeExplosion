using System;
using UnityEngine;

[RequireComponent(typeof(CubeLifecycle))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private CubeLifecycle _lifecycle;
    [SerializeField] private int _maxChildCount = 6;
    [SerializeField] private int _minChildCount = 2;

    private float _splitChanceScale = 2f;
    private float _sizeScale = 2f;

    public event Action<Cube> CubeSpawned;

    private void OnEnable()
    {
        _lifecycle.Spawning += Spawn;
    }

    private void OnDisable()
    {
        _lifecycle.Spawning -= Spawn;
    }

    private void Spawn(Cube previousCube)
    {
        for (int i = 0; i < UnityEngine.Random.Range(_minChildCount, _maxChildCount); i++)
        {
            Cube newCube = Instantiate(_cubePrefab);
            Vector3 newSize = previousCube.Scale / _sizeScale;
            float newSplitChance = previousCube.SplitChance / _splitChanceScale;
            newCube.Initialize(previousCube.Position, newSize, newSplitChance);
            CubeSpawned?.Invoke(newCube);
        }
    }
}
