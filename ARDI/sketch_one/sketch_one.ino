//scetch_one||Ar

int ledPin = 13;
int delayTime = 5;
void setup() {
  // put your setup code here, to run once:
  pinMode(ledPin,OUTPUT);

}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(ledPin,HIGH);
  delay(delayTime);
  digitalWrite(ledPin,LOW);
  delay(delayTime);
 // delayTime = delayTime + 1000;
  
}
