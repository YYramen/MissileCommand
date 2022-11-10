using UniRx.Toolkit;
using UnityEngine;

namespace Samples
{
    /// <summary>
    /// ExplosionEffect��Pool
    /// </summary>
    public class EffectPool : ObjectPool<ExplodionEffect>
    {
        private readonly ExplodionEffect _prefab;
        private readonly Transform _parenTransform;

        //�R���X�g���N�^
        public EffectPool(Transform parenTransform, ExplodionEffect prefab)
        {
            _parenTransform = parenTransform;
            _prefab = prefab;
        }

        /// <summary>
        /// �I�u�W�F�N�g�̒ǉ��������Ɏ��s�����
        /// </summary>
        protected override ExplodionEffect CreateInstance()
        {
            //�V��������
            var e = GameObject.Instantiate(_prefab);

            //�q�G�����L�[���U�炩��Ȃ��悤�Ɉ�ӏ��ɂ܂Ƃ߂�
            e.transform.SetParent(_parenTransform);

            return e;
        }
    }
}