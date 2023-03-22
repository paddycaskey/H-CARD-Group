#include <HID.h>
#include <Keyboard.h>
#include <KeyboardLayout.h>

const int button1Pin = 2;
const int button2Pin = 3;

const int inputDTPin = 6;
const int inputCLKPin = 7;

const int switchPin = 9;

const int pressurePin = A0;

const int xaxisPin = A2;
const int yaxisPin = A3;

const int motorPin = 12;

int counter = 0;
int turnLimit = 10;

int currentStateCLK;
int previousStateCLK;

int button1State = 0;
int button2State = 0;

int switchState = 0;

int x;
int y;

int joystickThresholdup = 800;
int joystickThresholddown = 200;

int force;
int forceThreshold = 500;

void setup() {
  pinMode(button1Pin, INPUT);
  pinMode(button2Pin, INPUT);

  pinMode(inputDTPin, INPUT);
  pinMode(inputCLKPin, INPUT);

  pinMode(switchPin, INPUT);

  pinMode(pressurePin, INPUT);

  pinMode(xaxisPin, INPUT);
  pinMode(yaxisPin, INPUT);

  pinMode(motorPin, OUTPUT);

  Serial.begin(9600);
  Keyboard.begin();

  previousStateCLK = digitalRead(inputCLKPin);
}

void loop() {
  button1State = digitalRead(button1Pin);
  button2State = digitalRead(button2Pin);

  currentStateCLK = digitalRead(inputCLKPin);
  if (currentStateCLK != previousStateCLK){

    if (digitalRead(inputDTPin) != currentStateCLK){
      counter ++;
    } else{
      counter --;
    }

    previousStateCLK = currentStateCLK;
  }
  
  switchState = digitalRead(switchPin);
  
  x = analogRead(xaxisPin);
  y = analogRead(yaxisPin);
  
  force = analogRead(pressurePin);

  //*Actions*
  
  if (button1State == HIGH && button2State == HIGH) {
      Serial.println("Buttons 1 & 2 Pressed");
      Keyboard.press(' ');
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release(' ');
    }
  
  if (counter >= turnLimit || counter <= -turnLimit) {
      Serial.println("Encoder Turned");
      Keyboard.press('b');
      digitalWrite(motorPin, HIGH);
      counter = 0;
  //    delay(500);
    } else {
      Keyboard.release('b');
    }

  if (x >= joystickThresholdup) {
      Serial.println("Up Pressed");
      Keyboard.press(KEY_DOWN_ARROW);
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release(KEY_DOWN_ARROW);
    }
  
  if (x <= joystickThresholddown) {
      Serial.println("Down Pressed");
      Keyboard.press(KEY_UP_ARROW);
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release(KEY_UP_ARROW);
    }

      if (y >= joystickThresholdup) {
      Serial.println("Up Pressed (Y)");
      Keyboard.press(KEY_LEFT_ARROW);
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release(KEY_LEFT_ARROW);
    }
  
  if (y <= joystickThresholddown) {
      Serial.println("Down Pressed (Y)");
      Keyboard.press(KEY_RIGHT_ARROW);
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release(KEY_RIGHT_ARROW);
    }

   if (force >= forceThreshold) {
      Serial.println("Pressed with force");
      Keyboard.press('g');
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release('g');
    }

  if (switchState == HIGH) {
      Serial.println("Switch On");
      Keyboard.press('h');
      digitalWrite(motorPin, HIGH);
  //    delay(500);
    } else {
      Keyboard.release('h');
    }

  digitalWrite(motorPin, LOW);
}
