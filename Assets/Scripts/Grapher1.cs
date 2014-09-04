using UnityEngine;
using System;
using UnityEditor;

public class Grapher1 : MonoBehaviour {

	public int resolution = 10;

	private int currentResolution;
	private ParticleSystem.Particle[] points;


	void Start() {
		CreatePoints ();
	}


	// Use this for initialization
	private void CreatePoints () {
		if (resolution < 10 || resolution > 100) {
			Debug.LogWarning ("Grapher resoulution out of bounds,resetting to minimum. ", this);
			resolution = 10;
		}
		currentResolution = resolution;
		points = new ParticleSystem.Particle[resolution];
		float increment = 1f / (resolution - 1);
		for (int i = 0; i < resolution; i++) {
			float x = i * increment;
			points [i].position = new Vector3 (x, 0f, 0f);
			points [i].color = new Color (x, 0f, 0f);
			points [i].size = 0.1f;
		}
	}
	
	void Update () {

		if (currentResolution != resolution) {
			CreatePoints ();
		}

		particleSystem.SetParticles (points, points.Length);
	}
}
