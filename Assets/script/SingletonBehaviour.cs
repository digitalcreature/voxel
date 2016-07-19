using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T> {

	static T _instance;
	public static T instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<T>();
				if (_instance == null) {
					Debug.LogError(string.Format("No {0} present in scene!", typeof(T).Name));
				}
			}
			return _instance;
		}
	}

}
