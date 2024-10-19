using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    // �̗̓Q�[�W�i�\�ʂ̏�Ɍ����镔���j
    [SerializeField] private GameObject _gauge;

    // �ő�HP
    [SerializeField] private int _HP;
    // HP1������̕�
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
        playerMode = obj.GetComponent<ModeManager>(); //�t���Ă���X�N���v�g���擾
        _playerColObj = obj.GetComponent<CollisionManager>();

        _heal = GetComponent<HealArea>();
        
    }
    void Awake()
    {
        // �X�v���C�g�̕����ő�HP�Ŋ�����HP1������̕����h_HP1�h�ɓ���Ă���
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    // �U���͂����ꂼ��̃{�^���Őݒ�
    public void BeInjured(float atacck)//attack�̃f�t�H�l0.1
    {
        float damege = 0;
        switch (playerMode.nowmodelTag)
        {
            case "Water":
                // �U���͂Ƒ̗�1������̕��̐ς����ۂɑ̗̓Q�[�W���猸�炷��
                damege = _HP1 * atacck * water;
                break;

            case "Ice":
                // �U���͂Ƒ̗�1������̕��̐ς����ۂɑ̗̓Q�[�W���猸�炷��
                damege = _HP1 * atacck * ice;
                break;
            
            case "Cloud":
                // �U���͂Ƒ̗�1������̕��̐ς����ۂɑ̗̓Q�[�W���猸�炷��
                damege = _HP1 * atacck * cloud;
                break;

            case "Slime":
                // �U���͂Ƒ̗�1������̕��̐ς����ۂɑ̗̓Q�[�W���猸�炷��
                damege = _HP1 * atacck * slime;
                break;
        }

        // ���炷����ݒ肵�ăR���[�`���hdamegeEm�h���Ăяo��
        StartCoroutine(damegeEm(damege));
    }
    public void Update()
    {
        if (!isDead) // ���S���Ă��Ȃ��ꍇ�̂ݎ��s
        {
            foreach (Collider col in _playerColObj.hitCollidersList)
            {
                if (col.gameObject.CompareTag("HealSpot"))
                {
                    Heal(100f);
                    break; // 1�ł��񕜃G���A�ɓ��������烋�[�v�𔲂���
                }
            }

            // �񕜃G���A�ɓ������Ă��Ȃ��ꍇ
            BeInjured(0.1f);
            Debug.Log(playerMode.nowmodelTag + "1");
        }
        else
        {
            //���񂾂Ƃ��̏���
        }
    }

    // �񕜂���
    public void Heal(float healAmount)
    {
        float heal = _HP1 * healAmount;  // �񕜗ʂ��v�Z
        StartCoroutine(HealEm(heal));
    }

    // �̗̓Q�[�W�����炷
    IEnumerator damegeEm(float damege)
    {
        // �̗̓Q�[�W�̕��ƍ�����Vector2�Ŏ��o��(Width,Height)
        Vector2 nowsafes = _gauge.GetComponent<RectTransform>().sizeDelta;
        // �̗̓Q�[�W�̕�����_���[�W���̕�������
        nowsafes.x -= damege;

        // �̗̓Q�[�W�̕���0�ȉ��ɂȂ�����A�f�o�b�O�\��
        if (nowsafes.x <= 0 && !isDead)
        {
            nowsafes.x = 0; // �Q�[�W����0�ɌŒ�
            isDead = true; // ���S��Ԃ��L�^
            Debug.Log("Player is dead!");


        }
        // �̗̓Q�[�W�Ɍv�Z�ς݂�Vector2��ݒ肷��
        _gauge.GetComponent<RectTransform>().sizeDelta = nowsafes;

        yield return null;
    }

    // �񕜂��ăQ�[�W�𑝂₷
    IEnumerator HealEm(float heal)
    {
        Vector2 currentSize = _gauge.GetComponent<RectTransform>().sizeDelta;
        currentSize.x += heal;

        // �ő啝�𒴂��Ȃ��悤�ɒ���
        float maxWidth = _HP1 * _HP;
        if (currentSize.x > maxWidth)
        {
            currentSize.x = maxWidth;
        }

        _gauge.GetComponent<RectTransform>().sizeDelta = currentSize;

        yield return null;
    }
}