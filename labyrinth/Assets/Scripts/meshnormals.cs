using UnityEngine;
using System.Collections;

public class meshnormals : MonoBehaviour {
	void Start() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.RecalculateNormals();
	}
}