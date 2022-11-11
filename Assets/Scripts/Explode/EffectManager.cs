using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;


public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField]
    private ExplosionEffect _effectPrefab;

    [SerializeField]
    private Transform _hierarchyTransform;

    private EffectPool _effectPool;

    void Start()
    {
        //�I�u�W�F�N�g�v�[���𐶐�
        _effectPool = new EffectPool(_hierarchyTransform, _effectPrefab);

        //�j�����ꂽ�Ƃ���Pool���������
        this.OnDestroyAsObservable().Subscribe(_ => _effectPool.Dispose());

        //�{�^���������ꂽ��G�t�F�N�g����
        _button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                //�����_���ȏꏊ
                var position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

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
