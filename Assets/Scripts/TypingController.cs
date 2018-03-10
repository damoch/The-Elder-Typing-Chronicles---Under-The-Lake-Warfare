using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TypingController : MonoBehaviour
    {
        public Text DisplayedText;
        public Text DisplayedPowerText;
        public string CurrentWordsToType;
        public string CorrectColorHex;
        public string WrongColorHex;
        public string ColorOpenTag;
        public string ColorCloseTag;
        public int CurrentLetterPosition = 0;
        public string ShootKeyword;
        public string ShieldKeyword;
        public string CurrentLetter { get
            {
                if (CurrentWordsToType.Length == CurrentLetterPosition)
                {
                    CurrentWordsToType = GetRestOfThisBrutalUnderLakeWarfareStory();
                    DisplayedText.text = CurrentWordsToType;
                    CurrentLetterPosition = 0;
                }
                if (CurrentWordsToType[CurrentLetterPosition] == ' ')
                {
                    CurrentWordsToType = CurrentWordsToType.Substring(CurrentLetterPosition + 1);
                    CurrentLetterPosition = 0;
                }
                return CurrentWordsToType[CurrentLetterPosition].ToString().ToLower();
            }

        }

        public bool IsKeyDown;
        public string CurrentPowerString;
        public int PowerIndex = 0;
        public PlayerController PlayerController;
        public TextAsset GameText;

        private string _correctOpenTag;
        private string _wrongOpenTag;
        private KeyCode _previousPressedKey;
        private bool _wrongKeyDown;
        private Stack _textStack;

        private void Start()
        {
            _textStack = new Stack();
            var text = GameText.text.Split(Environment.NewLine.ToCharArray()).ToList();
            text.RemoveAll(x => x == string.Empty);
            text.Reverse();
            text.ForEach(x => _textStack.Push(x));
            DisplayedText.text = CurrentWordsToType;
            _correctOpenTag = string.Format(ColorOpenTag, CorrectColorHex);
            _wrongOpenTag = string.Format(ColorOpenTag, WrongColorHex);
        }

        private void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey && e.keyCode != KeyCode.None && e.keyCode != _previousPressedKey)
            {
                _wrongKeyDown = false;
                CheckPowerStrings(e.keyCode);
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(CurrentLetter))
            {
                IsKeyDown = false;
                CurrentLetterPosition++;
            }
            if (Input.GetKeyUp(_previousPressedKey)) _previousPressedKey = KeyCode.None;
            if (Input.anyKey && Input.GetKey(CurrentLetter)) SetNextLetterCorrect();
            else if (Input.anyKey && !IsKeyDown) SetNextLetterWrong();
        }

        private void SetNextLetterWrong()
        {
            if (IsKeyDown || _wrongKeyDown) return;
            _wrongKeyDown = true;
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition, CurrentWordsToType.Length - CurrentLetterPosition);
            var result = firstHalf + _wrongOpenTag + CurrentLetter + ColorCloseTag + secondHalf.Substring(1, secondHalf.Length - 1) ;

            DisplayedText.text = result;
            PlayerController.BadKey();
        }


        private void SetNextLetterCorrect()
        {
            if (IsKeyDown) return;
            if (CurrentLetterPosition >= CurrentWordsToType.Length - 1) return;
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition + 1);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition + 1);
            IsKeyDown = true;
            var result = _correctOpenTag + firstHalf + ColorCloseTag + secondHalf;
            DisplayedText.text = result;

            PlayerController.GoodKey();
        }

        private void CheckPowerStrings(KeyCode kc)
        {
            _previousPressedKey = kc;

            CurrentPowerString += kc.ToString().ToLower();
            var len = CurrentPowerString.Length;
            var tmpShoot = ShootKeyword.Substring(0, len < ShootKeyword.Length ? len : 0).ToLower();
            var tmpShield = ShieldKeyword.Substring(0, len < ShieldKeyword.Length ? len : 0).ToLower();

            if((ShootKeyword.StartsWith(CurrentPowerString) && PlayerController.HasBullet) 
                || (ShieldKeyword.StartsWith(CurrentPowerString) && PlayerController.HasShield))
            {
                DisplayedPowerText.text = CurrentPowerString;

                if(CurrentPowerString == ShootKeyword)
                {
                    PlayerController.Shoot();
                    CurrentPowerString = "";
                    DisplayedPowerText.text = "";
                }
                if (CurrentPowerString == ShieldKeyword)
                {
                    PlayerController.Shield();
                    CurrentPowerString = "";
                    DisplayedPowerText.text = "";
                }
                return;
            }
            CurrentPowerString = "";
            DisplayedPowerText.text = "";
        }

        private string GetRestOfThisBrutalUnderLakeWarfareStory()
        {
            //dac potem te teksty z pliku xd
            return _textStack.Pop().ToString();
        }
    }
}

