using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    // �̗̓Q�[�W�i�\�ʂ̏�Ɍ����镔���j
    [SerializeField] private GameObject _gauge;
    // �P�\�Q�[�W�i�̗͂��������Ƃ���u�����镔���j
    [SerializeField] private GameObject _graceGauge;

    // �ő�HP
    [SerializeField] private int _HP;
    // HP1������̕�
    private float _HP1;
    // �̗̓Q�[�W���������㗠�Q�[�W������܂ł̑ҋ@����
    private float _waitingTime = 0.5f;

    public GameObject modeManager;
    ModeManager playerMode;
    void Start()
    {
        GameObject obj = modeManager;
        playerMode = obj.GetComponent<ModeManager>(); //�t���Ă���X�N���v�g���擾
    }
    void Awake()
    {
        // �X�v���C�g�̕����ő�HP�Ŋ�����HP1������̕����h_HP1�h�ɓ���Ă���
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    // �U���͂����ꂼ��̃{�^���Őݒ�
    public void BeInjured(float atacck)
    {
        // �U���͂Ƒ̗�1������̕��̐ς����ۂɑ̗̓Q�[�W���猸�炷��
        float damege = _HP1 * atacck;

        // ���炷����ݒ肵�ăR���[�`���hdamegeEm�h���Ăяo��
        StartCoroutine(damegeEm(damege));
    }
    public void Update()
    {
        BeInjured(0.1f);
        Debug.Log(playerMode.nowmodelTag +  "1");
    }

    // �̗̓Q�[�W�����炷�R���[�`��
    IEnumerator damegeEm(float damege)
    {
        // �̗̓Q�[�W�̕��ƍ�����Vector2�Ŏ��o��(Width,Height)
        Vector2 nowsafes = _gauge.GetComponent<RectTransform>().sizeDelta;
        // �̗̓Q�[�W�̕�����_���[�W���̕�������
        nowsafes.x -= damege;
        // �̗̓Q�[�W�Ɍv�Z�ς݂�Vector2��ݒ肷��
        _gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;

        // �h_waitingTime�h�b�҂�
        yield return new WaitForSeconds(_waitingTime);
        // �P�\�Q�[�W�Ɍv�Z�ς݂�Vector2��ݒ肷��
        _graceGauge.GetComponent<RectTransform>().sizeDelta = nowsafes;
    }
}