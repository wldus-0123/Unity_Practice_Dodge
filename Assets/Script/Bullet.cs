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

        // 리지드바디의 속도 = 앞쪽방향(Z축) * 이동속도
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤에 게임오브젝트 파괴
        Destroy(gameObject, 2.5f);
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
        {
            // 플레이어 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null )
            {
                // 플레이어의 PlayerController 컴포넌트의 Die() 실행
                playerController.Die();
            }
        }
	}
}
