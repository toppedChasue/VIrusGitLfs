using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.right * 16);

        while (transform.rotation.z >= 0)
            transform.rotation = Quaternion.Euler(0, 0, 1);

    }
}
