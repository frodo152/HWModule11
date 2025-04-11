using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float MinDistanceToTarget = 0.05f;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private List<Transform> _targets;

    private Queue<Vector3> _targetsPositions;

    private Vector3 _currentTarget;

    public bool CanMove = true;

    private void Awake()
    {
        _targetsPositions = new Queue<Vector3>();

        foreach (Transform target in _targets)
            _targetsPositions.Enqueue(target.position);

        SwitchTarget();
    }

    private void Update()
    {
        if (!CanMove) return;

        Vector3 direction = _currentTarget - transform.position;

        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();

        Vector3 normalizedDirection = direction.normalized;

        ProcessMoveTo(normalizedDirection);
        ProcessRotateTo(normalizedDirection);
    }

    private void SwitchTarget()
    {
        _currentTarget = _targetsPositions.Dequeue();
        _targetsPositions.Enqueue(_currentTarget);
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
