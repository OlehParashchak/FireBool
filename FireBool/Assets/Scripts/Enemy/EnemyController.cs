using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float _minPointX;
    private float _maxPointX;

    [SerializeField]
    private float _minMovingDuration;
    [SerializeField]
    private float _maxMovingDuration;

    private SpriteRenderer _enemySprite;

    private float _delayBetweenMovements;

    private Sequence _moveSequence;
    
    [SerializeField]
    private ParticleSystem _deathParticlesPrefab;

    private float GetRandomMovementDuration()
    {
        return Random.Range(_minMovingDuration, _maxMovingDuration);
    }

    private void Move()
    {
        var randomMovementDuration = GetRandomMovementDuration();
        var nextPosition = GetNextRandomPositionX();

        _moveSequence = DOTween.Sequence();
        _moveSequence.Append(transform.DOMoveX(nextPosition, randomMovementDuration));
        _moveSequence.AppendInterval(_delayBetweenMovements);
        _moveSequence.OnComplete(Move);
    }

    private float GetNextRandomPositionX()
    {
        return Random.Range(_minPointX, _maxPointX);
    }

    public void Initialize(float minPointX, float maxPointX, float delayBetweenMovements)
    {
        _enemySprite = GetComponent<SpriteRenderer>();
        var offsetX = _enemySprite.bounds.size.x / 2;

        _minPointX = minPointX + offsetX;
        _maxPointX = maxPointX - offsetX;
        _delayBetweenMovements = delayBetweenMovements;

        Move();
    }

    //вызывается по событие уничтожения врага.
    [UsedImplicitly]
    public void Destroy()
    {
        Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _moveSequence.Kill();
    }
}
