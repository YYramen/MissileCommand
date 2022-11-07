using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// 弾の動き
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 3f;
    [SerializeField] GameObject _explodePrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Move();
        }
    }

    /// <summary>
    /// クリックされた地点に弾が動く
    /// </summary>
    private void Move()
    {
        var targetPos = Input.mousePosition;

        this.transform.DOMove(targetPos, _bulletSpeed)
            .SetEase(Ease.Linear)
            .onComplete(OnCompleteMove);
    }

    private void OnCompleteMove()
    {
        Instantiate(_explodePrefab);
    }
}
