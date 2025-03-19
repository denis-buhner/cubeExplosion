using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode InputKey = KeyCode.Mouse0;

    public event Action<Cube> CubeSelected;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(InputKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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