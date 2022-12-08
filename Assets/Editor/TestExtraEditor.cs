using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestExtraEditor : EditorWindow
{

    [MenuItem("Editor/Sample")]
    private static void Create()
    {
        GetWindow<EditorWindowSample>("ƒTƒ“ƒvƒ‹");
    }

    public class EditorWindowSample : EditorWindow
    {
        private Vector2 _dataScrollPosition;
        private Vector2 _parameterScrollPosition;


    private void OnGUI()
        {
            using (new GUILayout.HorizontalScope())
            {
                UpdateLayoutData();
                UpdateLayoutParameter();
            }
        }

        private void UpdateLayoutData()
        {
            using (GUILayout.ScrollViewScope scroll = new GUILayout.ScrollViewScope(_dataScrollPosition, EditorStyles.helpBox, GUILayout.Width(150)))
            {
                _dataScrollPosition = scroll.scrollPosition;

                GUILayout.Label("data");
            }
        }
        private void UpdateLayoutParameter()
        {
            using (GUILayout.ScrollViewScope scroll = new GUILayout.ScrollViewScope(_parameterScrollPosition, EditorStyles.helpBox))
            {
                _parameterScrollPosition = scroll.scrollPosition;

                GUILayout.Label("parameter");
            }
        }
    }
}
