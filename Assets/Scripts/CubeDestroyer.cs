using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube, bool> CubeDestroyed;

    private void OnEnable()
    {
        _inputReader.ObjectSelected += DestroyCube;
    }

    private void OnDisable()
    {
        _inputReader.ObjectSelected -= DestroyCube;
    }

    private void DestroyCube(Cube cube)
    {
        bool shooldSpawn = UnityEngine.Random.value <= cube.SplitChance;

        CubeDestroyed?.Invoke(cube, shooldSpawn);
        Destroy(cube.gameObject);
    }
}
