using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  public bool broken = false;
  [SerializeField]
  PlayerInteractionHandler buttonHandler1;
  [SerializeField]
  PlayerInteractionHandler buttonHandler2;
  [SerializeField]
  Transform door;
  [SerializeField]
  bool open = false;

  [Header("Door Rotation")]
  [SerializeField]
  float rotationSpeed = 5f;
  [SerializeField]
  Transform doorPivot;
  [SerializeField]
  Vector3 closedRotation;
  [SerializeField]
  Vector3 openRotation;

  [SerializeField]
  bool opening;
  [SerializeField]
  bool closing;


  // Update is called once per frame
  void Update()
  {
    if (buttonHandler1.active || buttonHandler2.active)
    {
      if (open && !closing)
      {
        StopAllCoroutines();
        StartCoroutine(CloseDoor());
        opening = false;
      }
      else if (!open && !opening)
      {
        StopAllCoroutines();
        StartCoroutine(OpenDoor());
        closing = false;
      }
    }
  }

  IEnumerator OpenDoor()
  {
    open = true;
    opening = true;
    float time = 0;
    float step = Mathf.Abs(openRotation.y - door.localEulerAngles.y) / rotationSpeed;
    while (time < step)
    {
      door.RotateAround(doorPivot.position, Vector3.up, rotationSpeed * Time.deltaTime);
      time += Time.deltaTime;
      yield return null;
    }
    door.rotation = Quaternion.Euler(openRotation);
    opening = false;
  }

  IEnumerator CloseDoor()
  {
    open = false;
    closing = true;
    float time = 0;
    float step = Mathf.Abs(closedRotation.y - door.localEulerAngles.y) / rotationSpeed;
    while (time < step)
    {
      door.RotateAround(doorPivot.position, Vector3.up, -rotationSpeed * Time.deltaTime);
      time += Time.deltaTime;
      yield return null;
    }
    door.rotation = Quaternion.Euler(closedRotation);
    closing = false;
  }
}
