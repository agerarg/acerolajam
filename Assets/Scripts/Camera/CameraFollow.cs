using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targeT;

    private void LateUpdate()
    {
        transform.position = targeT.position;
    }
}
