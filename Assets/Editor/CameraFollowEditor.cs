using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CameraFollow))]

public class CameraFollowEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cf = (CameraFollow)target;

        if(GUILayout.Button("Set Min Cam Pos (Left and Down)"))
        {
            cf.SetMinCamPosition();
        }
        if(GUILayout.Button("Set Max Cam Pos (Right and Up)"))
        {
            cf.SetMaxCamPosition();
        }
    }    
}
