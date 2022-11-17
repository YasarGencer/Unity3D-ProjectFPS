using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EnemyPath : MonoBehaviour
{

    public List<Transform> Waypoints;
    [SerializeField]
    private bool _alwaysDrawPath;
    [SerializeField]
    private bool _drawAsLoop;
    [SerializeField]
    private bool _drawNumbers;
    public Color DebugColour = Color.white;

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        if (_alwaysDrawPath)
        {
            DrawPath();
        }
    }
    public void DrawPath()
    {
        for (int i = 0; i < Waypoints.Count; i++)
        {
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = 30;
            labelStyle.normal.textColor = DebugColour;
            if (_drawNumbers)
                Handles.Label(Waypoints[i].position, i.ToString(), labelStyle);
            //Draw Lines Between Points.
            if (i >= 1)
            {
                Gizmos.color = DebugColour;
                Gizmos.DrawLine(Waypoints[i - 1].position, Waypoints[i].position);

                if (_drawAsLoop)
                    Gizmos.DrawLine(Waypoints[Waypoints.Count - 1].position, Waypoints[0].position);

            }
        }
    }
    public void OnDrawGizmosSelected()
    {
        if (_alwaysDrawPath)
            return;
        else
            DrawPath();
    }
#endif
}