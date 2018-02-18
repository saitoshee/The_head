#include <Wire.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27, 16, 2);
#define Vcc  1.02f
void setup() {
  //pinMode(A0,INPUT);//P
  //pinMode(A3,INPUT); //O
  //digitalWrite(A0, HIGH);
  //digitalWrite(A3, HIGH);
  
  Serial.begin(9600);
  lcd.init();
  lcd.backlight();
}

void loop() {
 float U1,U2,SWR,Up,Uo;


  U1 = analogRead(A0);
  U2 = analogRead(A3);
  SWR = (U1 + U2) / (U1 - U2);
  
  lcd.setCursor(0, 0);
  lcd.print("P:");
  lcd.print(U1/1000);
  //lcd.print((U1/204.6)/1000);
  lcd.print(" O:");
  lcd.print(U2/1000);
  lcd.setCursor(0, 1);
  lcd.print("KCB:");
  lcd.print(SWR);
  delay(5000);

}
