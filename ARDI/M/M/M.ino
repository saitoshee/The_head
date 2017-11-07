const int16_t ledPin = 13;
const int16_t dotDelay = 100;


int8_t *letters[] = {
      ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", // A-G
      "--.-", "....", "..", ".---", "-.-", ".-..", "--", // Q-M
      "-.", "---", ".--.", "...", "-", "..-", "...-", // N-V
      ".--", "-..-", "-.--", "--.." }; // W - Z
int8_t *num[] = {
     "-----", ".----", "..---", "...--", "....-",  // 0-4
     ".....", "-....", "--...", "---..", "----.",  // 5-9
  };

void flashSeq(int8_t* seq)
{
    int16_t i = 0;
    while (seq[i] != '\0')
    {
      flashDotOrDash(seq[i]);
      i++;
    }
}

void flashDotOrDash(int8_t dORd) 
{
  digitalWrite(ledPin,HIGH);
  if (dORd == ".")
  {                       // если . задерживается вкл 100мс
    delay(dotDelay);  
  }
  else
  {                     // если - задержка 500мс 
    delay(dotDelay * 5);  
  }
  digitalWrite(ledPin,LOW);
  delay(dotDelay); // звдержка в выкл состоянии 100мс
}
void setup() 
{
pinMode(ledPin,OUTPUT);
}

void loop() 
{ 
    int8_t ch = "F";  
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
        delay(dotDelay * 3);
    }
   
}

