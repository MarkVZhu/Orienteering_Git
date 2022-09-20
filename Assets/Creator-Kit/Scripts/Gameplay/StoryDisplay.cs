using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//һ�����ص�����ȴ�t�����ʾ��updata��ʱ��ʵ��
public class StoryDisplay : MonoBehaviour
{

	public GameObject image;
	public int tshow=3;//չʾ�ȴ�ʱ��
	public int thide = 8;//���صȴ�ʱ��

	// Use this for initialization
	void Start()
	{
		image.SetActive(false);
		Invoke("ActiveShow", tshow);
		Invoke("HideShow", thide);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ActiveShow()
	{
		image.SetActive(true);
	}

	public void HideShow()
	{
		image.SetActive(false);
	}
}
