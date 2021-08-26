using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBehaviour : MonoBehaviour{
	Transform pos;
	SpriteRenderer spr;
	CollisionColliderBehaviour ccb;
	Vector2 position;
	Transform cam;
	Tilemap collisionTile;

	bool useTemp = false;

	public int timeStamp;

	public Sprite[] topRotation;
	public Sprite[] rightRotation;
	public Sprite[] bottomRotation;
	public Sprite[] leftRotation;
	int curRot;
	//0 - top
	//1 - right
	//2 - bottom
	//3 - left

	Vector3 savedPos;
	Vector3 targetPos;
	float hor = 0;
	float ver = 0;
	int curTime = 0;
	bool eventTemp = false;

	void Start(){
		cam = Reference.instance.cam;
		collisionTile = Reference.instance.collisionTile;
		position = new Vector2(0,0);
		savedPos = new Vector3(0,0,0);
		targetPos = new Vector3(0,0,0);
		pos = GetComponent<Transform>();
		spr = GetComponent<SpriteRenderer>();
		ccb = GetComponent<CollisionColliderBehaviour>();
	}

	void FixedUpdate(){
		//Debug.Log(EventSystem.instance);
		//set de la position
		float tempX = pos.position.x;
		if(tempX < 0){tempX = (float)(int)(tempX-1);}
		float tempY = pos.position.y;
		if(tempY < 0){tempY = (float)(int)(tempY-1);}

		position = new Vector2((int)tempX,(int)tempY);
		// Debug.Log(((int)tempX).ToString()+" - "+((int)tempY).ToString());

		//update la pos de la cam
		cam.position = new Vector3(pos.position.x,pos.position.y,cam.position.z);

		//principe de mouvement
		hor = 0;
		if(Input.GetKey("q")){hor -=1;}
		if(Input.GetKey("d")){hor +=1;}
		ver = 0;
		if(Input.GetKey("s")){ver -=1;}
		if(Input.GetKey("z")){ver +=1;}

		

		if((hor != 0 || ver != 0) && curTime == 0){
			if(!(hor != 0 && ver != 0)){
				eventTemp = true;
				if(hor == -1){curRot = 3;}
				if(hor == 1){curRot = 1;}

				if(ver == 1){curRot = 0;}
				if(ver == -1){curRot = 2;}

				//transmition a gamemaster
				tempX = pos.position.x;
				if(tempX < 0){tempX = (float)(int)(tempX-1);}
				tempY = pos.position.y;
				if(tempY < 0){tempY = (float)(int)(tempY-1);}

				//faire le mouvement

				curTime ++;
				savedPos = new Vector3(pos.position.x,pos.position.y,0);
				targetPos = new Vector3(pos.position.x + hor,pos.position.y + ver,0);
				if(collisionTile.HasTile(new Vector3Int((int)(position.x+hor),(int)(position.y+ver),0))){targetPos = savedPos;};
				if(ccb.IsColliding((int)hor,(int)ver)){targetPos = savedPos;};
			}
		}

		if(curTime <= (timeStamp+5) && curTime >0){
			switch(curRot){
				case 0:
					spr.sprite = topRotation[(int)((float)curTime/(float)(timeStamp+1)*(float)topRotation.Length)];
				break;	
				case 1:
					spr.sprite = rightRotation[(int)((float)curTime/(float)(timeStamp+1)*(float)rightRotation.Length)];
				break;
				case 2:
					spr.sprite = bottomRotation[(int)((float)curTime/(float)(timeStamp+1)*(float)bottomRotation.Length)];
				break;
				case 3:
					spr.sprite = leftRotation[(int)((float)curTime/(float)(timeStamp+1)*(float)leftRotation.Length)];
				break;
			}
			pos.position = Vector3.Lerp(savedPos, targetPos, (float)curTime/(float)timeStamp);
		}
		if(curTime >0){
			curTime = (curTime+1)%(timeStamp+1);
		}else if(eventTemp){
			eventTemp = false;
			tempX = pos.position.x;
			if(tempX < 0){tempX = (float)(int)(tempX-1);}
			tempY = pos.position.y;
			if(tempY < 0){tempY = (float)(int)(tempY-1);}
			Data curDt = new Data((int)(tempX),(int)(tempY),curRot,Input.GetKey("space"));
			EventSystem.instance.SendEvent(curDt);
		}

		//executer le sys d'vent si touche de use change
		if(useTemp != Input.GetKey("space")){
			useTemp = Input.GetKey("space");

			tempX = pos.position.x;
			if(tempX < 0){tempX = (float)(int)(tempX-1);}
			tempY = pos.position.y;
			if(tempY < 0){tempY = (float)(int)(tempY-1);}
			Data curDt = new Data((int)tempX,(int)tempY,curRot,Input.GetKey("space"));
			EventSystem.instance.SendEvent(curDt);
		}
	}
}
