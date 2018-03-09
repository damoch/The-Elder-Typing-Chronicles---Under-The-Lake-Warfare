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
        public int CurrentLetterPosition;
        public string CurrentLetter { get
            {
                if (CurrentWordsToType[CurrentLetterPosition] == ' ') CurrentLetterPosition++;
                var result = CurrentWordsToType[CurrentLetterPosition].ToString().ToLower();
                return result;
            }

        }
        private void Start()
        {
            DisplayedText.text = CurrentWordsToType;
            ColorOpenTag = string.Format(ColorOpenTag, CorrectColorHex);

            //InvokeRepeating("SetNextLetterCorrect", 1f, 1f);
        }
        private void Update()
        {
            if (Input.GetKey(CurrentLetter)) SetNextLetterCorrect();

        }

        private void SetNextLetterCorrect()
        {
            if (CurrentLetterPosition++ > CurrentWordsToType.Length - 1) return;
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition, CurrentWordsToType.Length - CurrentLetterPosition);
            var result = ColorOpenTag + firstHalf + ColorCloseTag + secondHalf;
            DisplayedText.text = result;
            if (CurrentLetter == " ") CurrentLetterPosition++;

        }

    }
}

