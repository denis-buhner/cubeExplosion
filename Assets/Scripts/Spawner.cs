using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _splitChanceScale = 2f;
    private float _sizeScale = 2f;

    public Cube Spawn(Cube previousCube)
    {
        Cube newCube = Instantiate(_cubePrefab);
        Vector3 newSize = previousCube.Scale / _sizeScale;
        float newSplitChance = previousCube.SplitChance / _splitChanceScale;
        newCube.Initialize(previousCube.Position, newSize, newSplitChance);

        return newCube;
    }
}
