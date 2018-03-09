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

        private string _correctOpenTag;
        private string _wrongOpenTag;
        private KeyCode _previousPressedKey;
        private void Start()
        {
            DisplayedText.text = CurrentWordsToType;
            _correctOpenTag = string.Format(ColorOpenTag, CorrectColorHex);
            _wrongOpenTag = string.Format(ColorOpenTag, WrongColorHex);
        }

        private void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey && e.keyCode != KeyCode.None && e.keyCode != _previousPressedKey)
            {
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
            if (Input.anyKey && Input.GetKey(CurrentLetter)) SetNextLetterCorrect();
            else if (Input.anyKey && !IsKeyDown) SetNextLetterWrong();
        }

        private void SetNextLetterWrong()
        {
            //CheckPowerStrings();
            var firstHalf = CurrentWordsToType.Substring(0, CurrentLetterPosition);
            var secondHalf = CurrentWordsToType.Substring(CurrentLetterPosition, CurrentWordsToType.Length - CurrentLetterPosition);
            var result = firstHalf + _wrongOpenTag + CurrentLetter + ColorCloseTag + secondHalf.Substring(1, secondHalf.Length - 1) ;

            DisplayedText.text = result;
            PlayerController.BadKey();
        }

        private void SetNextLetterCorrect()
        {
            //CheckPowerStrings();
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
            Debug.Log("Nacisnieto: " + kc);
            _previousPressedKey = kc;

            CurrentPowerString += kc.ToString().ToLower();
            var tmpShoot = ShootKeyword.Substring(0, CurrentPowerString.Length).ToLower();
            var tmpShield = ShieldKeyword.Substring(0, CurrentPowerString.Length).ToLower();

            if(tmpShield == CurrentPowerString || tmpShoot == CurrentPowerString)
            {
                DisplayedPowerText.text = CurrentPowerString;

                if(CurrentPowerString == ShootKeyword)
                {
                    Debug.Log("shooot!");
                    CurrentPowerString = "";
                    DisplayedPowerText.text = "";
                }
                if (CurrentPowerString == ShieldKeyword)
                {
                    Debug.Log("shieeeld!");
                    CurrentPowerString = "";
                    DisplayedPowerText.text = "";
                }
                return;
            }
            CurrentPowerString = "";
            DisplayedPowerText.text = "";
        }
    }
}

