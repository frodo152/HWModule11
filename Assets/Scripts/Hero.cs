using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    public bool CanMove = true;

    private float _deadZone = 0.1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {   
        if (!CanMove) return;

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input.magnitude <= _deadZone)
            return;

        _characterController.Move(input.normalized * _speed * Time.deltaTime);

        ProcessRotateTo(input.normalized);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction); 
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void StopMove()
    {
        _speed = 0;
    }
}
