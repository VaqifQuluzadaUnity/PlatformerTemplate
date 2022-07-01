using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CharacterRotationController : MonoBehaviour
{
   [SerializeField] private CinemachineFreeLook characterCMcamera;

    // Update is called once per frame
    void Update()
    {
      Vector3 characterRotation = transform.rotation.eulerAngles;

      transform.rotation = Quaternion.Euler(characterRotation.x, characterCMcamera.m_XAxis.Value, characterRotation.z);
    }
}
