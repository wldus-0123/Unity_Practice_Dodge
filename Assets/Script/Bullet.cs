using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        // ������ٵ��� �ӵ� = ���ʹ���(Z��) * �̵��ӵ�
        bulletRigidbody.velocity = transform.forward * speed;

        // 3�� �ڿ� ���ӿ�����Ʈ �ı�
        Destroy(gameObject, 2.5f);
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
        {
            // �÷��̾� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null )
            {
                // �÷��̾��� PlayerController ������Ʈ�� Die() ����
                playerController.Die();
            }
        }
	}
}
