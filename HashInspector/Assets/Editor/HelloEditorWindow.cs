using UnityEngine;
using UnityEditor;
using System.Collections;

public class HelloEditorWindow : EditorWindow {
	
	[MenuItem("Oppai/shake")]
	static void OpenWindow()
	{
		EditorWindow.GetWindow<HelloEditorWindow>(false,"shake");	
	}
}
