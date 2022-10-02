using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAattackRange : MonoBehaviour
{
    [SerializeField] private float angle; // 각도
    [SerializeField] private float radius; // 반지름
    [SerializeField] private GameObject owner;
    [SerializeField] private Color color;
    [SerializeField] private GizmoTpye gizmoTpye;

    //[SerializeField] private Material _material;
    
    public void DrawCircle(Material _material,float Duration)
    {
        _material.SetFloat("_Duration",Duration);
        //_material.SetVector("Center",new Vector4(owner.transform.position.x,owner.transform.position.y,owner.transform.position.z,0f));
    }

    private void DrawSectorForm()
    {

    }
}

public enum GizmoTpye
{
    circle,
    sectorform,
}




