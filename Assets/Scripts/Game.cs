using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Transform _hero;
    [SerializeField] private Transform _enemy;
    [SerializeField] private DistanceDetector _distanceDetector;
    [SerializeField] private float _distanceToWin;
    public float DistanceToWin => _distanceToWin;

    [SerializeField] private float _timerToLose;
    [SerializeField] private float _timerToWin;

    private float _currentTimerToLose;
    private float _currentTimerToWin;

    [SerializeField] private Hero Hero;
    [SerializeField] private Enemy Enemy;

    private Vector3 startHeroPosition;
    private Vector3 startEnemyPosition;


    private void Start()
    {
        SaveHeroAndEnemyPositions();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }

        _currentTimerToLose += Time.deltaTime;

        if (_currentTimerToLose > _timerToLose)
            Defeat();

        if (_distanceDetector.Distance < _distanceToWin)
        {
            _currentTimerToLose = 0;
            _currentTimerToWin += Time.deltaTime;

            if (_currentTimerToWin > _timerToWin)
                Victory();
        }

        else
        {
            _currentTimerToWin = 0;
        }
    }

    private void SaveHeroAndEnemyPositions()
    {
        startHeroPosition = _hero.transform.position;
        startEnemyPosition = _enemy.transform.position;
    }

    private void Victory()
    {
        Debug.Log("Вы победили!");

        Hero.CanMove = false;
        Enemy.CanMove = false;
    }

    private void Defeat()
    {
        Debug.Log("Вы проиграли!");

        Hero.CanMove = false;
        Enemy.CanMove = false;
    }

    private void RestartGame()
    {
        _hero.transform.position = startHeroPosition;
        _enemy.transform.position = startEnemyPosition;

        _currentTimerToLose = 0;
        _currentTimerToWin = 0;

        Hero.CanMove = true;
        Enemy.CanMove = true;

    }
}
