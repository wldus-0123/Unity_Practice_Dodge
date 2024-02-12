using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    Vector3 moveDir;
	private void OnMove(InputValue value)
	{
	    Vector2 inputDir = value.Get<Vector2>();  // �Է¹��� Vector2 �� ��������
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
	}
	void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // ���ӿ�����Ʈ�� �ִ� rigidbody ã�Ƽ� ����
    }

    
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(0,0,moveDir.z *  speed * Time.deltaTime, Space.Self);
        transform.Translate(moveDir.x * speed * Time.deltaTime,0,0, Space.Self);
    }
    public void Die()
    {
        gameObject.SetActive(false);  // ���ӿ�����Ʈ ��Ȱ��ȭ

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
