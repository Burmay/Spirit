using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    public virtual void OnCreate(){ } // ����� ��� �������

    public virtual void Initialize() { } // ����� ��� ������� OnCreate

    public virtual void OnStart() { } // ����� ��� �������������������
}
