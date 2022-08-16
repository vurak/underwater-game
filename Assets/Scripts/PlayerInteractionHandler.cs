using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
  public bool lookedAt = false;
  public bool active = false;
  public bool hold = false;
  public KeyCode interactionKey;

  // Update is called once per frame
  void Update()
  {
    if (lookedAt && (hold || (!hold && !active)))
    {
      if (hold && Input.GetButton("Fire1") && !active)
      {
        active = true;
        Debug.Log("Interacted: Hold");
      }
      else if (!hold && Input.GetButtonDown("Fire1"))
      {
        active = true;
        Debug.Log("Interacted: Down");
      }
    }
    else if (active)
    {
      active = false;
    }
  }
}
