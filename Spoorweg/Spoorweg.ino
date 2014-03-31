#include "pitches.h"
#include <Servo.h>
#include <Bounce2.h>

Bounce trein = Bounce();

const int LDR1 = A1;
const int LDR2 = A0;
const int leds = 5;
int slagboompositie = 0;

int lichtsterkte = 0;

Servo myservo1;
Servo myservo2; // create servo object to control a servo 
// a maximum of eight servo objects can be created 

int pos = 0;    // variable to store the servo position 

void setup() 
{
  //trein.attach(7);
  //trein.interval(5);
  myservo1.attach(9);
  myservo2.attach(10);  // attaches the servo on pin 9 to the servo object
  pinMode(leds, OUTPUT);
  digitalWrite(leds, LOW);
  
  Serial.begin(9600);
}

void loop() 
{
  int startLicht = analogRead(LDR1);
  int eindLicht = analogRead(LDR2);
  
  //Serial.println(startLicht);
  //Serial.println(eindLicht);
 
  //trein.update();

  //int valueTrein = trein.read();

  if(startLicht < 400 && eindLicht >= 400)
  {
    Serial.println("1");
    if(slagboompositie == 0)
    {
      digitalWrite(leds, HIGH);
      Makesound();
      SlagboomDicht();
      slagboompositie = 1;
    }
  }
  else if(startLicht >= 400 && eindLicht >= 400)
  {
    if(slagboompositie == 1)
    {
      Makesound();
      SlagboomOpen();
      digitalWrite(leds, LOW);
      slagboompositie = 0;
      Serial.println("2");
    }
  }
}




