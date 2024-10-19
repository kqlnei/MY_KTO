using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject player1Model;   // �v���C���[1���f��
    public GameObject player2Model;   // �v���C���[2���f��

    private Collider player1Collider;
    private Collider player2Collider;


    // �����̏Փ˂����I�u�W�F�N�g��ێ����邽�߂̃��X�g
    public List<Collider> hitCollidersList { get; private set; } = new List<Collider>();


    // Start is called before the first frame update
    void Start()
    {
        if (player1Model != null)
        {
            player1Collider = player1Model.GetComponent<Collider>();
        }
        if (player2Model != null)
        {
            player2Collider = player2Model.GetComponent<Collider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Collider != null)
        {
            CheckCollisions(player1Collider, "Player");
        }
        if (player2Collider != null)
        {
            CheckCollisions(player2Collider, "Player 2");
        }
    }

    // �Փ˂��m�F���郁�\�b�h
    private void CheckCollisions(Collider playerCollider, string playerName)
    {
        // �O��̏Փ˃��X�g���N���A
        hitCollidersList.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(playerCollider.transform.position, playerCollider.bounds.extents.magnitude);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider != playerCollider)
            {
                Debug.Log(playerName + " collided with " + hitCollider.gameObject.name);
                hitCollidersList.Add(hitCollider);  // �Փ˂����I�u�W�F�N�g�����X�g�ɒǉ�
            }
        }
    }
}
