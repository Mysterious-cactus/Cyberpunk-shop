using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // ���������������� ����� �� ���� ����
    [SerializeField] private float sensitivityX = 1.0f, sensitivityY = 1.0f;

    // ����������� � ������������ �������� �� ��� X
    [SerializeField] private float minX = -90.0f, maxX = 90.0f;

    // ����� ��������
    private enum Options { X, Y, XandY }

    // ��������� ����� ��������
    [SerializeField] private Options options;

    // ������� �������
    private Quaternion targetRot;

    void Start()
    {
        // ��������� ������� �������
        targetRot = transform.rotation;
    }

    void Update()
    {
        // �������� �������� �������� ���� � �������� �� ���������������� ��������
        float rotY = Input.GetAxis("Mouse X") * sensitivityX;
        float rotX = Input.GetAxis("Mouse Y") * sensitivityY;

        // ���������� ����������� ��� ��������
        if (options == Options.X)
            // ������������� ������� ������� �� ����������� ����
            targetRot *= Quaternion.Euler(-rotX, 0.0f, 0.0f);
        else if (options == Options.Y)
            targetRot *= Quaternion.Euler(0.0f, rotY, 0.0f);
        else if (options == Options.XandY)
            targetRot *= Quaternion.Euler(-rotX, rotY, 0.0f);

        // ������������ ������
        transform.localRotation = targetRot;
    }
}
