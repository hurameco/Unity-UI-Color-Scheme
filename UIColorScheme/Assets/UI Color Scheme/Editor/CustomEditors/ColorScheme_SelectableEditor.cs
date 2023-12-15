using System;
using Toolbox.Editor;
using UI.UIColor.Palette;
using UI.UIColor.Theme;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIColor.Editor
{
    [CustomEditor(typeof(UIColor_Selectable))]
    public class ColorPalette_SelectableEditor : ToolboxEditor, IObserver<ColorPalette>
    {
        SerializedProperty _normalColorKey;
        SerializedProperty _highlightedColorKey;
        SerializedProperty _pressedColorKey;
        SerializedProperty _selectedColorKey;
        SerializedProperty _disabledColorKey;
        SerializedProperty _childTMPTextsProp;
        SerializedProperty _selectable;
        UIColor_Selectable _ColorPaletteSelectable;

        bool _foldout = true;

        private void Awake()
        {
            _normalColorKey = serializedObject.FindProperty("_normalColorPaletteKey");
            _highlightedColorKey = serializedObject.FindProperty("_highlightedColorPaletteKey");
            _pressedColorKey = serializedObject.FindProperty("_pressedColorPaletteKey");
            _selectedColorKey = serializedObject.FindProperty("_selectedColorPaletteKey");
            _disabledColorKey = serializedObject.FindProperty("_disabledColorPaletteKey");
            _childTMPTextsProp = serializedObject.FindProperty("_childTMPTexts");
            _selectable = serializedObject.FindProperty("_selectable");
            _ColorPaletteSelectable = serializedObject.targetObject as UIColor_Selectable;
            ColorTheme.Instance.Subscribe(this);
        }

        public override void DrawCustomInspector()
        {
            //base.DrawCustomInspector();

            serializedObject.Update();
            int index = 0;
            if (!string.IsNullOrEmpty(_normalColorKey.stringValue))
            {
                index = ColorTheme.Instance.CurrentTheme.mainProperties.IndexOf(_normalColorKey.stringValue);
            }

            index = EditorGUILayout.Popup("Normal Color Key", index, ColorTheme.Instance.CurrentTheme.mainProperties.ToArray());

            if (index > -1)
            {
                _normalColorKey.stringValue = ColorTheme.Instance.CurrentTheme.mainProperties[index];

            }

            index = 0;
            if (!string.IsNullOrEmpty(_highlightedColorKey.stringValue))
            {
                index = ColorTheme.Instance.CurrentTheme.mainProperties.IndexOf(_highlightedColorKey.stringValue);
            }

            index = EditorGUILayout.Popup("Highlighted Color Key", index, ColorTheme.Instance.CurrentTheme.mainProperties.ToArray());

            if (index > -1)
            {
                _highlightedColorKey.stringValue = ColorTheme.Instance.CurrentTheme.mainProperties[index];

            }

            index = 0;
            if (!string.IsNullOrEmpty(_pressedColorKey.stringValue))
            {
                index = ColorTheme.Instance.CurrentTheme.mainProperties.IndexOf(_pressedColorKey.stringValue);
            }

            index = EditorGUILayout.Popup("Pressed Color Key", index, ColorTheme.Instance.CurrentTheme.mainProperties.ToArray());

            if (index > -1)
            {
                _pressedColorKey.stringValue = ColorTheme.Instance.CurrentTheme.mainProperties[index];

            }

            index = 0;
            if (!string.IsNullOrEmpty(_selectedColorKey.stringValue))
            {
                index = ColorTheme.Instance.CurrentTheme.mainProperties.IndexOf(_selectedColorKey.stringValue);
            }

            index = EditorGUILayout.Popup("Selected Color Key", index, ColorTheme.Instance.CurrentTheme.mainProperties.ToArray());

            if (index > -1)
            {
                _selectedColorKey.stringValue = ColorTheme.Instance.CurrentTheme.mainProperties[index];

            }

            index = 0;
            if (!string.IsNullOrEmpty(_disabledColorKey.stringValue))
            {
                index = ColorTheme.Instance.CurrentTheme.mainProperties.IndexOf(_disabledColorKey.stringValue);
            }

            index = EditorGUILayout.Popup("Disabled Color Key", index, ColorTheme.Instance.CurrentTheme.mainProperties.ToArray());

            if (index > -1)
            {
                _disabledColorKey.stringValue = ColorTheme.Instance.CurrentTheme.mainProperties[index];

            }

            ToolboxEditorGui.DrawToolboxProperty(_childTMPTextsProp, new GUIContent("Associated TMP Childs"));

            var cb = _ColorPaletteSelectable.SelectableComponent.colors;
            cb.normalColor = ColorTheme.Instance.CurrentTheme.GetColor(_normalColorKey.stringValue);
            cb.highlightedColor = ColorTheme.Instance.CurrentTheme.GetColor(_highlightedColorKey.stringValue);
            cb.pressedColor = ColorTheme.Instance.CurrentTheme.GetColor(_pressedColorKey.stringValue);
            cb.selectedColor = ColorTheme.Instance.CurrentTheme.GetColor(_selectedColorKey.stringValue);
            cb.disabledColor = ColorTheme.Instance.CurrentTheme.GetColor(_disabledColorKey.stringValue);
            _ColorPaletteSelectable.SelectableComponent.colors = cb;


            foreach (var text in _ColorPaletteSelectable.ChildTMPTexts)
            {
                if (text != null)
                {
                    text.font = ColorTheme.Instance.CurrentTheme.FontAsset;
                    text.color = ColorTheme.Instance.CurrentTheme.GetColor("On" + _normalColorKey.stringValue);
                }
            }

            serializedObject.ApplyModifiedProperties();
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
            _ColorPaletteSelectable.OnNext(value);
        }
    }
}