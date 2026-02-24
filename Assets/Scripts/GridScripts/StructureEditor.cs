using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StructureScript))]
public class StructureEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        StructureScript thisStructure = (StructureScript)target;

        if (GUILayout.Button("Update Colliders"))
        {
            thisStructure.AttachColliders();
        }
    }
}
