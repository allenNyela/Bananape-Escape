using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LabInteractionController : MonoBehaviour
{
    public GameObject online;
    public GameObject offline;
    public GameObject doorClosed;
    public GameObject doorOpen;

    public GameObject Electricity;

    public GameObject InventorySystemObj;
    private InventorySystem inventorySystem;
    public GameObject Player;
    public GameObject stickyNoteUI;
    public GameObject stickyNote;
    public GameObject posterLarge;
    public GameObject ptPiece1;
    public GameObject ptPiece2;
    public GameObject ptPiece3;
    public LabInventoryItemData ptPiece1Data;
    public LabInventoryItemData ptPiece2Data;
    public LabInventoryItemData ptPiece3Data;

    public GameObject BeakerPlacedObj;
    public LabInventoryItemData beakerData;

    public GameObject KeyPadUI;
    public GameObject KeyPad;

    public Text inputText;

    public string password;
    
    public string passwordEntered = "";

    private int numOfDigitsEntered = 0;

    public GameObject machineFace;
    public Sprite onMachine;

    private bool posterComplete = false;
    private bool beakerPlaced = false;

    public GameObject faucet;
    public Sprite faucetOn;
    public Sprite faucetOff;
    public GameObject SpilledWater;

    public Animator beakerAnimator;

    private bool isFaucetOn = false;

    public GameObject Wires;
    public Sprite CutWiresSprite;
    public LabInventoryItemData scissorsData;

    public GameObject Scissors;
    public GameObject OpenDrawer;
    public LabInventoryItemData SilverKeyData;

    public GameObject goldKey;
    public GameObject openLocker;
    public GameObject closedLocker;
    public LabInventoryItemData GogglesData;
    public LabInventoryItemData CoatData;
    public GameObject Scanner;

    public GameObject Vent;
    public GameObject SilverKey;
    public LabInventoryItemData ScrewdriverData;

    public GameObject CabinetClosed;
    public GameObject CabinetOpen;
    public GameObject Screwdriver;
    public LabInventoryItemData goldKeyData;

    private bool passwordCorrect = false;
    private bool wiresCut = false;
    private bool waterSpilled = false;

    public void Awake() {
        inventorySystem = InventorySystemObj.GetComponent<InventorySystem>();
    }

    private void CheckIfWon() {
        if(passwordCorrect && wiresCut && waterSpilled) {
            offline.SetActive(true);
            online.SetActive(false);

            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
        }

        if(wiresCut && passwordCorrect) {
            Electricity.SetActive(true);
        }
    }

    public void GoToNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StickyEnabled() {
        if (Vector3.Distance (stickyNote.transform.position, Player.transform.position) < 3) {
            stickyNoteUI.SetActive(true);
        }
    }

    public void StickyDisabled() {
        stickyNoteUI.SetActive(false);
    }

    public void DisplayPoster() {
        if (Vector3.Distance (ptPiece1.transform.position, Player.transform.position) < 3) {
            if(!posterComplete) {
                if(inventorySystem.Get(ptPiece1Data) != null) {
                    ptPiece1.SetActive(true);
                    inventorySystem.Remove(ptPiece1Data);
                }
                if(inventorySystem.Get(ptPiece2Data) != null) {
                    ptPiece2.SetActive(true);
                    inventorySystem.Remove(ptPiece2Data);
                }
                if(inventorySystem.Get(ptPiece3Data) != null) {
                    ptPiece3.SetActive(true);
                    inventorySystem.Remove(ptPiece3Data);
                }
                if(ptPiece1.activeSelf && ptPiece2.activeSelf && ptPiece3.activeSelf) {
                    posterComplete = true;
                }
            }
            else {
                // Display Poster in large view
                posterLarge.SetActive(true);
            }
        }
    }

    public void HidePoster() {
        posterLarge.SetActive(false);
    }

    public void PlaceBeaker() {
        if((Vector3.Distance (BeakerPlacedObj.transform.position, Player.transform.position) < 3) && !beakerPlaced) {
            if(inventorySystem.Get(beakerData) != null) {
                BeakerPlacedObj.GetComponent<SpriteRenderer>().enabled = true;
                beakerPlaced = true;
                inventorySystem.Remove(beakerData);
            }
        }
    }

    public void ShowKeypad() {
        if (Vector3.Distance (KeyPad.transform.position, Player.transform.position) < 3 && !passwordCorrect) {
            KeyPadUI.SetActive(true);
        }
    }

    public void HideKeypad() {
        passwordEntered = "";
        inputText.text = passwordEntered;
        numOfDigitsEntered = 0;
        KeyPadUI.SetActive(false);
    }

    public void KeypadEnterNumber(int num) {
        passwordEntered += num;
        inputText.text = passwordEntered;
        numOfDigitsEntered++;

        if(numOfDigitsEntered == 5) {
            if(password == passwordEntered) {
                passwordCorrect = true;
                machineFace.GetComponent<SpriteRenderer>().sprite = onMachine;
                HideKeypad();
                CheckIfWon();
            }
            else {
                passwordEntered = "";
                inputText.text = passwordEntered;
                numOfDigitsEntered = 0;
            }
        }
    }

    public void TurnOnOffFaucet() {
        if(Vector3.Distance (faucet.transform.position, Player.transform.position) < 3) {
            if(isFaucetOn) {
                faucet.GetComponent<SpriteRenderer>().sprite = faucetOff;
                isFaucetOn = false;
            }
            else {
                faucet.GetComponent<SpriteRenderer>().sprite = faucetOn;
                isFaucetOn = true;

                if(beakerPlaced && !waterSpilled) {
                    beakerAnimator.SetTrigger("FillBeaker");
                }
            }
        }
        
    }

    public void BeakerSpill() {
        waterSpilled = true;
        SpilledWater.SetActive(true);
        faucet.GetComponent<SpriteRenderer>().sprite = faucetOff;
        isFaucetOn = false;
        CheckIfWon();
    }

    public void CutWires() {
        if (Vector3.Distance (Wires.transform.position, Player.transform.position) < 8 && !wiresCut) {
            if(inventorySystem.Get(scissorsData) != null) {
                Wires.GetComponent<SpriteRenderer>().sprite = CutWiresSprite;
                inventorySystem.Remove(scissorsData);
                wiresCut = true;
                CheckIfWon();
            }
        }
    }

    public void OpenScissorDrawer() {
        if(inventorySystem.Get(SilverKeyData) != null) {
            inventorySystem.Remove(SilverKeyData);
            OpenDrawer.SetActive(true);
            Scissors.SetActive(true);
        }
    }

    public void OpenLocker() {
        if(Vector3.Distance (closedLocker.transform.position, Player.transform.position) < 5 && inventorySystem.Get(GogglesData) != null && inventorySystem.Get(CoatData) != null) {
            inventorySystem.Remove(GogglesData);
            inventorySystem.Remove(CoatData);
            openLocker.SetActive(true);
            goldKey.SetActive(true);
            closedLocker.SetActive(false);
            Scanner.SetActive(false);
        }
    }

    public void OpenVent() {
        if(Vector3.Distance (Vent.transform.position, Player.transform.position) < 3 && inventorySystem.Get(ScrewdriverData) != null) {
            inventorySystem.Remove(ScrewdriverData);
            Vent.SetActive(false);
            SilverKey.SetActive(true);
        }
    }

    public void OpenCabinet() {
        if(Vector3.Distance (CabinetClosed.transform.position, Player.transform.position) < 3 && inventorySystem.Get(goldKeyData) != null) {
            inventorySystem.Remove(goldKeyData);
            CabinetClosed.SetActive(false);
            CabinetOpen.SetActive(true);
            Screwdriver.SetActive(true);
        }
    }

}
