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
        //オブジェクトプールを生成
        _effectPool = new EffectPool(_hierarchyTransform, _effectPrefab);

        //破棄されたときにPoolを解放する
        this.OnDestroyAsObservable().Subscribe(_ => _effectPool.Dispose());

        //ボタンが押されたらエフェクト生成
        _button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                //ランダムな場所
                var position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                //poolから1つ取得
                var effect = _effectPool.Rent();

                //エフェクトを再生し、再生終了したらpoolに返却する
                effect.PlayEffect(position)
                .Subscribe(__ =>
                {
                    _effectPool.Return(effect);
                });
            });
    }
}
