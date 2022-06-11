using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class movDrag : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler{
	public static GameObject itemBeginDragged;
	Vector3 starPosition;
	Transform startParent;
	public Vector3 asd;
	#region IBeginDragHandler implementation
	
	void IBeginDragHandler.OnBeginDrag (PointerEventData eventData)
	{
		itemBeginDragged = gameObject;
		starPosition = transform.position;
		startParent = transform.parent;
		 GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	
	#endregion
	
	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)
	{	
		transform.position = Input.mousePosition;

	}
	
	#endregion
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeginDragged = null;
		
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if (transform.parent == startParent){
			transform.position = starPosition;
		}
	}
	
	#endregion

}
