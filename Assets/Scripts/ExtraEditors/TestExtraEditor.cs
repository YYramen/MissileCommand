using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestExtraEditor : EditorWindow
{
    [MenuItem("Test/Editor extention/Sample", false, 1)]
    private static void ShowWindow()
    {
        TestExtraEditor window = GetWindow<TestExtraEditor>();
        window.titleContent = new GUIContent("Sample Window");
    }
}
