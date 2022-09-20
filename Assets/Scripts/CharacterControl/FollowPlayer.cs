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
		// 定义摄像机的位置
		Vector3 targetPos = player.position + new Vector3(0, 3f, -10f);
		// 通过插值计算改变摄像机位置
		transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
		// 使摄像机一直看向Player
		Quaternion targetRot = Quaternion.LookRotation(player.position - transform.position);
		// Slerp 一般用于角度的插值计算
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, speed * Time.deltaTime);
	}
}