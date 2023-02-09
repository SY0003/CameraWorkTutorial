using Cinemachine;
using UnityEngine;

public class TestDollyCameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private float deltaValue = 20f;
    [SerializeField] private float maxValue = 10;
    [SerializeField] private float minValue = 2;

    [SerializeField] private KeyCode dollyInKey;
    [SerializeField] private KeyCode dollyOutKey;
    [SerializeField] private KeyCode resetKey;

    private CinemachineFramingTransposer cinemachineFramingTransposer;
    private float initialCameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        this.cinemachineFramingTransposer = this.cinemachineVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFramingTransposer;
        this.initialCameraDistance = this.cinemachineFramingTransposer.m_CameraDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.dollyInKey))
        {
            this.cinemachineFramingTransposer.m_CameraDistance = Mathf.Clamp(this.cinemachineFramingTransposer.m_CameraDistance - this.deltaValue * Time.deltaTime, this.minValue, this.maxValue);
        }

        if (Input.GetKey(this.dollyOutKey))
        {
            this.cinemachineFramingTransposer.m_CameraDistance = Mathf.Clamp(this.cinemachineFramingTransposer.m_CameraDistance + this.deltaValue * Time.deltaTime, this.minValue, this.maxValue);
        }

        if (Input.GetKeyDown(this.resetKey))
        {
            this.cinemachineFramingTransposer.m_CameraDistance = this.initialCameraDistance;
        }
    }
}