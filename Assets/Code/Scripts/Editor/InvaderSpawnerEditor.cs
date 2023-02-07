using UnityEditor;
using UnityEngine;

namespace Code.Scripts.Editor
{
    [CustomEditor(typeof(InvaderSpawner))]
    public class InvaderSpawnerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var invaderSpawner = (InvaderSpawner) target;

            if (GUILayout.Button("Spawn invaders"))
            {
                invaderSpawner.Spawn();
            }

            if (GUILayout.Button("Remove invaders"))
            {
                invaderSpawner.Destroy();
            }
        }
    }
}