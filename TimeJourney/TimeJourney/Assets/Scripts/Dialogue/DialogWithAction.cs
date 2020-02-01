using System;
using System.Collections;
using UnityEngine;

public class DialogWithAction : MonoBehaviour
{
    //dialog sentences
    public string[] dialogSentence;

    //next dialog sentences
    public string[] nextDialogSentences;

    //current index
    public int index;

    //typing speedd
    public float typingSpeed = 0.015f;

    // coroutine for typing
    private IEnumerator type;

    // dialog count 
    public int endedDialogCount;

    // nextLine status
    private bool nextLine;

    // dialog status
    public bool dialogEnded;

    /// <summary>
    /// MonoBehaviour OnEnable function for when the gameobject is activated.
    /// </summary>
    void OnEnable()
    {
        DialogsController.instance.textBackGround.SetActive(true);
        DialogsController.instance.textDisplay.gameObject.SetActive(true);
        type = Type();
        StartCoroutine(type);
    }

    /// <summary>
    /// MonoBehaviour Updated function called every frame
    /// </summary>
    private void Update()
    {
        if (DialogsController.instance.textDisplay.text == dialogSentence[index])
        {
            if ((Input.GetKeyDown(KeyCode.Space) && nextLine) || (Input.GetKeyDown(KeyCode.E) && nextLine))//Input.anyKeyDown
            {
                nextLine = false;
                NextSentence();
            }
        }
    }

    /// <summary>
    /// Coroutine for typing
    /// </summary>
    /// <returns></returns>
    public IEnumerator Type()
    {
        foreach (char letter in dialogSentence[index].ToCharArray())
        {
            DialogsController.instance.textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        nextLine = true;
    }

    /// <summary>
    /// type next sentence
    /// </summary>
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
            NextDialogSentences();
        }
    }

    /// <summary>
    /// Handle the next dialog typing
    /// </summary>
    public void NextDialogSentences()
    {
        if (nextDialogSentences.Length > 0)
        {
            Array.Resize(ref dialogSentence, nextDialogSentences.Length);
            nextDialogSentences.CopyTo(dialogSentence, 0);
        }
        dialogEnded = true;
        EndDialog();
    }

    /// <summary>
    /// Handle the end of dialogs
    /// </summary>
    public void EndDialog()
    {
        index = 0;
        StopCoroutine(type);
        DialogsController.instance.textDisplay.text = "";
        DialogsController.instance.textDisplay.gameObject.SetActive(false);
        DialogsController.instance.textBackGround.SetActive(false);
        endedDialogCount += 1;
        if (endedDialogCount >= 2)
        {
            GameController.instance.DoSpecialAction();
            Destroy(gameObject);
            return;
        }
        enabled = false;
    }

    /// <summary>
    /// Check dialog status
    /// </summary>
    public void CheckDialogStatus()
    {
        if (!dialogEnded)
        {
            NextDialogSentences();
        }
    }
}