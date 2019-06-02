using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using System;

public class Dialog : MonoBehaviour
{
    public string[] dialogSentence;
    public string[] moreDialogSentences;
    public int index;
    public float typingSpeed = 0.015f;
    private IEnumerator type;
    public bool destroyDialog;
    private bool moreDialog;

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
        if (index < dialogSentence.Length - 1)
        {
            index++;
            DialogsController.instance.textDisplay.text = "";
            type = Type();
            StartCoroutine(type);
        }
        else
        {
            MoreDialogSentences();
            moreDialog = true;
        }
    }

    public void MoreDialogSentences()
    {
        if (moreDialogSentences.Length > 0)
        {
            Array.Resize(ref dialogSentence, moreDialogSentences.Length);
            moreDialogSentences.CopyTo(dialogSentence, 0);
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
        if (moreDialog && destroyDialog)
        {
            Destroy(gameObject);
        }
        GetComponent<Dialog>().enabled = false;
    }

    public void CheckDialogStatus()
    {
        if (destroyDialog)
        {
            StopCoroutine(type);
            DialogsController.instance.textDisplay.text = "";
            DialogsController.instance.textDisplay.gameObject.SetActive(false);
            DialogsController.instance.textBackGround.SetActive(false);
            Destroy(gameObject);
        }
    }
}