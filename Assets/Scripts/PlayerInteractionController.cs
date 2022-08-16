using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
  [SerializeField]
  Camera playerCamera;
  [SerializeField]
  LayerMask layerMask;

  PlayerInteractionHandler interactionHandler;
  PlayerInteractionHandler lastHandler;
  // Update is called once per frame
  void Update()
  {
    RaycastHit hit;
    Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
    Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
    if (Physics.Raycast(ray, out hit, 10f, layerMask))
    {
      try
      {
        interactionHandler = hit.transform.GetComponent<PlayerInteractionHandler>();
        lastHandler = interactionHandler;
        interactionHandler.lookedAt = true;
      }
      catch
      {
        Debug.Log("Target does not have PlayerInteractionHandler");
      }
    }
    else if (lastHandler)
    {
      lastHandler.lookedAt = false;
      lastHandler = null;
    }
  }
}
