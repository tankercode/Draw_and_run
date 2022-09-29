using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour
{

    [SerializeField]
    public Vector3 angle;

    [SerializeField]
    public float time;

    void Start()
    {
        transform.DOLocalRotate(angle, time).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

   
}
