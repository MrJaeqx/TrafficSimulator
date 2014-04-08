int thisNote = 0;

// notes in the melody:
int melody[] = {
  NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0};

// note durations: 4 = quarter note, 8 = eighth note, etc.:
int noteDurations[] = {
  8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8};

void WarningSound()
{
  // to calculate the note duration, take one second divided by the note type.
  // quarter note = 1000 / 4, eighth note = 1000/8, etc.
  int noteDuration = 1000/noteDurations[thisNote];
  tone(8, melody[thisNote],noteDuration);

  // to distinguish the notes, set a minimum time between them.
  int pauseBetweenNotes = noteDuration * 0.80;
  delay(pauseBetweenNotes);
  // stop the tone playing:
  noTone(8); 

  thisNote++;
  if(thisNote == 24)
  {
    thisNote = 0;
  } 
}







