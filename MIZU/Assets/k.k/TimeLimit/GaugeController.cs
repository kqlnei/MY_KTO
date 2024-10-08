using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    // 体力ゲージ（表面の常に見える部分）
    [SerializeField] private GameObject _gauge;

    // 最大HP
    [SerializeField] private int _HP;
    // HP1あたりの幅
    private float _HP1;

    public GameObject Managerobject;
    ModeManager playerMode;
    CollisionManager _playerColObj;


    private bool isDead = false;

    public float water = 1;
    public float ice =1;
    public float cloud = 1;
    public float slime = 1;

    private HealArea _heal;
    
    void Start()
    {
        GameObject obj = Managerobject;
        playerMode = obj.GetComponent<ModeManager>(); //付いているスクリプトを取得
        _playerColObj = obj.GetComponent<CollisionManager>();

        _heal = GetComponent<HealArea>();
        
    }
    void Awake()
    {
        // スプライトの幅を最大HPで割ってHP1あたりの幅を”_HP1”に入れておく
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    // 攻撃力をそれぞれのボタンで設定
    public void BeInjured(float atacck)//attackのデフォ値0.1
    {
        float damege = 0;
        switch (playerMode.nowmodelTag)
        {
            case "Water":
                // 攻撃力と体力1あたりの幅の積が実際に体力ゲージから減らす幅
                damege = _HP1 * atacck * water;
                break;

            case "Ice":
                // 攻撃力と体力1あたりの幅の積が実際に体力ゲージから減らす幅
                damege = _HP1 * atacck * ice;
                break;
            
            case "Cloud":
                // 攻撃力と体力1あたりの幅の積が実際に体力ゲージから減らす幅
                damege = _HP1 * atacck * cloud;
                break;

            case "Slime":
                // 攻撃力と体力1あたりの幅の積が実際に体力ゲージから減らす幅
                damege = _HP1 * atacck * slime;
                break;
        }

        // 減らす幅を設定してコルーチン”damegeEm”を呼び出し
        StartCoroutine(damegeEm(damege));
    }
    public void Update()
    {
        if (!isDead) // 死亡していない場合のみ実行
        {
            foreach (Collider col in _playerColObj.hitCollidersList)
            {
                if (col.gameObject.CompareTag("HealSpot"))
                {
                    Heal(100f);
                    break; // 1つでも回復エリアに当たったらループを抜ける
                }
            }

            // 回復エリアに当たっていない場合
            BeInjured(0.1f);
            Debug.Log(playerMode.nowmodelTag + "1");
        }
        else
        {
            //死んだときの処理
        }
    }

    // 回復する
    public void Heal(float healAmount)
    {
        float heal = _HP1 * healAmount;  // 回復量を計算
        StartCoroutine(HealEm(heal));
    }

    // 体力ゲージを減らす
    IEnumerator damegeEm(float damege)
    {
        // 体力ゲージの幅と高さをVector2で取り出す(Width,Height)
        Vector2 nowsafes = _gauge.GetComponent<RectTransform>().sizeDelta;
        // 体力ゲージの幅からダメージ分の幅を引く
        nowsafes.x -= damege;

        // 体力ゲージの幅が0以下になったら、デバッグ表示
        if (nowsafes.x <= 0 && !isDead)
        {
            nowsafes.x = 0; // ゲージ幅を0に固定
            isDead = true; // 死亡状態を記録
            Debug.Log("Player is dead!");


        }
        // 体力ゲージに計算済みのVector2を設定する
        _gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;

        yield return null;
    }

    // 回復してゲージを増やす
    IEnumerator HealEm(float heal)
    {
        Vector2 currentSize = _gauge.GetComponent<RectTransform>().sizeDelta;
        currentSize.x += heal;

        // 最大幅を超えないように調整
        float maxWidth = _HP1 * _HP;
        if (currentSize.x > maxWidth)
        {
            currentSize.x = maxWidth;
        }

        _gauge.GetComponent<RectTransform>().sizeDelta = currentSize;

        yield return null;
    }
}