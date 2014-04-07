void SlagboomDicht()
{
  for(pos = 75; pos < 180; pos += 1)  // goes from 0 degrees to 180 degrees 
  {                                  // in steps of 1 degree 
    myservo1.write(pos);
    myservo2.write(pos);    // tell servo to go to position in variable 'pos' 
    delay(15);    // waits 15ms for the servo to reach the position     
  }  
}

void SlagboomOpen()
{
  for(pos = 180; pos>=75; pos-=1)     // goes from 180 degrees to 0 degrees 
  {                                
    myservo1.write(pos);
    myservo2.write(pos);    // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  }
}
