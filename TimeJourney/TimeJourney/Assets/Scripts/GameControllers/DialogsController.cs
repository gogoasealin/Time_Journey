using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogsController : MonoBehaviour
{
    [HideInInspector] public static DialogsController instance;
    public TextMeshProUGUI textDisplay;
    public Animator textDisplayAnim;
    public GameObject textBackGround;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

}
