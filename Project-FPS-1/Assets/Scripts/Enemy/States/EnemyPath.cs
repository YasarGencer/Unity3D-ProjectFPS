using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EnemyPath : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints;
    public List<Transform> Waypoints { get { return _waypoints; } }
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
        for (int i = 0; i < _waypoints.Count; i++)
        {
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = 30;
            labelStyle.normal.textColor = DebugColour;
            if (_drawNumbers)
                Handles.Label(_waypoints[i].position, i.ToString(), labelStyle);
            //Draw Lines Between Points.
            if (i >= 1)
            {
                Gizmos.color = DebugColour;
                Gizmos.DrawLine(_waypoints[i - 1].position, _waypoints[i].position);

                if (_drawAsLoop)
                    Gizmos.DrawLine(_waypoints[_waypoints.Count - 1].position, _waypoints[0].position);

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