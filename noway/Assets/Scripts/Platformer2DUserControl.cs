using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Prangles._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }
        
        private void FixedUpdate()
        {
            // Read the inputs.
            bool restart = Input.GetKey("r");
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, restart);
        }
    }
}
