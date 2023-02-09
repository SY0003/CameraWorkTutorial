using Cinemachine;
using UnityEngine;

public class TestZoomCameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private float deltaFov = 30f;
    [SerializeField] private float maxFov = 70f;
    [SerializeField] private float minFov = 5f;

    [SerializeField] private KeyCode zoomInKey;
    [SerializeField] private KeyCode zoomOutKey;
    [SerializeField] private KeyCode resetKey;

    private float initialFov;

    // Start is called before the first frame update
    void Start()
    {
        this.initialFov = this.cinemachineVirtualCamera.m_Lens.FieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.zoomInKey))
        {
            this.cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Clamp(this.cinemachineVirtualCamera.m_Lens.FieldOfView - this.deltaFov * Time.deltaTime, this.minFov, this.maxFov);
        }

        if (Input.GetKey(this.zoomOutKey))
        {
            this.cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Clamp(this.cinemachineVirtualCamera.m_Lens.FieldOfView + this.deltaFov * Time.deltaTime, this.minFov, this.maxFov);
        }

        if (Input.GetKeyDown(this.resetKey))
        {
            this.cinemachineVirtualCamera.m_Lens.FieldOfView = this.initialFov;
        }
    }
}