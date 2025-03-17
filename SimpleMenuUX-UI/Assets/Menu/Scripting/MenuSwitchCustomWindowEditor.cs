using UnityEditor;
using UnityEngine;

/// <summary>
/// Menu Editor to switch between custom Menus and update References in rela time editor mode
/// </summary>
public class MenuSwitchCustomWindowEditor : EditorWindow
{
    [MenuItem("Simple/Simple Menu Window")]
    public static void ShowWindow()
    {
        GetWindow<MenuSwitchCustomWindowEditor>("Simple Menu");
    }

    [InitializeOnLoadMethod]
    static void OpenWindowOnLoad()
    {
        // Check if the window has already been opened in this session.
        if (!SessionState.GetBool("MenuSwitchCustomWindowEditor_Opened", false))
        {
            // Open the window.
            ShowWindow();

            // Mark the window as opened in this session.
            SessionState.SetBool("MenuSwitchCustomWindowEditor_Opened", true);
        }
    }
    private void OnGUI()
    {
        // Add your UI elements here
        GUILayout.Label("This is a simple custom window.", EditorStyles.boldLabel);

        // Example: Add a button
        if (GUILayout.Button("Click Me"))
        {
            Debug.Log("Button Clicked!");
        }
    }
}
