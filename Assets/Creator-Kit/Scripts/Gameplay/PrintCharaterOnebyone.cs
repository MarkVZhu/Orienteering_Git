
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintCharaterOnebyone : MonoBehaviour
{

    public float charsPerSecond = 0.2f;//����ʱ����
    private string words;//������Ҫ��ʾ������

    private bool isActive = false;
    private float timer;//��ʱ��
    private Text myText;
    private int currentPos = 0;//��ǰ����λ��


    private float lastTime;   //˯��ʱ��
    private float curTime;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<Text>();
        words = myText.text;
        myText.text = "";//��ȡText���ı���Ϣ�����浽words�У�Ȼ��̬�����ı���ʾ���ݣ�ʵ�ִ��ֻ���Ч��
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        curTime = Time.time;
        if (curTime - lastTime >= 4) {  // ͣ��һ��ʱ���Ķ���һ������

            OnStartWriter();
        //Debug.Log (isActive);
    }
}

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// ִ�д�������
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//�жϼ�ʱ��ʱ���Ƿ񵽴�
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//ˢ���ı���ʾ����

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// �������֣���ʼ������
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
    }




}
