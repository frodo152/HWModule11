using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DistanceDetector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _heroPosition;
    [SerializeField] private Transform _enemyPosition;
    [SerializeField] private Game _game;

    private float _distance;
    public float Distance => _distance;

    private void Awake()
    {
        Color currentCameraColor = _camera.backgroundColor;
    }

    private void Update()
    {
        Vector3 direction = _enemyPosition.position - _heroPosition.position;
        _distance = direction.magnitude;

        if (_distance < _game.DistanceToWin)
            SwitchCameraBackgroundToGreen();
        else
            SwitchCameraBackgroundToRed();
    }

    private void SwitchCameraBackgroundToGreen()
    {
        _camera.backgroundColor = new Color(0.51f, 0.796f, 0.27f);
    }

    private void SwitchCameraBackgroundToRed()
    {
        _camera.backgroundColor = new Color(0.784f, 0.196f, 0.196f);
    }

}
