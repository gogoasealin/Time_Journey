using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Dialog : MonoBehaviour
{
    public string[] sentencces;
    public int index;
    public float typingSpeed = 0.02f;
    private IEnumerator type;


    void OnEnable()
    {
        DialogsController.instance.textBackGround.SetActive(true);
        type = Type();
        StartCoroutine(type);
    }


    private void Update()
    {
        if(DialogsController.instance.textDisplay.text == sentencces[index])
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
            DialogsController.instance.textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        DialogsController.instance.textDisplayAnim.SetTrigger("Change");
        if (index < sentencces.Length - 1)
        {
            index++;
            DialogsController.instance.textDisplay.text = "";
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
        DialogsController.instance.textDisplay.text = "";
        DialogsController.instance.textBackGround.SetActive(false);
        GetComponent<Dialog>().enabled = false;
    }
}
