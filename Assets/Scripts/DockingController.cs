using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DockingController : MonoBehaviour
{
  [Header("Info")]
  public bool docked = false;

  [Header("Docking")]
  public DockingDetector dockingDetector;
  [SerializeField]
  GameObject dockingButton;
  PlayerInteractionHandler dockingButtonHandler;
  Renderer dockingButtonRenderer;
  public Transform dockTargetTransform;
  public float dockingTime;
  
  [Header("Hatch")]
  [SerializeField]
  GameObject hatchButton;
  PlayerInteractionHandler hatchButtonHandler;
  Renderer hatchButtonRenderer;
  [SerializeField]
  GameObject[] hatches;

  bool docking;
  float dockingTimer;
  Vector3 initialPosition;

  private void Start() {
    dockingButtonRenderer = dockingButton.GetComponent<Renderer>();
    dockingButtonHandler = dockingButton.GetComponent<PlayerInteractionHandler>();
    hatchButtonRenderer = hatchButton.GetComponent<Renderer>();
    hatchButtonHandler = hatchButton.GetComponent<PlayerInteractionHandler>();
  }

  private void Update() {
    if (dockingDetector.dockingRange && !docking) {
      // Activate Docking Button
      dockingButtonRenderer.material.color = Color.green;
      if (dockingButtonHandler.active) {
        docking = true;
        dockingTimer = 0f;
        initialPosition = transform.position;
      }
    }

    if (docking) {
      dockingTimer += Time.deltaTime;
      transform.position = Vector3.Lerp(initialPosition, dockTargetTransform.position, Mathf.Clamp01(dockingTimer / dockingTime));
      if (dockingTimer >= dockingTime) {
        docking = false;
        docked = true;
        hatchButtonRenderer.material.color = Color.green;
      }
    }

    if (docked && hatchButtonHandler.active) {
      for (int i = 0; i < hatches.Length; i++) {
        hatches[i].SetActive(false);
      }
    }
  }
  
}
