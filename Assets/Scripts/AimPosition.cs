using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPosition : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHint))
        {
            transform.position = raycastHint.point;
        }
    }
}
