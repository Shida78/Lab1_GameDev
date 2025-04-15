using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    [Range(1, 300)]
    public float speed = 100;
    public bool clockwise = true;   //�� ������� ������� ��������

    Rigidbody rb;
    Vector3 m_EulerAngleVelocity;   //���������� ��� �������� �������� �������� � ���� �������� ������ �Z

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation;

        if (clockwise)              //���� �������� �� �������, �� ���������� �������� � ���� �����������
            deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime * -1);
        else                        //������ �������
            deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);

        rb.MoveRotation(rb.rotation * deltaRotation);   //���������� �������� � ��� ����
    }
}
