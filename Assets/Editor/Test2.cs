using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test2 : EditorWindow
{
    private string text = "";

    [MenuItem("Test/ExtraEditor/aaa", priority = 1, validate = true)]
    private static void ShowWindow()
    {
        Test2 window = GetWindow<Test2>();
        window.titleContent = new GUIContent("�T���v��");
    }

    private void OnGUI()
    {
        GUILayout.Label("�e�X�g������");

        text = EditorGUILayout.TextArea(text, GUILayout.Height(100));

        //GUILayout.Button("�R���\�[���E�B���h�E�ɏo��");

        if (GUILayout.Button("�R���\�[���ɏo��"))
        {
            Debug.Log(text);
        }


    }
}