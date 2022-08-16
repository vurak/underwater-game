using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentDisplay : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public float updateFrequency = 1f;

    [Header("Indicators")]
    public Renderer up;
    public Renderer down;
    public Renderer left;
    public Renderer right;

    float xOffset;
    float zOffset;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 1f/updateFrequency) {
            xOffset = origin.position.x - target.position.x;
            zOffset = origin.position.z - target.position.z;
            if (xOffset > 1) {
                left.enabled = true;
                right.enabled = false;
            } else if (xOffset < -1) {
                right.enabled = true;
                left.enabled = false;
            } else if (left.enabled || right.enabled) {
                right.enabled = false;
                left.enabled = false;
            }
            
            if (zOffset > 1) {
                down.enabled = true;
                up.enabled = false;
            } else if (zOffset < -1) {
                up.enabled = true;
                down.enabled = false;
            } else if (down.enabled || up.enabled) {
                down.enabled = false;
                up.enabled = false;
            }
                
            timer = 0;
        }
    }
}
