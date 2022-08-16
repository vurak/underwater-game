using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingDetector : MonoBehaviour
{
  public bool dockingRange = false;
  [SerializeField]
  GameObject targetPort;
  void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.gameObject.name);
    if (other.gameObject.name == targetPort.name)
    {
      dockingRange = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.name == targetPort.name)
    {
      dockingRange = false;
    }
  }
}
