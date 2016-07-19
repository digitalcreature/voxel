using UnityEngine;

public abstract class ChunkGenerator : MonoBehaviour {

	public abstract BlockType[,,] GenerateChunkData(Vector3 offset, int chunkSize);

}
