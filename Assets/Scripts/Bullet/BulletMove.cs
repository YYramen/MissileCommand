using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// ’e‚Ì“®‚«
/// </summary>
public class BulletMove : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float _bulletSpeed = 3f;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
}
