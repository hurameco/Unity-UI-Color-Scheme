using System;
using Toolbox.Editor;
using UI.UIColor.Palette;
using UI.UIColor.Theme;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIColor.Editor
{
    [CustomEditor(typeof(UIColor_Image))]
    public class UIColor_ImageEditor : ToolboxEditor, IObserver<ColorPalette>
    {
        SerializedProperty _colorKey;
        SerializedProperty _image;
        SerializedProperty _childTMPTextsProp;
        UIColor_Image _ColorPaletteImage;

        bool _foldout = true;

        private void Awake()
        {
            _colorKey = serializedObject.FindProperty("_ColorPaletteKey");
            _childTMPTextsProp = serializedObject.FindProperty("_childTMPTexts");
            _image = serializedObject.FindProperty("_image");
            _ColorPaletteImage = serializedObject.targetObject as UIColor_Image;
            ColorTheme.Instance.Subscribe(this);
        }

        public override void DrawCustomInspector()
        {
            //base.DrawCustomInspector();

            serializedObject.Update();
            int index = 0;
            if (!string.IsNullOrEmpty(_colorKey.stringValue))
            {
                index = ColorTheme.Instance.CurrentTheme.mainProperties.IndexOf(_colorKey.stringValue);
            }

            index = EditorGUILayout.Popup("Color Key", index, ColorTheme.Instance.CurrentTheme.mainProperties.ToArray());
            
            if(index > -1)
            {
                _colorKey.stringValue = ColorTheme.Instance.CurrentTheme.mainProperties[index];
                ((Image)_image.objectReferenceValue).color = ColorTheme.Instance.CurrentTheme.GetColor(_colorKey.stringValue);
            }

            ToolboxEditorGui.DrawToolboxProperty(_childTMPTextsProp, new GUIContent("Associated TMP Childs"));

            foreach(var text in _ColorPaletteImage.ChildTMPTexts)
            {
                if (text != null)
                {
                    text.font = ColorTheme.Instance.CurrentTheme.FontAsset;
                    text.color = ColorTheme.Instance.CurrentTheme.GetColor("On" + _colorKey.stringValue);
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
            _ColorPaletteImage.OnNext(value);
        }
    }
}