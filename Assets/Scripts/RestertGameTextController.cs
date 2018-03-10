using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestertGameTextController : MonoBehaviour
{
    public GameController GController;
    public Text T;
    public int CurrentLetterPosition = 0;
    public string CurrentLetter
    {
        get
        {
            if (GController.RGameText.Length == CurrentLetterPosition)
            {
                GController.RestartGame();
                CurrentLetterPosition = 0;
            }
            if (GController.RGameText[CurrentLetterPosition] == ' ')
            {
                GController.RGameText = GController.RGameText.Substring(CurrentLetterPosition + 1);
                CurrentLetterPosition = 0;
            }
            return GController.RGameText[CurrentLetterPosition].ToString().ToLower();
        }

    }

    public string CorrectOpenTag;
    public string ColorCloseTag;

    public bool IsKeyDown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(CurrentLetter))
        {
            IsKeyDown = false;
            CurrentLetterPosition++;
        }
        if (Input.anyKey && Input.GetKey(CurrentLetter)) SetNextLetterCorrect();
    }

    private void SetNextLetterCorrect()
    {
        if (IsKeyDown) return;
        if (CurrentLetterPosition >= GController.RGameText.Length - 1) return;
        var firstHalf = GController.RGameText.Substring(0, CurrentLetterPosition + 1);
        var secondHalf = GController.RGameText.Substring(CurrentLetterPosition + 1);
        IsKeyDown = true;
        var result = CorrectOpenTag + firstHalf + ColorCloseTag + secondHalf;
        T.text = result;
        
    }
}   
