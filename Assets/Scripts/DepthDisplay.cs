using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthDisplay : MonoBehaviour
{
    public TMP_Text text;
    public float updateFrequency = 4f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1/updateFrequency) {
            text.SetText((Mathf.Abs(transform.position.y).ToString() + "00000").Substring(0, 4));
        }
    }
}
