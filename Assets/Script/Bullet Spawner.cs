using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;   // ź�� ���� ������
    public float spawnRateMin = 0.5f; // �� ź�� �ּ� ���� �ֱ�
    public float spawnRateMax = 3f;   // �� ź�� �ִ� ���� �ֱ�

    private Transform target;         // �߻��� ����� ��ġ
    private float spawnRate;          // ź�� ���� �ֱ�
    private float timeAfterSpawn;     // �ֱ� ���� �������� ���� �ð�

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ź�� ���� ������ Min, Max ���̿��� ���� ����
        target = FindObjectOfType<PlayerController>().transform; // PlayerController ������Ʈ�� ���� ���ӿ�����Ʈ�� ��ġ = �߻���
    }

   
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;   // ������ �ð� ����

        if(timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f; // ���� �ð� ����

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // ź�� �������� ��ġ, ȸ�����⿡ ����
            bullet.transform.LookAt(target); // ������ target�� �ٶ󺸵��� ȸ����Ŵ
            spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        }
    }
}
