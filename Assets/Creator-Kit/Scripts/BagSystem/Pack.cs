using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pack : MonoBehaviour
{
    //������Ʒ��List����
    public List<ItemEntity> items = null;
    //�����������
    public int maxItem = 32;

    // Use this for initialization
    void Start()
    {
        items = new List<ItemEntity>();
    }

    //ʰȡ��Ʒ
    public ObjectItem getItem(ObjectItem item)
    {
        //ʹ���м���ɵ�ʵ����
        ItemEntity itemEntity = ItemEntity.FillData(item);

        //�����Ʒ���ɺϲ�
        if (!itemEntity.IsCanAdd)
        {
            //�����п���
            if (items.Count < maxItem)
            {
                //�����Ʒ
                items.Add(itemEntity);
                item.count = 0;
            }
            else
            {
                //ʰȡʧ��
            }
        }
        else
        {
            //�ձ���ʱ��ֱ�����
            if (items.Count < 1)
            {
                items.Add(itemEntity);
                item.count = 0;
            }
            else
            {
                //�жϵ�ǰ�����ϲ���Ʒ
                foreach (ItemEntity currItem in items)
                {
                    //��ͬ��Ʒ���ҿɵ��ӣ��ҷ���δ��
                    if (currItem.ObjId.Equals(itemEntity.ObjId) && currItem.Count < currItem.MaxAdd)
                    {
                        //��������
                        currItem.Count = currItem.Count + itemEntity.Count;
                        //����������ӷ�Χ
                        if (currItem.Count - currItem.MaxAdd > 0)
                        {
                            //ʰȡ��Ʒ��ʣ���������
                            item.count = currItem.Count - currItem.MaxAdd;
                            itemEntity.Count = item.count;
                            //�����������Ϊ���ֵ
                            currItem.Count = currItem.MaxAdd;
                        }
                        else
                        {
                            // δ�����������ֵ��ʰȡ�ɹ�
                            item.count = 0;
                        }
                    }
                    else
                    {
                        //�����Ʒ����ͬ�࣬����������ģ�������һ������
                        continue;
                    }
                }
                //��Ʒ�������飬��ʣ���������ӡ�����ʣ�ಿ���޷�ʰȡ
                if (item.count > 0 && items.Count < maxItem)
                {
                    items.Add(itemEntity);
                    item.count = 0;
                }
            }
        }
        return item;
    }

    //��ʾ��Ʒ
    public void showPack()
    {
        string show = "��Ʒ��\n";
        int i = 0;
        foreach (ItemEntity currItem in items)
        {
            show += ++i + " [" + currItem.ObjName + "], ����: " + currItem.Count + "\n";
        }
        Debug.Log(show);
    }
}