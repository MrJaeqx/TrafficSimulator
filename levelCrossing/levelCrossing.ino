#include "pitches.h"
#include <Servo.h>

const int warningLights = 5;

const int trainDetectorLightIncoming = 2;
const int trainDetectorLightOutgoing = 3;

const int trainDetectorIncoming = A3;
const int trainDetectorOutgoing = A4;

const int lightIntensityMeter = A5;

const int potMeter = A0;

Servo crossingGate1;
Servo crossingGate2;

int timeInBetween = 0;

int initial = 0;

boolean train = false;
boolean warningLight = false;

void setup()
{
  Serial.begin(9600);
  pinMode(warningLights, OUTPUT);
  pinMode(trainDetectorLightIncoming, OUTPUT);
  pinMode(trainDetectorLightOutgoing, OUTPUT);
  crossingGate1.attach(15);
  crossingGate2.attach(16);  
  WarningLightsOff();
  DetectorLightsOn();
  crossingGate1.write(90);
  crossingGate2.write(90);
}

void loop()
{
  //Write sensor and pot values into variables
  int incomingTrainRead = analogRead(trainDetectorIncoming);  
  int outgoingTrainRead = analogRead(trainDetectorOutgoing);
  int pot = analogRead(potMeter);

  //PrintDetectorValues(incomingTrainRead, outgoingTrainRead, pot); //Print sensor and pot values on the serial monitor
  
  //int lightIntensity = analogRead(lightIntensityMeter);
  //map(lightIntensity, 0, 1023, 0, 255);  //Use to control leds with pwm

  if(train == true)
  {
    //The lights begin to flash, the sound plays and finally the gates close
    timeInBetween++;
    if(warningLight == false)
    {
      incomingTrainMessage();
      warningLight = true;
      WarningLightsOn();
    }
    else if(timeInBetween == 50)
    {
      CloseCrossingGates(crossingGate1, crossingGate2);
    }
    else if(timeInBetween <= 50)
    {
      WarningSound();
    }
    //Detect if train is still passing by or gone
    TrainDetection(incomingTrainRead, outgoingTrainRead, pot);
  }
  else
  {
    //The gates open and finally the flashing lights turn off
    OpenCrossingGates(crossingGate1, crossingGate2);
    if(warningLight == true)
    {
      outgoingTrainMessage();
      timeInBetween = 0;
      warningLight = false;
      WarningLightsOff();
    }
    //Detect an incoming train
    TrainDetection(incomingTrainRead, outgoingTrainRead, pot);
  }
}



