using System;
using UnityEngine;

[RequireComponent(typeof(CubeDestroyer), typeof(CubeSpawner), typeof(Exploser))]
public class CubeLifecycle : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeDestroyer _destroyer;
    [SerializeField] private Exploser _exploser;

    public event Action<Cube> Spawning;
    public event Action<Cube> Explosing;

    private void OnEnable()
    {
        _destroyer.CubeDestroyed += SpawnCube;
        _spawner.CubeSpawned += ExploseCube;
    }

    private void OnDisable()
    {
        _destroyer.CubeDestroyed -= SpawnCube;
        _spawner.CubeSpawned -= ExploseCube;
    }

    private void SpawnCube(Cube cube, bool shooldSpawn)
    {
        if(shooldSpawn)
        {
            Spawning?.Invoke(cube);
        }
    }

    private void ExploseCube(Cube cube)
    {
        Explosing?.Invoke(cube);
    }
}
