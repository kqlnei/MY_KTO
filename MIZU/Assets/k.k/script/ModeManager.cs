using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameObject player1Model;   // player�P���f��
    public GameObject player2Model;   // player�Q���f��

    KK_PlayerModelSwitcher playerMode; //�ĂԃX�N���v�g�ɂ����Ȃ���

    [HideInInspector]  public string nowmodelTag;
    // Start is called before the first frame update
    void Start()
    { 
        GameObject obj = player1Model;
        playerMode = obj.GetComponent<KK_PlayerModelSwitcher>(); //�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        nowmodelTag = playerMode.currentModel.tag;
        Debug.Log(playerMode.currentModel.tag);
    }
}
