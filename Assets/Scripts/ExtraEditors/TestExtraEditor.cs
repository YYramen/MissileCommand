using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestExtraEditor : EditorWindow
{
    private string text = "";

    [MenuItem("Test/ExtraEditor/Sample", false, 1)]
    private static void ShowWindow()
    {
        TestExtraEditor window = GetWindow<TestExtraEditor>();
        window.titleContent = new GUIContent("�T���v��");
    }

    private void OnGUI()
    {
        GUILayout.Label("�e�X�g������");

        text = EditorGUILayout.TextArea(text, GUILayout.Height(100));

        //GUILayout.Button("�R���\�[���E�B���h�E�ɏo��");

        if (GUILayout.Button("�R���\�[���ɏo�́I�I"))
        {
            Debug.Log(text);
        }

    }
}
