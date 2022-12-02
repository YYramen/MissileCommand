using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// �e�̓���
/// </summary>
public class BulletMove : MonoBehaviour
{
    [SerializeField]
    float _bulletSpeed = 3f;
    [SerializeField]
    GameObject _explodePrefab;

    public GameObject ExplodePrefab { get => _explodePrefab; }

    //[SerializeField] GameObject _canvasObj;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Move();
        }
    }

    /// <summary>
    /// �N���b�N���ꂽ�n�_�ɒe������
    /// </summary>
    private void Move()
    {
        var targetPos = Input.mousePosition;
        var canvasObj = GameObject.Find("Canvas");

        this.transform.DOMove(targetPos, _bulletSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Instantiate(_explodePrefab, this.transform.position, Quaternion.identity, canvasObj.transform);
                Debug.Log("Move Completed");
                Destroy(this.gameObject);
            });
    }
}
