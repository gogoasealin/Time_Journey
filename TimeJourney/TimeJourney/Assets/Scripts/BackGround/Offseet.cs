using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offseet : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;
    public PlayerMovementWithSword pmws;


    // Update is called once per frame
    void FixedUpdate()
    {
        bgRend.material.mainTextureOffset += new Vector2(pmws.horizontalMove * Time.fixedDeltaTime * 0.001f, 0f);
    }
}
