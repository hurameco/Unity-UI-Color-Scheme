using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Toolbox.Editor;
using Toolbox.Editor.Drawers;
using UnityEditor;
using UnityEngine;

namespace UI.UIColor.Theme.Editor
{
    [CustomEditor(typeof(ColorTheme))]
    public class ColorThemeEditor : ToolboxEditor
    {
        SerializedProperty _currentThemeProp;
        ColorTheme _colorTheme;

        private void OnEnable()
        {
            _currentThemeProp = serializedObject.FindProperty("_currentTheme");
            _colorTheme = (serializedObject.targetObject as ColorTheme);
        }

        private void OnDisable()
        {

        }

        public override void DrawCustomInspector()
        {
            serializedObject.Update();

            base.DrawCustomInspector();
            int themeIndex = 0;
            if (_colorTheme.themeKeys.Count > 0)
            {
                if (!string.IsNullOrEmpty(_currentThemeProp.stringValue) && _colorTheme.themeKeys.Contains(_currentThemeProp.stringValue))
                {
                    themeIndex = _colorTheme.themeKeys.IndexOf(_currentThemeProp.stringValue);
                }
                themeIndex = EditorGUILayout.Popup(_currentThemeProp.displayName, themeIndex, _colorTheme.themeKeys.ToArray());
                _currentThemeProp.stringValue = _colorTheme.themeKeys[themeIndex];
                _colorTheme.NotifyObservers(_colorTheme.themeValues[themeIndex]);
                
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}