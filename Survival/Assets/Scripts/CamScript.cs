using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    private Vector2 mousePos;
    private float speed = 10f;
    private bool freeCam;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject camPoint;
    [SerializeField]
    private GameObject Player;

	void Start () {
        freeCam = false;
        camPoint.transform.position = cam.transform.position;
        cam.transform.parent = Player.transform;
	}
	
	void FixedUpdate () {
        mousePos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Y))
            if (freeCam)
            {
                freeCam = false;
                cam.transform.position = Vector3.Lerp(cam.transform.position, camPoint.transform.position, Time.deltaTime * speed);
                cam.transform.parent = Player.transform;
            }
            else
            {
                freeCam = true;
                cam.transform.parent = null;
            }

        if (freeCam)
        {
            if (mousePos.x > Screen.width)
                cam.transform.position = new Vector3((Time.deltaTime * speed) + cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            if (mousePos.x <= 0)
                cam.transform.position = new Vector3((-Time.deltaTime * speed) + cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            if (mousePos.y > Screen.height)
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, (Time.deltaTime * speed) + cam.transform.position.z);
            if (mousePos.y <= 0)
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, (-Time.deltaTime * speed) + cam.transform.position.z);
        }
        else
            cam.transform.position = Vector3.Lerp(cam.transform.position, camPoint.transform.position, Time.deltaTime * speed);
    }
}
