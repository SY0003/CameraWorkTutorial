using UnityEngine;

public class TestPanAndTiltCameraController : MonoBehaviour
{
    [SerializeField] CinemachineRecomposer cinemachineRecomposer;

    [SerializeField] private float rotateSpeed = 30f;

    [SerializeField] private KeyCode panRightKey;
    [SerializeField] private KeyCode panLeftKey;
    [SerializeField] private KeyCode tiltUpKey;
    [SerializeField] private KeyCode tiltDownKey;
    [SerializeField] private KeyCode resetKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.panRightKey))
        {
            this.cinemachineRecomposer.m_Pan = this.cinemachineRecomposer.m_Pan + this.rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(this.panLeftKey))
        {
            this.cinemachineRecomposer.m_Pan = this.cinemachineRecomposer.m_Pan - this.rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(this.tiltUpKey))
        {
            this.cinemachineRecomposer.m_Tilt = this.cinemachineRecomposer.m_Tilt - this.rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(this.tiltDownKey))
        {
            this.cinemachineRecomposer.m_Tilt = this.cinemachineRecomposer.m_Tilt + this.rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(this.resetKey))
        {
            this.cinemachineRecomposer.m_Pan = 0;
            this.cinemachineRecomposer.m_Tilt = 0;
        }
    }
}
