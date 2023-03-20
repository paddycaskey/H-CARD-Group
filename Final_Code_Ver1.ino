const int button1Pin = 2;
const int button2Pin = 3;

const int inputDTPin = 6;
const int inputCLKPin = 7;

const int switchPin = 9;

const int pressurePin = A0;

const int xaxisPin = A2;
const int yaxisPin = A3;

int counter = 0;

int currentStateCLK;
int previousStateCLK;

int button1State = 0;
int button2State = 0;

int switchState = 0;

int x;
int y;

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

  Serial.begin(9600);

  previousStateCLK = digitalRead(inputCLKPin);
}

void loop() {
  button1State = digitalRead(button1Pin);

  Serial.print(button1State);
  Serial.print(",");
  
  button2State = digitalRead(button2Pin);

  Serial.print(button2State);
  Serial.print(",");
  
  currentStateCLK = digitalRead(inputCLKPin);

  if (currentStateCLK != previousStateCLK){

    if (digitalRead(inputDTPin) != currentStateCLK){
      counter ++;
    } else{
      counter --;
    }

    previousStateCLK = currentStateCLK;
  }

  Serial.print(counter);
  Serial.print(",");

  switchState = digitalRead(switchPin);

  Serial.print(switchState);
  Serial.print(",");

  x = analogRead(xaxisPin);

  Serial.print(x);
  Serial.print(",");

  y = analogRead(yaxisPin);

  Serial.print(y);
  Serial.print(",");

  force = analogRead(pressurePin);

  if (force > forceThreshold){
    force = 1;
  } else{
    force = 0;
  }

  Serial.println(force);
}
