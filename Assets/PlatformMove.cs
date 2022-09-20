using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove: MonoBehaviour
{
    private bool startCheck; 
    public int index = 0;             
    public float speed = 3.0f;                 
    public Transform[] theWayPoints;         
    // Start is called before the first frame update
    void Start()
    {
        startCheck = GameObject.Find("Capsule").GetComponent<PlatformStartMove>().startMove;
    }
    // Update is called once per frame
    void Update()
    {
        startCheck = GameObject.Find("Capsule").GetComponent<PlatformStartMove>().startMove;
        if (startCheck)
        {
            //If the specified index position is not reached, call MoveToThePoints to continue moving each frame
            if (transform.position != theWayPoints[index].position)
            {
                MoveToThePoints();
            }
            else
            {
                if (index == theWayPoints.Length - 1)
                    Destroy(this);
                index++;
            }
        }
        
    }
    void MoveToThePoints()
    {
        //�ӵ�ǰλ�ð���ָ���ٶ��Ƶ�indexλ�ã��ǵ�speed * Time.deltaTime����Ȼ��˲��
        Vector2 temp = Vector2.MoveTowards(transform.position, theWayPoints[index].position, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(temp);

    }
}

