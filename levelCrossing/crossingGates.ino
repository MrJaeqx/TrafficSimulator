
void CloseCrossingGates(Servo crossingGate1, Servo crossingGate2)
{
  int angle = crossingGate1.read();

  if(angle == 90)
  {
    for(int gatePosition = 90; gatePosition <= 180; gatePosition += 1)     // goes from 90 degrees to 180 degrees 
    { 
      crossingGate1.write(gatePosition);
      crossingGate2.write(gatePosition);       // tell servo to go to position in variable 'gatePosition'  
      delay(25);                               // waits 25ms for the servo to reach the position 
    }
  }
}

void OpenCrossingGates(Servo crossingGate1, Servo crossingGate2)
{
  int angle = crossingGate1.read();

  if(angle == 180)
  {
    for(int gatePosition = 180; gatePosition >= 90; gatePosition -= 1)     // goes from 180 degrees to 90 degrees 
    {      
      crossingGate1.write(gatePosition);
      crossingGate2.write(gatePosition);             // tell servo to go to position in variable 'gatePosition' 
      delay(25);                                     // waits 25ms for the servo to reach the position 
    }
  }
}







