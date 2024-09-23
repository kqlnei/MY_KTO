using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameObject player1Model;   // player１モデル
    public GameObject player2Model;   // player２モデル

    KK_PlayerModelSwitcher playerMode; //呼ぶスクリプトにあだなつける

    [HideInInspector]  public string nowmodelTag;
    // Start is called before the first frame update
    void Start()
    { 
        GameObject obj = player1Model;
        playerMode = obj.GetComponent<KK_PlayerModelSwitcher>(); //付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        nowmodelTag = playerMode.currentModel.tag;
        Debug.Log(playerMode.currentModel.tag);
    }
}
