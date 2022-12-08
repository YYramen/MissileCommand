using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class Example : EditorWindow
{
    private SearchField m_searchField;
    private string m_text;

    [MenuItem("Tools/Hoge")]
    private static void Open()
    {
        GetWindow<Example>();
    }

    private void OnGUI()
    {
        m_searchField ??= new SearchField();
        m_text = m_searchField.OnToolbarGUI(m_text);
    }
}