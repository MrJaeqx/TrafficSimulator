// notes in the melody:
int melody[] = {
  NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0, NOTE_DS6, 0};

// note durations: 4 = quarter note, 8 = eighth note, etc.:
int noteDurations[] = {
  8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8};
  
void Makesound()
{
  for (int thisNote = 0; thisNote < 24; thisNote++) 
  {
    // to calculate the note duration, take one second 
    // divided by the note type.
    //e.g. quarter note = 1000 / 4, eighth note = 1000/8, etc.
    int noteDuration = 1000/noteDurations[thisNote];
    tone(8, melody[thisNote],noteDuration);

    // to distinguish the notes, set a minimum time between them.
    // the note's duration + 30% seems to work well:
    int pauseBetweenNotes = noteDuration * 0.80;
    delay(pauseBetweenNotes);
    // stop the tone playing:
    noTone(8);
  }
}

