using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using System;

public class DialogWithAction : MonoBehaviour
{
    public string[] dialogSentence;
    public string[] nextDialogSentences;
    public int index;
    public float typingSpeed = 0.015f;
    private IEnumerator type;
    public int endedDialog;

    void OnEnable()
    {
        DialogsController.instance.textBackGround.SetActive(true);
        DialogsController.instance.textDisplay.gameObject.SetActive(true);
        type = Type();
        StartCoroutine(type);
    }


    private void Update()
    {
        if (DialogsController.instance.textDisplay.text == dialogSentence[index])
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))//Input.anyKeyDown
            {
                NextSentence();
            }
        }
    }

    public IEnumerator Type()
    {
        foreach (char letter in dialogSentence[index].ToCharArray())
        {
            DialogsController.instance.textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        DialogsController.instance.textDisplayAnim.SetTrigger("Change");
        if (index < dialogSentence.Length - 1)
        {
            index++;
            DialogsController.instance.textDisplay.text = "";
            type = Type();
            StartCoroutine(type);
        }
        else
        {
            NextDialogSentences();
            endedDialog += 1;
            if (endedDialog >= 2)
            {
                GameController.instance.DoSpecialAction();
                Destroy(gameObject);
            }

        }
    }

    public void NextDialogSentences()
    {
        if (nextDialogSentences.Length > 0)
        {
            Array.Resize(ref dialogSentence, nextDialogSentences.Length);
            nextDialogSentences.CopyTo(dialogSentence, 0);
        }

        EndDialog();
    }

    public void EndDialog()
    {
        index = 0;
        StopCoroutine(type);
        DialogsController.instance.textDisplay.text = "";
        DialogsController.instance.textDisplay.gameObject.SetActive(false);
        DialogsController.instance.textBackGround.SetActive(false);
        enabled = false;

    }
}