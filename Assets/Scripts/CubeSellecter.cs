using System;
using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private KeyCode _inputKey = KeyCode.Mouse0;

    public event Action<Cube> CubeSelected;

    private void Update()
    {
        if (Input.GetKeyDown(_inputKey))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Cube cube))
                {
                    CubeSelected?.Invoke(cube);
                }
            }
        }
    }
}