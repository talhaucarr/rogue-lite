#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityToolbarExtender;

[InitializeOnLoad]
public class SceneSwitchLeftButton
{
	
	static SceneSwitchLeftButton()
	{
		ToolbarExtender.LeftToolbarGUI.Add(OnToolbarLeftGUI);
		ToolbarExtender.RightToolbarGUI.Add(OnToolbarRightGUI);
	}

	static void OnToolbarLeftGUI()
	{
		GUILayout.FlexibleSpace();
		
		if (GUILayout.Button(new GUIContent("Game Scene", "Switch to GameScene.")))
        {
        	bool saved = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        	if (!saved)
        		return;
        	EditorSceneManager.OpenScene("Assets/_Scenes/GameScene.unity");
        }
	}

	static void OnToolbarRightGUI()
    {
	    //
	    
	    GUILayout.FlexibleSpace();
	}
}
#endif