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
        window.titleContent = new GUIContent("サンプル");
    }

    private void OnGUI()
    {
        GUILayout.Label("テスト文字列");

        text = EditorGUILayout.TextArea(text, GUILayout.Height(100));

        //GUILayout.Button("コンソールウィンドウに出力");

        if (GUILayout.Button("コンソールに出力！！"))
        {
            Debug.Log(text);
        }

    }
}
