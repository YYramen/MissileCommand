using UniRx.Toolkit;
using UnityEngine;


/// <summary>
/// ExplosionEffectのPool
/// </summary>
public class EffectPool : ObjectPool<ExplosionEffect>
{
    private readonly ExplosionEffect _prefab;
    private readonly Transform _parenTransform;

    //コンストラクタ
    public EffectPool(Transform parenTransform, ExplosionEffect prefab)
    {
        _parenTransform = parenTransform;
        _prefab = prefab;
    }

    /// <summary>
    /// オブジェクトの追加生成時に実行される
    /// </summary>
    protected override ExplosionEffect CreateInstance()
    {
        //新しく生成
        var e = GameObject.Instantiate(_prefab);

        //ヒエラルキーが散らからないように一箇所にまとめる
        e.transform.SetParent(_parenTransform);

        return e;
    }
}
