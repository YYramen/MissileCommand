using UniRx.Toolkit;
using UnityEngine;

namespace Samples
{
    /// <summary>
    /// ExplosionEffectのPool
    /// </summary>
    public class EffectPool : ObjectPool<ExplodionEffect>
    {
        private readonly ExplodionEffect _prefab;
        private readonly Transform _parenTransform;

        //コンストラクタ
        public EffectPool(Transform parenTransform, ExplodionEffect prefab)
        {
            _parenTransform = parenTransform;
            _prefab = prefab;
        }

        /// <summary>
        /// オブジェクトの追加生成時に実行される
        /// </summary>
        protected override ExplodionEffect CreateInstance()
        {
            //新しく生成
            var e = GameObject.Instantiate(_prefab);

            //ヒエラルキーが散らからないように一箇所にまとめる
            e.transform.SetParent(_parenTransform);

            return e;
        }
    }
}