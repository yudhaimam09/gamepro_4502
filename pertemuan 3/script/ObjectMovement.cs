using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    public int aksi;
    public float speed;
    Vector3 kekanan;
    Vector3 kekiri;
    Vector3 keatas;
    Vector3 kebawah;
    Vector3 maju;
    Vector3 mundur;
    // Start is called before the first frame update
    void Start() {
        maju = new Vector3(0,0,1);
        mundur = new Vector3(0,0,-1);
        kekanan = new Vector3(1,0,0);
        kekiri = new Vector3(-1,0,0);
        keatas = new Vector3(0,1,0);
        kebawah = new Vector3(0,-1,0);
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        switch(aksi){
            case 0:
                // translasi ke kanan
                TranslasiObjek(kekanan);
                break;
            case 1:
                // translasi ke kiri
                TranslasiObjek(kekiri);
                break;
            case 2:
                // translasi ke atas
                TranslasiObjek(keatas);
                break;
            case 3:
                // translasi ke bawah
                TranslasiObjek(kebawah);
                break;
            case 4:
                // translasi ke kanan
                transform.rotation = transform.rotation * toQuaternion(maju * speed * Time.deltaTime);
                break;
            case 5:
                // translasi ke kanan
                transform.rotation = transform.rotation * toQuaternion(mundur * speed * Time.deltaTime);
                break;
        }
    }
    static Quaternion toQuaternion(Vector3 euler){
        Quaternion q;
        float pitch = euler.y;
        float roll = euler.x;
        float yaw = euler.z;
        float t0 = Mathf.Cos(yaw * 0.5f);
        float t1 = Mathf.Sin(yaw * 0.5f);
        float t2 = Mathf.Cos(roll * 0.5f);
        float t3 = Mathf.Sin(roll * 0.5f);
        float t4 = Mathf.Cos(pitch * 0.5f);        
        float t5 = Mathf.Sin(pitch * 0.5f);
        q.x = t0 * t3 * t4 - t1 * t2 * t5;
        q.y = t0 * t2 * t5 + t1 * t3 * t4;
        q.z = t1 * t2 * t4 - t0 * t3 * t5;
        q.w = t0 * t2 * t4 + t1 * t3 * t5;
        return q;
    }
    void TranslasiObjek(Vector3 arah){
        transform.position = transform.position + (arah * speed * Time.deltaTime );
    }
}
