#include "pitches.h"
#include <Servo.h>
#include <Bounce2.h>

Bounce trein = Bounce();

const int LDR = A1;
const int leds = 5;
int slagboompositie = 0;

int lichtsterkte = 0;

Servo myservo;  // create servo object to control a servo 
// a maximum of eight servo objects can be created 

int pos = 0;    // variable to store the servo position 

void setup() 
{
  trein.attach(7);
  trein.interval(5);
  myservo.attach(9);  // attaches the servo on pin 9 to the servo object
  pinMode(leds, OUTPUT);
  digitalWrite(leds, LOW);
  
  Serial.begin(9600);
}

void loop() 
{
  int lichtinval = analogRead(LDR);
  
  Serial.print(lichtinval);
  Serial.print(" ");
  
  trein.update();

  int valueTrein = trein.read();

  if(valueTrein == HIGH || lichtinval < 400)
  {
    if(slagboompositie == 0)
    {
      digitalWrite(leds, HIGH);
      Makesound();
      SlagboomDicht();
      slagboompositie = 1;
    }
  }
  else
  {
    if(slagboompositie == 1)
    {
      Makesound();
      SlagboomOpen();
      digitalWrite(leds, LOW);
      slagboompositie = 0;
    }
  }
}




