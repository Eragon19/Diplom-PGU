using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialTriggerActivator : MonoBehaviour
{
    public GameObject[] objects; // Массив объектов в порядке их активации
    private int currentIndex = 0; // Индекс текущего объекта

    void Start()
    {
        // Убеждаемся, что у всех объектов триггеры выключены, кроме первого
        for (int i = 0; i < objects.Length; i++)
        {
            Collider collider = objects[i].GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = (i == 0); // Включаем триггер только у первого
            }
        }

        // Запускаем проверку на отключение объектов
        StartCoroutine(CheckObjectsStatus());
    }

    IEnumerator CheckObjectsStatus()
    {
        while (currentIndex < objects.Length - 1)
        {
            // Ждем, пока текущий объект отключится
            while (objects[currentIndex].activeSelf)
            {
                yield return null; // Ждем следующий кадр
            }

            // Увеличиваем индекс и включаем триггер у следующего объекта
            currentIndex++;
            Collider nextCollider = objects[currentIndex].GetComponent<Collider>();
            if (nextCollider != null)
            {
                nextCollider.isTrigger = true;
            }
        }
    }
}
