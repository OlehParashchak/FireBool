using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserMoveTimeLimiter : MonoBehaviour
{
    [SerializeField]
    private float _timeLimiterDuration;
    [SerializeField]
    private float _finishTimeLimiterScale;

    private Vector3 _startTimeLimiterScale;
    private Sequence _timeLimiterSequence;

    [SerializeField]
    private UnityEvent _timeIsOver;

    private void Start()
    {
        _startTimeLimiterScale = transform.localScale;

        StartTimeLimiterSequence();
    }

    private void StartTimeLimiterSequence()
    {
        _timeLimiterSequence = DOTween.Sequence();
        _timeLimiterSequence.SetAutoKill(false);
        _timeLimiterSequence.Append(transform.DOScale(_startTimeLimiterScale, 0f));
        _timeLimiterSequence.Append(transform.DOScale(_finishTimeLimiterScale, _timeLimiterDuration));
        _timeLimiterSequence.OnComplete(_timeIsOver.Invoke);
    }

    public void RestartTimeLimiter()
    {
        _timeLimiterSequence.Restart();
    }

    public void StopTimeLimiter()
    {
        _timeLimiterSequence.Pause();
        transform.localScale = Vector3.zero;
    }
}