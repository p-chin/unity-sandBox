using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Hoge : MonoBehaviour {

	public Vector3 velocity;
	public Hashtable hash;
	public Dictionary<string, string> dict;
	//public Types argments;
	
	void Awake()
	{
		//dict = new Dictionary<string, string>();
	}
	
	void Start()
	{
		Debug.Log(dict.GetType().GetGenericArguments()[0].ToString());
		Debug.Log(dict.GetType().GetGenericArguments()[1].ToString());
	}
}
