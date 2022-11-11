using UniRx.Toolkit;
using UnityEngine;


/// <summary>
/// ExplosionEffect��Pool
/// </summary>
public class EffectPool : ObjectPool<ExplosionEffect>
{
    private readonly ExplosionEffect _prefab;
    private readonly Transform _parenTransform;

    //�R���X�g���N�^
    public EffectPool(Transform parenTransform, ExplosionEffect prefab)
    {
        _parenTransform = parenTransform;
        _prefab = prefab;
    }

    /// <summary>
    /// �I�u�W�F�N�g�̒ǉ��������Ɏ��s�����
    /// </summary>
    protected override ExplosionEffect CreateInstance()
    {
        //�V��������
        var e = GameObject.Instantiate(_prefab);

        //�q�G�����L�[���U�炩��Ȃ��悤�Ɉ�ӏ��ɂ܂Ƃ߂�
        e.transform.SetParent(_parenTransform);

        return e;
    }
}
