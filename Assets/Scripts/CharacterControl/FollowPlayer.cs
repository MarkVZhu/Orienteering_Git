using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

	private Transform player;
	private float speed = 5f;
	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	// Update is called once per frame
	void Update()
	{
		// �����������λ��
		Vector3 targetPos = player.position + new Vector3(0, 3f, -10f);
		// ͨ����ֵ����ı������λ��
		transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
		// ʹ�����һֱ����Player
		Quaternion targetRot = Quaternion.LookRotation(player.position - transform.position);
		// Slerp һ�����ڽǶȵĲ�ֵ����
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, speed * Time.deltaTime);
	}
}