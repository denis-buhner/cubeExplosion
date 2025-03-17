using System;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Stats, bool> CubeDestroyed;

    private void OnEnable()
    {
        _inputReader.ObjectSelected += DestroyCube;
    }

    private void OnDisable()
    {
        _inputReader.ObjectSelected -= DestroyCube;
    }

    private void DestroyCube(GameObject objectToDestroy)
    {
        if (objectToDestroy == null)
            return;

        Stats stats = objectToDestroy.GetComponent<Stats>();

        if (stats == null)
            return;

        bool shooldSpawn = UnityEngine.Random.value <= stats.SplitChance;

        CubeDestroyed?.Invoke(stats, shooldSpawn);
        Destroy(objectToDestroy);
    }
}
