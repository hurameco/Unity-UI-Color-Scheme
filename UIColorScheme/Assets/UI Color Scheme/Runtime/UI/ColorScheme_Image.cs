using System;
using System.Collections.Generic;
using TMPro;
using UI.UIColor.Palette;
using UI.UIColor.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIColor
{
    [RequireComponent(typeof(Image))]
    [ExecuteInEditMode]
    public class UIColor_Image : MonoBehaviour, IObserver<ColorPalette>
    {
        [SerializeField] private string _ColorPaletteKey;
        [SerializeField] private Image _image;
        [ReorderableList(ListStyle.Round)][SerializeField] private List<TextMeshProUGUI> _childTMPTexts = new();

        public Image Image => _image;
        public string ColorPaletteKey => _ColorPaletteKey;

        public List<TextMeshProUGUI> ChildTMPTexts => _childTMPTexts;

        IDisposable _unsubscriber;

        private void Reset()
        {

            foreach (Transform t in this.transform)
            {
                var text = t.GetComponent<TextMeshProUGUI>();
                if (text != null && !_childTMPTexts.Contains(text))
                {
                    _childTMPTexts.Add(text);
                }
            }
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
            _unsubscriber = ColorTheme.Instance.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ColorPalette value)
        {
            _image.color = value.GetColor(_ColorPaletteKey);
            foreach (var text in _childTMPTexts)
            {
                if (text != null)
                {
                    text.font = value.FontAsset;
                    text.color = value.GetColor("On" + _ColorPaletteKey);
                }
            }
        }

        private void OnDestroy()
        {
            _unsubscriber?.Dispose();
        }
    }
}