using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Rotates object to camera
 */
public class RotateToCameraManager : MonoBehaviour {

	void Start () {
        transform.LookAt(Camera.main.transform);
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
