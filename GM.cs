using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GM : MonoBehaviour
{

    public float _gameScore=0;
    public int _levelNumber=0;
    // need
    // spawn new items
    [SerializeField]
    public SplineComputer _sc;

    [SerializeField]
    public UI ui;

    [SerializeField]
    public GuardGroup _gg;

    [SerializeField]
    public UnityEvent LevelFailed;

    public int _gameLives = 0;

    private void Start()
    {
        ui.ShowStartButton();
        _gg.GenNewUnits();
    }

    public void initGame() {
        _gameLives = _gg._unitsCount;
        ui.HideStartButton();
    }

    public void CheckGG() {

        _gameLives--;

        if (_gameLives > 0) { }
        else { LoseGame(); }
    }

    public void UpGameScore() {
        _gameScore++;
    }

    // need 
    // show next level button
    public void WinGame() {
        _gg.StartDancing();
        _gameScore += _gg._units.Count;
        _levelNumber++;
    }
    // need 
    //show restart button
    public void LoseGame() {
        _gg.transform.GetComponent<SplineFollower>().followSpeed = 0;
        ui.ShowrREStartButton();
    }

    //need
    //show start button
    public void RestartGame() {
        _gg.KILLEVERYONE();
        _gg.transform.GetComponent<SplineFollower>().followSpeed = 0;
        _gg.transform.GetComponent<SplineFollower>().SetDistance(0);
        _gg.GenNewUnits();
    }

    public void StartGame() {
        _gg.StartRunning();
    }



}
