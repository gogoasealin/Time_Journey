using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBackGround : MonoBehaviour {

    public Animator anim;

    private void OnEnable()
    {
        anim.SetBool("IsOpen", true);
    }

}
