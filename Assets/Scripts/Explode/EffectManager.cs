using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;


public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private ExplosionEffect _effectPrefab;

    [SerializeField]
    private Transform _hierarchyTransform;

    private EffectPool _effectPool;

    void Start()
    {
        //�I�u�W�F�N�g�v�[���𐶐�
        _effectPool = new EffectPool(_hierarchyTransform, _effectPrefab);
        Debug.Log("�v�[���쐬");

        //�j�����ꂽ�Ƃ���Pool���������
        this.OnDestroyAsObservable().Subscribe(_ => _effectPool.Dispose());

        //Bullet�v���n�u��Destroy������Effect�v���n�u�𐶐�
        _bulletPrefab.OnDestroyAsObservable()
            .Subscribe(_ =>
            {
                //Destroy�����ꏊ
                var position = this.transform.position;

                //pool����1�擾
                var effect = _effectPool.Rent();

                //�G�t�F�N�g���Đ����A�Đ��I��������pool�ɕԋp����
                effect.PlayEffect(position)
                .Subscribe(__ =>
                {
                    _effectPool.Return(effect);
                });
            });
    }
}
