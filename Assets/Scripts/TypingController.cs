using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TypingController : MonoBehaviour
    {
        public Text DisplayedText;
        public string CurrentWordsToType;
        public string CorrectColorHex;
        public string WrongColorHex;
        public string ColorOpenTag;
        public string ColorCloseTag;
        public int CurrentLetterPosition = 0;

        private string _colorOpenTagPrototype;
        public string CurrentLetter { get
            {
                if (CurrentWordsToType[CurrentLetterPosition] == ' ') CurrentLetterPosition++;
                return CurrentWordsToType[CurrentLetterPosition].ToString().ToLower();
            }

        }

        public bool IsKeyDown;

        private void Start()
        {
            _colorOpenTagPrototype = ColorOpenTag;
            DisplayedText.text = CurrentWordsToType;
            ColorOpenTag = string.Format(_colorOpenTagPrototype, CorrectColorHex);
        }
        private void Update()
        {
            if (Input.GetKeyUp(CurrentLetter))
            {
                IsKeyDown = false;
                CurrentLetterPosition++;
            }
            if (Input.anyKey && Input.GetKey(CurrentLetter)) SetNextLetterCorrect();
            else if (Input.anyKey && !IsKeyDown) SetNextLetterWrong();
        }

        private void SetNextLetterWrong()
        {
            ColorOpenTag = string.Format(_colorOpenTagPrototype, WrongColorHex);
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition, CurrentWordsToType.Length - CurrentLetterPosition);
            var result = firstHalf + ColorOpenTag + CurrentLetter + ColorCloseTag + secondHalf.Substring(1, secondHalf.Length - 1) ;

            DisplayedText.text = result;

        }

        private void SetNextLetterCorrect()
        {
            ColorOpenTag = string.Format(_colorOpenTagPrototype, CorrectColorHex);
            if (CurrentLetterPosition >= CurrentWordsToType.Length - 1) return;
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition + 1);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition + 1, CurrentWordsToType.Length - CurrentLetterPosition -1);
            var result = ColorOpenTag + firstHalf + ColorCloseTag + secondHalf;
            DisplayedText.text = result;
            if (CurrentLetter == " ") CurrentLetterPosition++;
            IsKeyDown = true;

        }



    }
}

