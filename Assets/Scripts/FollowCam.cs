using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform player;
    [Range(0.1f, 100f)]
    [SerializeField] float rotationSpeed = 0.1f;
    [Range(0, 360)]
    [SerializeField] float rotationAngle = 0;

    Vector3 offset;                                 //�������� ������ ������������ ������� ������

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.position;
    }

    public void follow()
    {
        transform.position = RotatePointAroundPivot(player.position + offset, player.position, rotationAngle);
        transform.LookAt(player.position);
    }

    public void rotate(float delta)                 //����� ��������� ���� �������� ������
    {
        rotationAngle += delta * rotationSpeed * Time.deltaTime;
    }

    public Vector3 getDirection(Vector3 dir)        //����� �������������� ������� ����������� � ������� ��������� ������
    {
        return transform.TransformDirection(dir);
    }


    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, float angle)    //����� ���������� �������� ����� ������ ������
    {
        return Quaternion.Euler(0, angle, 0) * (point - pivot) + pivot;
    }
}
