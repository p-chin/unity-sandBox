using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Hoge))]
public sealed class HelloEditorInspector : Editor {
	
	static Hoge hoge;
	/**Vector3**/
	static Vector3 copyBuffer = Vector3.zero;
	/**Hashtable**/
	static List<string> hashKey;
	static string[] defaultKey;
	static List<string> hashValue;
	static string[] defaultValue;
	static int currentHashSize;
	static int inspectorHashSize;
	
	public void OnEnable()
	{
		hoge = target as Hoge;
		hashKey = new List<string>();
		hashValue = new List<string>();
		//defaultKey = new List<string>();
		//defaultValue = new List<string>();
		hoge.dict = new Dictionary<string, string>();
	}
	
	public override void OnInspectorGUI()
	{
		/**Vector3Field**/
		Vector3 v = EditorGUILayout.Vector3Field("Velocity", hoge.velocity);
		EditorGUILayout.BeginHorizontal();
			if(GUILayout.Button("Reset", EditorStyles.miniButton))
			{
				v = Vector3.zero;
			}
			GUILayout.Space(GUILayoutUtility.GetAspectRect(1).width / 3);
			if(GUILayout.Button("Copy", EditorStyles.miniButtonLeft))
			{
				copyBuffer = v;
			}
			if(GUILayout.Button("Paste", EditorStyles.miniButtonRight))
			{
				v = copyBuffer;
			}
		EditorGUILayout.EndHorizontal();
		if(v != hoge.velocity) // 変更があった場合.
		{
			Undo.RegisterUndo(hoge, "Velocity Change");
			hoge.velocity = v; 
			EditorUtility.SetDirty(target);//Asset update
		}
		
		/**HashField**/
		EditorGUILayout.LabelField("HashTable");
		EditorGUILayout.BeginVertical();
			currentHashSize = EditorGUILayout.IntField("size",currentHashSize);
			//if(GUI.changed)
			//{
				Debug.Log("GUI changed");
				defaultKey = new string[currentHashSize];
				defaultValue = new string[currentHashSize];
				initArray(defaultKey);
				initArray(defaultValue);
				for(int i=0; i<currentHashSize; i++)
				{
					Debug.Log("create" + i);
					//defaultKey.Add("");
					//defaultValue.Add("");
					EditorGUILayout.BeginHorizontal();
						defaultKey[i] = EditorGUILayout.TextField("key",defaultKey[i]);
						defaultValue[i] = EditorGUILayout.TextField("value", defaultValue[i]);
					EditorGUILayout.EndHorizontal();			
				}
				/**Buttons**/
				EditorGUILayout.BeginHorizontal();
					GUILayout.Space(GUILayoutUtility.GetAspectRect(1).width / 3);
					if(GUILayout.Button("Clear", EditorStyles.miniButtonRight))
					{
						Debug.Log("Clear");
					}
					if(GUILayout.Button("Apply", EditorStyles.miniButtonRight))
					{
						Debug.Log("Apply");
					}
				EditorGUILayout.EndHorizontal();
			//}
		EditorGUILayout.EndVertical();
	}
	
	void initArray(string[] strArray)
	{
		for(int i = 0; i<strArray.Length; i++)
		{
			strArray[i] = "";	
		}		
	}
	/**if Clear**/
	void clearHogeHash()
	{
		hoge.dict.Clear();	
	}
	
	/**if Apply**/
	void updateHogeHash()
	{
		for(int i=0; i<defaultKey.Length; i++)
		{
			hoge.dict.Add(defaultKey[i],defaultValue[i]);
		}
	}
}