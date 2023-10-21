#include <SoftwareSerial.h>

SoftwareSerial bluetoothSerial(11, 10);

unsigned long last;

void setup() {
  pinMode(PIN_LED, OUTPUT);
  
  Serial.begin(9600);
  bluetoothSerial.begin(9600);

  last = millis();
}
int notePrecision = 25;
int sameNoteAmmount = 0;
int previousNote = 64;

void loop() {
  
 if(bluetoothSerial.available()){
     int input = bluetoothSerial.read();
    if(input > 49 && input < 72){
        if(previousNote != input){
          sameNoteAmmount = 0;
          previousNote = input;
        }else{
          sameNoteAmmount++;
          if(sameNoteAmmount > notePrecision){
            char note = (char) previousNote;
            Serial.println(note);
            sameNoteAmmount = 0;
          }
        }
    }
 }  
 
}
