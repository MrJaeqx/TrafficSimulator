int timeDetectorBlocked = 0;
int timeDetectorUnblocked = 0;

void DetectorLightsOn()
{
  digitalWrite(trainDetectorLightIncoming, HIGH);
  digitalWrite(trainDetectorLightOutgoing, HIGH);
}

void DetectorLightsOff()
{
  digitalWrite(trainDetectorLightIncoming, LOW);
  digitalWrite(trainDetectorLightOutgoing, LOW);
}

void TrainDetection(int incomingTrainSensor, int outgoingTrainSensor, int switchPoint)
{
  if((incomingTrainSensor <= switchPoint - 30 && outgoingTrainSensor >= switchPoint + 30) || (incomingTrainSensor <= switchPoint - 30 && outgoingTrainSensor <= switchPoint - 30) || (incomingTrainSensor >= switchPoint + 30 && outgoingTrainSensor <= switchPoint - 30))
  {
    timeDetectorBlocked++;
    if(timeDetectorBlocked >= 50)
    { 
      timeDetectorUnblocked = 0;     
      train = true; 
    }
  }
  else if((incomingTrainSensor >= switchPoint + 30 && outgoingTrainSensor >= switchPoint + 30))
  { 
    timeDetectorUnblocked++;
    if(timeDetectorUnblocked >= 50)
    { 
      timeDetectorBlocked = 0;     
      train = false;
    }
  }
}

void PrintDetectorValues(int incomingTrainSensor, int outgoingTrainSensor, int switchPoint)
{
  Serial.print("Incoming = ");
  Serial.print(incomingTrainSensor);
  Serial.print(" Outgoing = ");
  Serial.print(outgoingTrainSensor);
  Serial.print(" Switch value = ");
  Serial.println(switchPoint);
}

