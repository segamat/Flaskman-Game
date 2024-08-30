using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "equation name", menuName = "bag/Create new equation")]
public class EquationCreate : ScriptableObject
{
    // ����ʽ��Ӧ��
    public string[] factor = new string[3];

    // ����ʽ��Ӧ����
    public bool beam; //����
    public bool heat; //���ȡ�����
    public bool electrolyze; // ���
    public bool nocondition; // �����ⷴӦ����

    // ����ʽ������
    public string[] product = new string[3];

    // �Ƿ�ʹ��
    public bool use;

    // �Ƿ�ѡ����ȷ������
    public bool condition;

    // �Ƿ���Ҫ��������ﵽ������
    public bool additem;
}
