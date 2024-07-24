using UnityEngine;
using UnityEngine.InputSystem;

public class MolInput : MonoBehaviour
{
    private void Update()
    {
        // 現在のキーボード情報
        var current = Keyboard.current;

        // キーボード接続チェック
        if (current == null)
        {
            return;
        }

        // キーの入力状態取得
        var aKey = current.aKey;
        var sKey = current.sKey;
        var dKey = current.dKey;
        var wKey = current.wKey;

        // Aキーが押された瞬間かどうか
        if (aKey.wasPressedThisFrame)
        {
            Debug.Log("Aキーが押された！");
            if (transform.position.x > -2)
                transform.position += new Vector3(-1, 0, 0);
        }

        if (sKey.wasPressedThisFrame)
        {
            Debug.Log("Sキーが押された！");
            if (transform.position.y > -2)
                transform.position += new Vector3(0, -1, 0);
        }

        if (dKey.wasPressedThisFrame)
        {
            Debug.Log("Dキーが押された！");
            if (transform.position.x < 2)
                transform.position += new Vector3(1, 0, 0);
        }

        if (wKey.wasPressedThisFrame)
        {
            Debug.Log("Wキーが押された！");
            if (transform.position.y < 2)
                transform.position += new Vector3(0, 1, 0);
        }
    }
}
