using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;   // 탄알 원본 프리팹
    public float spawnRateMin = 0.5f; // 새 탄알 최소 생성 주기
    public float spawnRateMax = 3f;   // 새 탄알 최대 생성 주기

    private Transform target;         // 발사할 대상의 위치
    private float spawnRate;          // 탄알 생성 주기
    private float timeAfterSpawn;     // 최근 생성 시점에서 지난 시간

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 탄알 생성 간격을 Min, Max 사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform; // PlayerController 컴포넌트를 가진 게임오브젝트의 위치 = 발사대상
    }

   
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;   // 지나간 시간 갱신

        if(timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f; // 누적 시간 리셋

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // 탄알 생성기의 위치, 회전방향에 생성
            bullet.transform.LookAt(target); // 정면이 target을 바라보도록 회전시킴
            spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        }
    }
}
