using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode InputKey = KeyCode.Mouse0;

    public event Action<GameObject> ObjectSelected;

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
                ObjectSelected?.Invoke(hit.collider.gameObject);
            }
        }
    }
}
