﻿using UnityEditor;
using System.Collections;
using UnityEngine;

[CustomEditor(typeof (OutdoorMapController))]
public class OutdoorMapGeneratorView : Editor {
	
	public override void OnInspectorGUI() {
        OutdoorMapController outdoorMapController = (OutdoorMapController)target;

        if (DrawDefaultInspector()) {
			// if (outdoorMapGenerator.autoUpdate) {
			// 	...
			// }
		}
		
		
		if (GUILayout.Button("Generate Texture")) {
            Debug.Log("View: button with texture clicked");
            outdoorMapController.GenerateNonColourTexture();
        	}
       
		
		if (GUILayout.Button("Generate Mesh")) {
			//...
		}
            
        
	}
	
	
}
