using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ”š”­ˆ—
/// </summary>
public class BulletExlode : MonoBehaviour
{
    [SerializeField] float _lifeTime = 2f;

    private void Start()
    {
        Destroy(this.gameObject, _lifeTime);
    }
}
