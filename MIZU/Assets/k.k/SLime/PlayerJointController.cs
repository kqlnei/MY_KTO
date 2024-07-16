using UnityEngine;
using System;
using System.Collections;

public class PlayerJointController : MonoBehaviour
{
    private CharacterJoint characterJoint;
    public static event Action<bool> OnConnectionStateChanged;

    // �ڑ���̃N�[���_�E�����ԁi�b�j
    public float cooldownTime = 3f;
    private bool canConnect = true;

    void OnCollisionEnter(Collision collision)
    {
        if (canConnect && collision.gameObject.CompareTag("Arm"))
        {
            Rigidbody armRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (armRigidbody != null)
            {
                ConnectJoint(armRigidbody);
            }
            else
            {
                Debug.LogWarning("Arm �I�u�W�F�N�g�� Rigidbody ������܂���B");
            }
        }
    }

    private void ConnectJoint(Rigidbody connectedBody)
    {
        characterJoint = gameObject.AddComponent<CharacterJoint>();
        characterJoint.connectedBody = connectedBody;
        OnConnectionStateChanged?.Invoke(true);
        Debug.Log("�v���C���[�� Arm �I�u�W�F�N�g���W���C���g�Őڑ�����܂����B");
        StartCoroutine(DisconnectAfterDelay());
        StartCoroutine(CooldownTimer());
    }

    private IEnumerator DisconnectAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(characterJoint);
        OnConnectionStateChanged?.Invoke(false);
        Debug.Log("CharacterJoint���폜����܂���");
    }

    private IEnumerator CooldownTimer()
    {
        canConnect = false;
        yield return new WaitForSeconds(cooldownTime);
        canConnect = true;
        Debug.Log("�ڑ��\�ɂȂ�܂���");
    }
}