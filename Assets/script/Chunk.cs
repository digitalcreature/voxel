using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour {

	public BlockType fillType;
	public float fillPercent = 0.5f;

	//references to block instances
	Block[,,] blocks;
	//references to types of block instances
	BlockType[,,] blockTypes;

	//easy access to global chunk size
	public static int size { get { return ChunkManager.instance.chunkSize; } }

	//chunk terrain offset in world space
	public Vector3 offset { get { return transform.position; } set { transform.position = value; } }

	//called when chunk instance is allocated from pool
	public void Activate() {
		gameObject.SetActive(true);
	}

	//called when chunk instance is deallocated and returned to pool
	public void Deactivate() {
		gameObject.SetActive(false);
	}

	//chunk instantiation
	void Awake() {
		blocks = new Block[size, size, size];
		blockTypes = new BlockType[size, size, size];
		for (int i = 0; i < size; i ++) {
			for (int j = 0; j < size; j ++) {
				for (int k = 0; k < size; k ++) {
					Block block = new GameObject(string.Format("block [{0}, {1}, {2}]", i, j, k)).AddComponent<Block>();
					block.transform.parent = transform;
					block.transform.localPosition = new Vector3(
						(float) i - (size / 2f),
						(float) j - (size / 2f),
						(float) k - (size / 2f)
					);
					blocks[i, j, k] = block;
					block.type = null;
					blockTypes[i, j, k] = null;
				}
			}
		}
	}

	//set the type of one block
	public void SetBlockType(int i, int j, int k, BlockType type) {
		blocks[i, j, k].type = type;
		blockTypes[i, j, k] = type;
	}

	//set the types of all blocks at once
	public void SetBlockTypes(BlockType[,,] types) {
		for (int i = 0; i < size; i ++) {
			for (int j = 0; j < size; j ++) {
				for (int k = 0; k < size; k ++) {
					blocks[i, j, k].type = types[i, j, k];
					blockTypes[i, j, k] = types[i, j, k];
				}
			}
		}
	}

}
