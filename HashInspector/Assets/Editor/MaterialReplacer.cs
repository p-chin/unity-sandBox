using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

public class MaterialReplacer : EditorWindow {
	
	[MenuItem("Tool/Material Replace")]
	static void OpenWindow()
	{
		EditorWindow.GetWindow<MaterialReplacer>(false,"shake");	
	}
	static Material targetMaterial = null;
	void OnGUI()
	{
		targetMaterial = EditorGUILayout.ObjectField("Material", targetMaterial,typeof(Material), false) as Material;
		GUI.enabled = (targetMaterial != null) && (Selection.gameObjects.Length > 0);
		if(GUILayout.Button("Replace"))
		{
			foreach(var renderer in from go in Selection.gameObjects select go.renderer)
				if(renderer != null)
					renderer.sharedMaterial = targetMaterial;
		}
		GUI.enabled = true;
	}
}
