using UnityEditor;
using UnityEngine;

namespace _Scripts.GameCore.Enemies.Editor
{
    [CustomEditor(typeof(EnemySpawnerService))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    { 
        public EnemySpawnerService spawner => target as EnemySpawnerService;

        private void OnSceneGUI()
        {
            Handles.color = Color.cyan;
        
            for (int i = 0; i < spawner.SpawnPoints.Length; i++)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 currentWaypoint = spawner.SpawnPoints[i];
                Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypoint, Quaternion.identity, 0.5f, Vector3.zero, Handles.SphereHandleCap);
                newWaypointPoint.y = 0f;
                GUIStyle textStyle = new GUIStyle();
                textStyle.fontStyle = FontStyle.Bold;
                textStyle.fontSize = 16;
                textStyle.normal.textColor = Color.magenta;

                Vector3 textAlligment = Vector3.down * 0.35f + Vector3.right * 0.35f;
                Handles.Label( spawner.SpawnPoints[i] + textAlligment, $"{i+1}", textStyle);

                EditorGUI.EndChangeCheck();

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "FreeMove");
                    spawner.SpawnPoints[i] = newWaypointPoint;
                }
            }
        }
    }
}
