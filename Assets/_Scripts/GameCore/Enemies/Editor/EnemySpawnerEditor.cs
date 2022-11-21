using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace _Scripts.GameCore.Enemies.Editor
{
    [CustomEditor(typeof(EnemySpawnerService))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    { 
        private const float HandleSize = .5f;
        public EnemySpawnerService spawner => target as EnemySpawnerService;

        private void OnSceneGUI()
        {
            Handles.color = Color.cyan;
        
            for (int i = 0; i < spawner.SpawnPoints.Length; i++)
            {
                EditorGUI.BeginChangeCheck();
                
                float size = HandleUtility.GetHandleSize(spawner.SpawnPoints[i]) * 0.2f;
                Vector3 snap = Vector3.one * 0.5f;

                Vector3 currentWaypoint = spawner.SpawnPoints[i];
                Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypoint, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
                newWaypointPoint.y = 0f;
                GUIStyle textStyle = new GUIStyle();
                textStyle.fontStyle = FontStyle.Bold;
                textStyle.fontSize = 16;
                textStyle.normal.textColor = Color.magenta;

                Vector3 textAlligment = new Vector3(0, 0, 0);
                Handles.Label( spawner.SpawnPoints[i] + textAlligment, $"{i+1}", textStyle);

                EditorGUI.EndChangeCheck();

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "MoveSpawnPoint" + (i + 1).ToString());
                    spawner.SpawnPoints[i] = newWaypointPoint;
                }
            }
        }
    }
}
