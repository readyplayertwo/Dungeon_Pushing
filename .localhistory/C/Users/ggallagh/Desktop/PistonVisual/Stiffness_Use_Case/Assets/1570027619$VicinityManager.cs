using System.Collections;
using UnityEngine;
using Ultrahaptics;
namespace ButtonSliderExample
{

    public class VicinityManager : MonoBehaviour
    {

        public Vector3 start = new Vector3(-12.326f, 0.51f, 9.475f);
        public Vector3 FirstEnd = new Vector3(-12.326f, 0.51f, 10.069f);



        public GameObject Cube;
        public GameObject SteamVrPlayArea;

        [SerializeField]

        public bool first = true;



        [SerializeField]
        public GameObject _pistonPresser;
        private GameObject _tempObject = null;
        public CustomEmitter CE;
        public startemitter SE;

        public bool FirstEndOfArea = false;


        public Inflate InflateScript;



        public GameObject Block;

        public float intensity;

        public float _minPressIntensity;
        public float _maxPressIntensity;
        public enum SWITCH_POSITION_E { DISABLED, READY, ACTUATING, CLICKED };
        public SWITCH_POSITION_E switchPos = SWITCH_POSITION_E.READY;

        public enum SWITCH_STATE_E { OFF = 0, ON = 1, UNSET };
        public SWITCH_STATE_E switchState = SWITCH_STATE_E.OFF;
        public float _pistonTravelDistance; // Distance between Piston top and bottom
        public float _buttonMaxYValue;
        public float _buttonMinYValue;
        public float _buttonPositionY;
        private float _buttonClickUpPosition;
        public float _offset = 0.026f;

        


        [SerializeField]

        // return intensity
        public float normalisedTravel;

        public void Start()
        {
            //Assign Objects


            _buttonMaxYValue = 10.069f;
            _buttonMinYValue = _buttonMaxYValue - _pistonTravelDistance;
            _buttonClickUpPosition = _buttonMinYValue + _pistonTravelDistance * 0.2f;
            _buttonPositionY = _buttonMaxYValue;
            _minPressIntensity = 0.5f;
            _maxPressIntensity = 0.5f;

        }

        void Update()

        {


            if (Block.transform.position = FirstEnd)
            {
                FirstEndOfArea = true;
                _minPressIntensity = 0.5f;
                _maxPressIntensity = 1.0f;
            }
            // if the hand is in the vicinity of the collider/buttopTop 
            // set the button top position to the colliding object else reset the position back to default

            if (FirstEndOfArea += true)
            {
                if (_tempObject != null)
                {
                    _buttonPositionY = _tempObject.transform.position.y - _offset;
                    setPressPosition(_buttonPositionY);
                    if (switchPos == SWITCH_POSITION_E.READY)
                    {

                        Debug.Log("_buttonPositionY" + _buttonPositionY);
                        Debug.Log("_buttonMaxYValue" + _buttonMaxYValue);


                        if (_buttonPositionY > _buttonMaxYValue)
                        {
                            hoverState.SetActive(true);
                            switchPos = SWITCH_POSITION_E.ACTUATING;

                        }
                    }
                    else if (switchPos == SWITCH_POSITION_E.ACTUATING)
                    {
                        // Update pressing haptic                    
                        setPressHapticIntensity((_pistonPresser.transform.position.y - _buttonMinYValue) / _pistonTravelDistance);

                        if (_buttonPositionY < _buttonMinYValue)
                        {
                            switchPos = SWITCH_POSITION_E.CLICKED;
                            pressComplete();

                        }
                    }
                    else if (switchPos == SWITCH_POSITION_E.CLICKED)
                    {

                        if (_buttonPositionY >= _buttonClickUpPosition)
                        {
                            // Hand is moving back up out off the button. 
                            switchPos = SWITCH_POSITION_E.ACTUATING;
                            clickComplete();

                        }
                    }
                }
                else
                {
                    // Catch button state if leaving vicinity
                    if (_buttonPositionY < _buttonMaxYValue)
                    {
                        // Return the button position back to initial value.
                        float damping = 0.1f;
                        _buttonPositionY = _buttonPositionY + damping * (_buttonMaxYValue - _buttonPositionY);
                        _buttonPositionY = Mathf.Min(_buttonPositionY, _buttonMaxYValue);
                        _pistonPresser.transform.position = new UnityEngine.Vector3(_pistonPresser.transform.position.x, _buttonPositionY, _pistonPresser.transform.position.z);
                    }
                }
            }


            if (FirstEndOfArea == false)
            {
                if (_tempObject != null)
                {
                    _buttonPositionY = _tempObject.transform.position.y - _offset;
                    setPressPosition(_buttonPositionY);
                    if (switchPos == SWITCH_POSITION_E.READY)
                    {

                        Debug.Log("_buttonPositionY" + _buttonPositionY);
                        Debug.Log("_buttonMaxYValue" + _buttonMaxYValue);


                        if (_buttonPositionY > _buttonMaxYValue)
                        {
                            hoverState.SetActive(true);
                            CE._emitter.start();
                            switchPos = SWITCH_POSITION_E.ACTUATING;

                        }
                    }
                    else if (switchPos == SWITCH_POSITION_E.ACTUATING)
                    {
                        // Update pressing haptic                    
                        setPressHapticIntensity((_pistonPresser.transform.position.y - _buttonMinYValue) / _pistonTravelDistance);

                        if (_buttonPositionY < _buttonMinYValue)
                        {
                            switchPos = SWITCH_POSITION_E.CLICKED;
                            pressComplete();

                        }
                    }
                    else if (switchPos == SWITCH_POSITION_E.CLICKED)
                    {

                        if (_buttonPositionY >= _buttonClickUpPosition)
                        {
                            // Hand is moving back up out off the button. 
                            switchPos = SWITCH_POSITION_E.ACTUATING;
                            clickComplete();

                        }
                    }
                }
                else
                {
                    // Catch button state if leaving vicinity
                    if (_buttonPositionY < _buttonMaxYValue)
                    {
                        // Return the button position back to initial value.
                        float damping = 0.1f;
                        _buttonPositionY = _buttonPositionY + damping * (_buttonMaxYValue - _buttonPositionY);
                        _buttonPositionY = Mathf.Min(_buttonPositionY, _buttonMaxYValue);
                        _pistonPresser.transform.position = new UnityEngine.Vector3(_pistonPresser.transform.position.x, _buttonPositionY, _pistonPresser.transform.position.z);
                    }
                }
            }
        }


        public IEnumerator Move()
        {
            cube.transform.position = Vector3.MoveTowards(start, end, 5f);

        }
        private IEnumerator OnTriggerEnter(Collider other)
        {
            if(Cube.transform.position == FirstEnd) { 
            Debug.Log("Collided");

            if (switchPos == SWITCH_POSITION_E.DISABLED)
                yield return null;

                // Debug.Log("ButtonVicinityManager OnTriggerExit");
                if (other.name == "HandTrackedBlock")
                {
                    // Use a proxy object, attached to the hand, to actuate the button.
                    if (FirstEndOfArea)
                    {
                        _tempObject = other.gameObject;

                    }


                    yield return new WaitForSeconds(0.1f);
                }
               
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (switchPos == SWITCH_POSITION_E.DISABLED)
                return;

            // Keep the press haptic tracking the hand's Y position.
            if (other.name == "HandTrackedBlock")
            {
                if (FirstEndOfArea == true)
                {
                    Block.transform.position = new UnityEngine.Vector3(
                        _pistonPresser.transform.position.x,
                        _buttonPositionY,
                        _pistonPresser.transform.position.z);
                }
                else
                {
                    StartCoroutine(Move());
                }

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (switchPos == SWITCH_POSITION_E.DISABLED)
                return;

            if (other.name == "HandTrackedBlock")
            {
                // Debug.Log("PistonvicinityManager OnTriggerExit");
                // Leaving the vicinity, go back to ready state
                switchPos = SWITCH_POSITION_E.READY;

                _tempObject = null;
                hoverState.SetActive(false);
                CE._emitter.stop();


                if (PushedDown == true)
                {
                    TiralComplete = true;
                    CE._emitter.stop();
                }


            }
        }

        private void setPressPosition(float _buttonPositionY)
        {
            float newY = Mathf.Clamp(_buttonPositionY, _buttonMinYValue, _buttonMaxYValue);
            _pistonPresser.transform.position = new UnityEngine.Vector3(_pistonPresser.transform.position.x, newY, _pistonPresser.transform.position.z);
        }

        public void setPressHapticIntensity(float normalisedTravel)
        {
            intensity = Mathf.Lerp(_maxPressIntensity, _minPressIntensity, normalisedTravel);
            baseRenderer.material.color = Color.Lerp(DarkGreenColor, lightGreenColor, normalisedTravel);
            if (PushedDown == false)
            {
                Balloon.transform.localScale = UnityEngine.Vector3.Lerp(increasedBalloonSize, BalloonSize, normalisedTravel);
            }
        }
        
        private void toggleState()
        {
            switchState = (switchState == SWITCH_STATE_E.OFF) ? SWITCH_STATE_E.ON : SWITCH_STATE_E.OFF;

        }

        private void clickComplete()
        {
            // Hand is returning out to complete the toggle.
            toggleState();
            completed = true;
            Num_Pressed = Num_Pressed + 1;





        }

        private void pressComplete()
        {
            // Hand has travelled fully to start first part of switching.
            intensity = _maxPressIntensity;
            PushedDown = true;
            baseRenderer.material.color = redColor;
            BalloonSize = Balloon.transform.localScale;




        }


    }
}
