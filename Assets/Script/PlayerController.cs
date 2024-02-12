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
	    Vector2 inputDir = value.Get<Vector2>();  // 입력받은 Vector2 값 가져오기
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
	}
	void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // 게임오브젝트에 있는 rigidbody 찾아서 넣음
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
        gameObject.SetActive(false);  // 게임오브젝트 비활성화

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
