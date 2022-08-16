using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescentVesselMovement : MonoBehaviour
{
    public float descentSpeed = 20f;
    public float maneuverSpeed = 5f;
    public bool manualControl = false;

    public DockingDetector dockingDetector;
    bool dockingReady = false;

    // Update is called once per frame
    void Update()
    {
        if (!dockingDetector.dockingRange && !dockingReady) {
            transform.position = transform.position - new Vector3(0, descentSpeed * Time.deltaTime, 0);
            if (dockingReady) dockingReady = false;
        } else {
            dockingReady = true;
        }
    }
}
