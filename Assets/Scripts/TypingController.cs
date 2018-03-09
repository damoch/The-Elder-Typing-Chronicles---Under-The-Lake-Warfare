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
        private void Start()
        {
            ColorOpenTag = string.Format(ColorOpenTag, CorrectColorHex);
            InvokeRepeating("SetNextLetterCorrect", 1f, 1f);
        }
        private void Update()
        {

        }

        private void SetNextLetterCorrect()
        {
            if (CurrentLetterPosition++ > CurrentWordsToType.Length - 1) return;
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition, CurrentWordsToType.Length - CurrentLetterPosition);
            var result = ColorOpenTag + firstHalf + ColorCloseTag + secondHalf;
            DisplayedText.text = result;

        }
    }
}

