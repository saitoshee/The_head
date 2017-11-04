// Массивы и строки SOS
const int ledPin = 13;
const int dotDelay = 200;
char *letters[] = {
      ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", // A-G
      "--.-", "....", "..", ".---", "-.-", ".-..", "--", // Q-M
      "-.", "---", ".--.", "...", "-", "..-", "...-", // N-V
      ".--", "-..-", "-.--", "--.." }; // W - Z
char *num[] = {
      ".----", "..---", "...--", "....-", ".....", "-....", // 1-6
      "--...", "---..", "----.", "-----" // 7-0
  };

void flashSeq(char* seq)
{
    int i = 0;
    while (seq[i] != '\0')
    {
      flashDotOrDash(seq[i]);
      i++;
    }
    delay(dotDelay * 3);
}

void flashDotOrDash(char dORd)
{
  digitalWrite(ledPin,HIGH);
  if (dORd == ".")
  {
    delay(dotDelay);  
  }
  else
  {
    delay(dotDelay * 3);  
  }
  digitalWrite(ledPin,LOW);
  delay(dotDelay);
}
void setup() 
{
pinMode(ledPin,OUTPUT);
Serial.begin(9600);
}

void loop() 
{
  char ch;
  if (Serial.available() > 0)
  {
    ch = Serial.read();
    if (ch >= 'a' && ch <= 'z')
    {
      flashSeq(letters[ch - 'a']);  
    }
    else if(ch >= 'A' && ch <='Z')
    {
      flashSeq(letters[ch - 'A']);  
    }
    else if(ch >= '0' && ch <='9')
    {
      flashSeq(num[ch - '0']);  
    }
    else if(ch == ' ')
    {
        delay(dotDelay * 4);
    }
   
  }
}

void flash(int delayTime)
{


}
