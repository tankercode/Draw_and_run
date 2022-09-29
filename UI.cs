using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI : MonoBehaviour
{
    [SerializeField]
    public GameObject _startButton;

    [SerializeField]
    public GameObject _restartButton;

    public void ShowStartButton() {
        _startButton.transform.DOLocalMoveY(0, 2);
    }

    public void HideStartButton() {
        _startButton.transform.DOLocalMoveY(1000, 2);
    }

    public void ShowrREStartButton()
    {
        _restartButton.transform.DOLocalMoveY(0, 2);
    }

    public void HideREStartButton()
    {
        _restartButton.transform.DOLocalMoveY(1000, 2);
    }



}
