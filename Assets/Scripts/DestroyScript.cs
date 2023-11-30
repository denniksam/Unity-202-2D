using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.transform.parent?.gameObject != null)
        {
            GameObject.Destroy(   // ������� �������� ���������� ��'��� - �����
                other             // other - Collider2D (Box Collider)
                .gameObject       // gameObject - Square
                .transform        // ������ ��������� ����� transform
                .parent           // parent - �� ��� transform
                .gameObject       // gameObject - �� ���� ��
            );                    // 
        }
        else
        {
            GameObject.Destroy( other.gameObject );
        }
    }
}
