using System;
using UniRx;
using UnityEngine;

namespace Samples
{
    /// <summary>
    /// �G�t�F�N�g���Đ����Ĉ�莞�Ԍ�ɒʒm����
    /// </summary>
    public class ExplodionEffect : MonoBehaviour
    {
        private EffectEmitter _effectEmitter;
        private EffectEmitter Emitter
        {
            get
            {
                //�x���������ɕύX
                return _effectEmitter ?? (_effectEmitter = GetComponent<EffectEmitter>());
            }
        }

        /// <summary>
        /// �G�t�F�N�g���Đ�����
        /// </summary>
        /// <param name="position">�Đ�������W</param>
        /// <returns>�Đ��I���ʒm</returns>
        public IObservable<Unit> PlayEffect(Vector3 position)
        {
            transform.position = position;

            //�G�t�F�N�g���Đ�
            Emitter.Play();

            //1�b��ɃG�t�F�N�g���~�߂ďI���ʒm
            return Observable.Timer(TimeSpan.FromSeconds(1.0f))
                .ForEachAsync(_ => Emitter.Stop());
        }
    }
}