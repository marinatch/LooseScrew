using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconControl : MonoBehaviour
{
    public Transform target;
    public float offsetZ = -196.3f, offsetY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, target.localPosition.y + offsetY, target.localPosition.z + offsetZ);
    }
}
