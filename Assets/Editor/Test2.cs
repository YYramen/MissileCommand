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
        window.titleContent = new GUIContent("サンプル");
    }

    private void OnGUI()
    {
        GUILayout.Label("テスト文字列");

        text = EditorGUILayout.TextArea(text, GUILayout.Height(100));

        //GUILayout.Button("コンソールウィンドウに出力");

        if (GUILayout.Button("コンソールに出力"))
        {
            Debug.Log(text);
        }


    }
}