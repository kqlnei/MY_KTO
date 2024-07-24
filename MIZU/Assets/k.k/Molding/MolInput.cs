using UnityEngine;
using UnityEngine.InputSystem;

public class MolInput : MonoBehaviour
{
    private void Update()
    {
        // ���݂̃L�[�{�[�h���
        var current = Keyboard.current;

        // �L�[�{�[�h�ڑ��`�F�b�N
        if (current == null)
        {
            return;
        }

        // �L�[�̓��͏�Ԏ擾
        var aKey = current.aKey;
        var sKey = current.sKey;
        var dKey = current.dKey;
        var wKey = current.wKey;

        // A�L�[�������ꂽ�u�Ԃ��ǂ���
        if (aKey.wasPressedThisFrame)
        {
            Debug.Log("A�L�[�������ꂽ�I");
            if (transform.position.x > -2)
                transform.position += new Vector3(-1, 0, 0);
        }

        if (sKey.wasPressedThisFrame)
        {
            Debug.Log("S�L�[�������ꂽ�I");
            if (transform.position.y > -2)
                transform.position += new Vector3(0, -1, 0);
        }

        if (dKey.wasPressedThisFrame)
        {
            Debug.Log("D�L�[�������ꂽ�I");
            if (transform.position.x < 2)
                transform.position += new Vector3(1, 0, 0);
        }

        if (wKey.wasPressedThisFrame)
        {
            Debug.Log("W�L�[�������ꂽ�I");
            if (transform.position.y < 2)
                transform.position += new Vector3(0, 1, 0);
        }
    }
}
