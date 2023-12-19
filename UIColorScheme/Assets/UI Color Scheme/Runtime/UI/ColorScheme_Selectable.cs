using System;
using System.Collections.Generic;
using TMPro;
using UI.UIColor.Palette;
using UI.UIColor.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIColor
{
    [RequireComponent(typeof(Selectable))]
    [ExecuteInEditMode]
    public class UIColor_Selectable : MonoBehaviour, IObserver<ColorPalette>
    {
        [SerializeField] private string _normalColorPaletteKey;
        [SerializeField] private string _highlightedColorPaletteKey;
        [SerializeField] private string _pressedColorPaletteKey;
        [SerializeField] private string _selectedColorPaletteKey;
        [SerializeField] private string _disabledColorPaletteKey;
        [SerializeField] private Selectable _selectableComponent;
        [ReorderableList, SerializeField] private List<TextMeshProUGUI> _childTMPTexts = new();

        IDisposable _unsubscriber;

        public string NormalColorPaletteKey => _normalColorPaletteKey;
        public string HighlightedColorPaletteKey => _highlightedColorPaletteKey;
        public string PressedColorPaletteKey => _pressedColorPaletteKey;
        public string SelectedColorPaletteKey => _selectedColorPaletteKey;
        public string DisabledColorPaletteKey => _disabledColorPaletteKey;
        public Selectable SelectableComponent => _selectableComponent;

        public List<TextMeshProUGUI> ChildTMPTexts => _childTMPTexts;

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
            _selectableComponent = GetComponent<Selectable>();
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
            ColorBlock cb = _selectableComponent.colors;
            cb.normalColor = value.GetColor(_normalColorPaletteKey);
            cb.highlightedColor = value.GetColor(_highlightedColorPaletteKey);
            cb.pressedColor = value.GetColor(_pressedColorPaletteKey);
            cb.selectedColor = value.GetColor(_selectedColorPaletteKey);
            cb.disabledColor = value.GetColor(_disabledColorPaletteKey);
            _selectableComponent.colors = cb;

            foreach (var text in _childTMPTexts)
            {
                if (text != null)
                {
                    text.font = value.FontAsset;
                    text.color = value.GetColor("On" + _normalColorPaletteKey);
                }
            }
        }

        private void OnDestroy()
        {
            _unsubscriber?.Dispose();
        }
    }
}