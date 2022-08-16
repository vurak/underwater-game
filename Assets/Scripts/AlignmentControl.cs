using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentControl : MonoBehaviour
{
    public Camera camera;
    public Transform vessel;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Move(Vector3 direction) {
        vessel.position += direction * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Debug.DrawRay(ray.origin, ray.direction *  50, Color.yellow);
        if (Physics.Raycast(ray, out hit)) {
            if (!Input.GetMouseButton(0)) return;
            if (hit.transform == up) {
                Move(Vector3.forward);
            } else if (hit.transform == down) {
                Move(Vector3.back);
            } else if (hit.transform == left) {
                Move(Vector3.left);
            } else if (hit.transform == right) {
                Move(Vector3.right);
            }
        }
    }
}
