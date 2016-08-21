using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;

    public bool turn;
    public float turnTime;
    public float turnPeriod;
    public float turnCooldown;
    public float ratio;

	// Use this for initialization
	void Start () {
        turn = false;
        turnTime = -100000f;
	}
	// Update is called once per frame
    void Update()
    {
        if (Time.time > turnTime + turnCooldown && Input.GetKeyDown(KeyCode.Z))
        {
            turn = !turn;
            turnTime = Time.time;
        }
        if (isTurning())
        {
            Quaternion rotation = transform.rotation;
            Vector3 angle = rotation.eulerAngles;
            ratio = (Time.time - turnTime) / turnPeriod;
            if (turn)
            {
                angle.y = 180f * ratio;
            }
            else
            {
                angle.y = 180f * (1f - ratio);
            }
            rotation.eulerAngles = angle;
            transform.rotation = rotation;
        }
        else
        {

            Quaternion rotation = transform.rotation;
            Vector3 angle = rotation.eulerAngles;
            if (turn)
            {
                angle.y = 180;
            }
            else
            {
                angle.y = 0;
            }
            rotation.eulerAngles = angle;
            transform.rotation = rotation;
        }

    }
	void FixedUpdate () {
        Vector3 pos = transform.position;
		pos.x = Mathf.Lerp(pos.x, player.GetComponent<Player>().nowStage.transform.position.x, 0.1f);
        transform.position = pos;
	}
    public bool isTurning() {
        return Time.time < turnTime + turnPeriod;
    }
}
