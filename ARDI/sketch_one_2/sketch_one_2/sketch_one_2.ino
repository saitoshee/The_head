//Функция, возвращаемые значения
float centToF(float c)
{
  float f = c * 9 / 5 + 32;
  return f;
 }

void setup() {
  // put your setup code here, to run once:

}

void loop() {
  // put your main code here, to run repeatedly:
  float a = centToF(25);
  int x;
  boolean tooBig = (x > 10);
  if (tooBig)
  {
    x = 5;  
  }

}
