using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMenuMonoBehavior : MonoBehaviour
{
    public Ring Data;
    public RingCakePiece cakePiece;
    public float GapWidthDegree = 1f;
    public Action<String> callback;
    protected RingCakePiece[] piece;
    protected RingMenuMonoBehavior parent;
    [HideInInspector]
    public string Path;

    void Start()
    {
        var stepLength = 360f / Data.Elements.Length;
        var iconDist = Vector3.Distance(cakePiece.Icon.transform.position, cakePiece.CakePiece.transform.position);
        piece = new RingCakePiece[Data.Elements.Length];

        for (int i = 0; i < Data.Elements.Length; i++)
        {
            piece[i] = Instantiate(cakePiece, transform);

            piece[i].transform.localPosition = Vector3.zero;
            piece[i].transform.localRotation = Quaternion.identity;

            piece[i].CakePiece.fillAmount = 1f / Data.Elements.Length - GapWidthDegree / 360f;
            piece[i].CakePiece.transform.localPosition = Vector3.zero;
            piece[i].CakePiece.transform.localRotation = Quaternion.Euler(0, 0, -stepLength / 2f + GapWidthDegree / 2f + i * stepLength);
            piece[i].CakePiece.color = new Color(1f, 1f, 1f, 0.5f);

            piece[i].Icon.transform.localScale = piece[i].CakePiece.transform.localPosition + Quaternion.AngleAxis(i * stepLength, Vector3.forward) *Vector3.up *iconDist;
        }
    }
    private void Update()
    {
        var stepLength = 360f / Data.Elements.Length;
        var mouseAngle = NormalizeAngle(Vector3.SignedAngle(Vector3.up, Input.mousePosition - transform.position, Vector3.forward) + stepLength / 2f);
        var activeElement = (int)(mouseAngle / stepLength);
        for (int i = 0; i < Data.Elements.Length; i++)
        {
            if (i == activeElement)
                piece[i].CakePiece.color = new Color(1f, 1f, 1f, 0.75f);
            else
                piece[i].CakePiece.color = new Color(1f, 1f, 1f, 0.5f);
        }


        if (Input.GetMouseButtonDown(0))
        {
            var path = Path + "/" + Data.Elements[activeElement].Name;
            if (Data.Elements[activeElement].NextRing != null)
            {
                var newSubRing = Instantiate(gameObject, transform.parent).GetComponent<RingMenuMonoBehavior>();
                newSubRing.parent = this;
                for (var j = 0; j < newSubRing.transform.childCount; j++)
                    Destroy(newSubRing.transform.GetChild(j).gameObject);
                newSubRing.Data = Data.Elements[activeElement].NextRing;
                newSubRing.Path = path;
                newSubRing.callback = callback;
            }
            else
            {
                callback?.Invoke(path);
            }
            gameObject.SetActive(false);
        }
    }

    private float NormalizeAngle(float a) => (a + 360f) % 360f;
}
