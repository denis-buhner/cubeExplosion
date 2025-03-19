using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Spawner), typeof(Exploser))]
public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploser _exploser;
    [SerializeField][Min(1)] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;

    private void OnEnable()
    {
        _inputReader.CubeSelected += SplitCube;
    }

    private void OnDisable()
    {
        _inputReader.CubeSelected -= SplitCube;
    }

    private void OnValidate()
    {
        if (_minSplitCount > _maxSplitCount)
        {
            _maxSplitCount = _minSplitCount;
        }
    }

    private void SplitCube(Cube cube)
    {
        bool canSplit = Random.value <= cube.SplitChance;

        if(canSplit )
        {
            for (int i = 0; i < Random.Range(_minSplitCount, _maxSplitCount); i++)
            {
                _exploser.Explose(_spawner.Spawn(cube));
            }
        }

        cube.Destroy();
    }
}
