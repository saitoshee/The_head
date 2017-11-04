// Массивы и строки SOS
const int ledPin = 13;
int durations[] = {200,200,200,500,500,500,200,200,200};

void setup() 
{
  pinMode(ledPin,OUTPUT);
}

void loop() 
{
  for(int i = 0; i < 9; i++)
  {
    flash(durations[i]);
  }
  delay(1000);
}

void flash(int delayTime)
{
  digitalWrite(ledPin,HIGH);
  delay(delayTime);
  digitalWrite(ledPin,LOW);
  delay(delayTime);

}
