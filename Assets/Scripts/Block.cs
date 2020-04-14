using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	const string BREAKABLE = "Breakable";

	[SerializeField] AudioClip destroySound;
	[SerializeField] GameObject destroyVFXPrefab;
	[SerializeField] int timesHit; // TODO serialized for debug purposes
	[SerializeField] Sprite[] hitSprites;

	Level level;
	GameSession gameSession;

	private void Start()
	{
		gameSession = FindObjectOfType<GameSession>();
		level = FindObjectOfType<Level>();
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks()
	{
		if (tag == BREAKABLE)
		{
			level.CountBlocks();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (tag == BREAKABLE)
		{
			RegisterHit();
		}
	}

	private void RegisterHit()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits)
		{
			DestroyBlock();
		}
		else 
		{
			ShowNextHitSprite();
		}
	}

	private void DestroyBlock()
	{
		level.BlockDestroyed();
		gameSession.AddToScore();
		AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
		Destroy(gameObject);
		TriggerDestroyVFX();
	}

	private void TriggerDestroyVFX()
	{
		GameObject destroyVFX = Instantiate(destroyVFXPrefab, transform.position, transform.rotation);
		Destroy(destroyVFX, 1f);
	}

	private void ShowNextHitSprite()
	{
		Sprite nextHitSprite = hitSprites[timesHit - 1];
		if (nextHitSprite != null)
		{
			GetComponent<SpriteRenderer>().sprite = nextHitSprite;
		}
		else
		{
			Debug.LogError("Block sprite is missing from array in " + gameObject.name);
		}
	}
}