using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialTriggerActivator : MonoBehaviour
{
    public GameObject[] objects; // ������ �������� � ������� �� ���������
    private int currentIndex = 0; // ������ �������� �������

    void Start()
    {
        // ����������, ��� � ���� �������� �������� ���������, ����� �������
        for (int i = 0; i < objects.Length; i++)
        {
            Collider collider = objects[i].GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = (i == 0); // �������� ������� ������ � �������
            }
        }

        // ��������� �������� �� ���������� ��������
        StartCoroutine(CheckObjectsStatus());
    }

    IEnumerator CheckObjectsStatus()
    {
        while (currentIndex < objects.Length - 1)
        {
            // ����, ���� ������� ������ ����������
            while (objects[currentIndex].activeSelf)
            {
                yield return null; // ���� ��������� ����
            }

            // ����������� ������ � �������� ������� � ���������� �������
            currentIndex++;
            Collider nextCollider = objects[currentIndex].GetComponent<Collider>();
            if (nextCollider != null)
            {
                nextCollider.isTrigger = true;
            }
        }
    }
}
