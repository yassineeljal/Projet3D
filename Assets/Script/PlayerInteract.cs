    using UnityEngine;

    public class PlayerInteract : MonoBehaviour
    {
        private Camera cam;
        [SerializeField] private float distance = 3f;
        [SerializeField] private LayerMask mask;
        private InputManager inputManager;

        void Start()
        {
            cam = GetComponent<PlayerLook>().cam;
            inputManager = GetComponent<InputManager>();
        }

        public void ProcessInteract()
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance, mask))
            {
                WeaponPickup weapon = hit.transform.GetComponent<WeaponPickup>();
                if (weapon != null)
                {
                    weapon.Pickup(inputManager);
                }
            }
        }
    }