using TMPro;
using UnityEngine;

namespace Game.Controller
{
    /// <summary>
    /// Can change TMP text attributes such as color or size. Use with TMP only. Links itself automatically.
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class TextManager : MonoBehaviour
    {
        private TMP_Text text;

        private Color defaultColor;
        public Color newColor;

        private void Start()
        {
            text = GetComponent<TMP_Text>();
            defaultColor = text.color;
            ////ErrorManager.LogError(gameObject, this, $"Není dosazený text v {nameof(TextManager)}.");
        }

        public void SetColor(Color newColor) => this.newColor = newColor;
        public void ChangeColor(Color newColor) => text.color = newColor;
        public void ChangeColor() => text.color = this.newColor;
        public void RestoreColor() => text.color = defaultColor;
    }
}
