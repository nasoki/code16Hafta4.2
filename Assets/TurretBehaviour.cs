using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public GameObject weaponBase;
    public GameObject weaponHead;
    public GameObject tank;
    Vector2 weaponRotation;
    float speedMultiplier = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        weaponRotation.x += Input.GetAxis("Mouse X");
        weaponRotation.y -= Input.GetAxis("Mouse Y");
        weaponRotation.y = Mathf.Clamp(weaponRotation.y, -20, 10);
        weaponBase.transform.rotation = Quaternion.Euler(0, weaponRotation.x, 0);
        weaponHead.transform.rotation = Quaternion.Euler(weaponRotation.y, weaponRotation.x, 0);
        tank.transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        Vector3 playerForward = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        Vector3 hiz = playerForward * Time.deltaTime * speedMultiplier;
        transform.Translate(hiz);
        //todo - ileri hareket, hedef alma, tagli objeleri yok etme
        //tank.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, Input.GetAxis("Horizontal") + 100, 0);
    }
}
