using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    bool showFoldout;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerController player = (PlayerController)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("Player State Machine", EditorStyles.boldLabel);

        if (player.stateMachine == null) return;

        if (player.stateMachine.CurrentState != null)
            EditorGUILayout.LabelField(
                "Current State:",
                player.stateMachine.CurrentState.GetType().Name
            );

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Available States");

        if (showFoldout && player.stateMachine.dictionaryState != null)
        {
            var keys = player.stateMachine.dictionaryState.Keys.ToArray();
            var vals = player.stateMachine.dictionaryState.Values.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                EditorGUILayout.LabelField($"{keys[i]} :: {vals[i].GetType().Name}");
            }
        }
    }
}
