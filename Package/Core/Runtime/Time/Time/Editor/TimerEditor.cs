using TheLuxGames.SharedResources.Time;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Timer))]
public class TimerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var timer = target as Timer;
        if (GUILayout.Button("Reset"))
        {
            timer.ResetTimer();
        }

        if (!timer.Paused)
        {
            if (GUILayout.Button("Pause"))
            {
                timer.PauseTimer();
            }
        }
        else
        {
            if (GUILayout.Button("Resume"))
            {
                timer.ResumeTimer();
            }
        }
    }
}