using System;
using System.Collections;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    //dialog sentences
    public string[] dialogSentence;

    //second dialog sentences
    public string[] moreDialogSentences;

    //current index
    public int index;

    //typing speedd
    public float typingSpeed = 0.015f;

    // coroutine for typing
    private IEnumerator type;

    //dialog status
    public bool destroyDialog;

    //second dialog status
    private bool moreDialog;

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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))//Input.anyKeyDown
            {
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
            MoreDialogSentences();
        }
    }

    /// <summary>
    /// Handle the second dialog typing
    /// </summary>
    public void MoreDialogSentences()
    {
        if (moreDialogSentences.Length > 0)
        {
            Array.Resize(ref dialogSentence, moreDialogSentences.Length);
            moreDialogSentences.CopyTo(dialogSentence, 0);
        }
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
        if (destroyDialog)
        {
            Destroy(gameObject);
        }
        GetComponent<Dialog>().enabled = false;
    }

    /// <summary>
    /// Check dialog status
    /// </summary>
    public void CheckDialogStatus()
    {
        EndDialog();
    }
}