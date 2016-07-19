using UnityEngine;

public class Block : MonoBehaviour {

	BlockType _type;
	public BlockType type {
		get {
			return _type;
		}
		set {
			_type = value;
			if (value) {
				collide.enabled = value.isSolid;
				if (value.mesh) {
					filter.mesh = value.mesh;
					render.material = value.material;
					render.enabled = true;
				}
				else {
					render.material = null;
					render.enabled = false;
					filter.mesh = null;
				}
			}
			else {
				collide.enabled = false;
				render.material = null;
				render.enabled = false;
				filter.mesh = null;
			}
		}
	}

	BoxCollider collide;
	MeshFilter filter;
	MeshRenderer render;

	void Awake() {
		collide = gameObject.AddComponent<BoxCollider>();
		collide.size = Vector3.one;
		collide.center = Vector3.zero;
		filter = gameObject.AddComponent<MeshFilter>();
		render = gameObject.AddComponent<MeshRenderer>();
		type = null;
	}


}
