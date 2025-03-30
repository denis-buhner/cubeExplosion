using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

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
}
