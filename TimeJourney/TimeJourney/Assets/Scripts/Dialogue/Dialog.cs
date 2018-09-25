using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentencces;
    public int index;
    public float typingSpeed;
    public Animator textDisplayAnim;
    public GameObject textBackGround;
    private IEnumerator type;


    void OnEnable()
    {
        textBackGround.SetActive(true);
        type = Type();
        StartCoroutine(type);
    }


    private void Update()
    {
        if(textDisplay.text == sentencces[index])
        {
            if(Input.GetKeyDown(KeyCode.Space))//Input.anyKeyDown
            {
                NextSentence();
            }
        }
    }

    public IEnumerator Type()
    {
        //textDisplay.text = gameObject.name + " : ";
        foreach (char letter in sentencces[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        textDisplayAnim.SetTrigger("Change");
        if (index < sentencces.Length - 1)
        {
            index++;
            textDisplay.text = "";
            type = Type();
            StartCoroutine(type);
        }
        else
        {
            EndDialog();
        }
    }

    public void EndDialog()
    {
        index = 0;
        StopCoroutine(type);
        textDisplay.text = "";
        textBackGround.SetActive(false);
        GetComponent<Dialog>().enabled = false;
    }
}
