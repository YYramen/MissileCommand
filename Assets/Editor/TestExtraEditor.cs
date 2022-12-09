using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI;

public class TestExtraEditor : EditorWindow
{
    List<GameObject> _sampleObjects = new List<GameObject>();
    GameObject _selectedObjects;

    private Vector2 _dataScrollPosition;
    private Vector2 _parameterScrollPosition;

    [MenuItem("Editor/Sample")]
    private static void Create()
    {
        GetWindow<TestExtraEditor>("サンプル");
    }

    private void OnGUI()
    {
        using (new GUILayout.HorizontalScope())
        {
            UpdateLayoutGameObjects();
            UpdateLayoutInspector();
        }
    }

    private void UpdateLayoutGameObjects()
    {
        using (GUILayout.ScrollViewScope scroll = new GUILayout.ScrollViewScope(_dataScrollPosition, EditorStyles.helpBox, GUILayout.Width(150)))
        {
            _dataScrollPosition = scroll.scrollPosition;

            GenericMenu menu = new GenericMenu();
            if (Event.current.type == EventType.ContextClick && Event.current.button == 1)
            {
                menu.AddItem(new GUIContent("AddSample"), false, () =>
                {
                    _sampleObjects.Add(Instantiate<GameObject>(_selectedObjects));
                    _selectedObjects = _sampleObjects[_sampleObjects.Count - 1];
                });
            }

            // メニュー表示
            if (menu.GetItemCount() > 0)
            {
                menu.ShowAsContext();
                Event.current.Use();
            }

            GUILayout.Label("GameObjects");
        }
    }

    private void UpdateLayoutInspector()
    {
        using (GUILayout.ScrollViewScope scroll = new GUILayout.ScrollViewScope(_parameterScrollPosition, EditorStyles.helpBox))
        {
            _parameterScrollPosition = scroll.scrollPosition;

            GUILayout.Label("Inspector");
        }
    }
}

