using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Romb : MonoBehaviour
{
    [SerializeField]
    public float time;

    [SerializeField]
    public float yRange;

    [SerializeField]
    public float _timeBeforeDeath;

    [SerializeField]
    public UnityEvent _gameScoreIncrise;

    private void OnTriggerEnter(Collider other)
    {
        KillMe();
    }

    public void KillMe() {
        transform.DOLocalMoveY(yRange, time);
        _gameScoreIncrise.Invoke();
        //Destroy(transform);    
    }

}
