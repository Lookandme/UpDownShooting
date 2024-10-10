using System;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
   
    
    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 driection)
    {
        RotateArm(driection);
    }

    private void RotateArm(Vector2 driection)
    {
        float rotZ = Mathf.Atan2(driection.y, driection.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }
}
