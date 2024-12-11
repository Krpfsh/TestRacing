using TMPro;
using UnityEngine;

namespace YG.Example
{
    public class LanguageExample : MonoBehaviour
    {
        public string ru, en, tr, es, ar, de;
        private TextMeshProUGUI text;
        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            SwitchLanguage(YG2.lang);
            SwitchLanguageEnvir(YG2.envir.language);
        }

        private void OnEnable()
        {
            YG2.onSwitchLang += SwitchLanguage;
        }
        private void OnDisable()
        {
            YG2.onSwitchLang -= SwitchLanguage;
        }

        public void SwitchLanguage(string lang)
        {
            switch (lang)
            {
                case "ru":
                    text.text = ru;
                    break;
                case "en":
                    text.text = en;
                    break;
                case "tr":
                    text.text = tr;
                    break;
                case "es":
                    text.text = es;
                    break;
                case "ar":
                    text.text = ar;
                    break;
                case "de":
                    text.text = de;
                    break;
                default:
                    text.text = en;
                    break;
            }
        }
        public void SwitchLanguageEnvir(string lang)
        {
            switch (lang)
            {
                case "ru":
                    text.text = ru;
                    break;
                case "en":
                    text.text = en;
                    break;
                case "tr":
                    text.text = tr;
                    break;
                case "es":
                    text.text = es;
                    break;
                case "ar":
                    text.text = ar;
                    break;
                case "de":
                    text.text = de;
                    break;
                default:
                    text.text = en;
                    break;
            }
        }
    }
}