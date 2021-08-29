using UnityEngine;

public class TransformRandomzier: MonoBehaviour {

    public Vector3 scaleMin;
    public Vector3 scaleMax;

    public Vector3 rotation;
    public void Start() {
        float rotRand_x = Random.value;
        float rotRand_y = Random.value;
        float rotRand_z = Random.value;
        transform.rotation = Quaternion.Euler(new Vector3(rotation.x*rotRand_x,rotation.y*rotRand_y,rotation.z*rotRand_z));

        float scale_x = Random.Range(scaleMin.x, scaleMax.x);
        float scale_y = Random.Range(scaleMin.y, scaleMax.y);
        float scale_z = Random.Range(scaleMin.z, scaleMax.z);

        transform.localScale = new Vector3(scale_x, scale_y, scale_z);
    }
}
