using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    public float speed;
    public MeshRenderer rend;

    void Update()
    {
        float offset = speed * Time.time;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
