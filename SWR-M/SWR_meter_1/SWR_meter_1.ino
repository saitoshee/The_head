#include <Wire.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,16,2);  // Устанавливаем дисплей
//31,17,17,17,17,17,17
//byte symbol[8] = {B11111,B10001,B10001,B10001,B10001,B10001,B10001,B10001}; // буква П
#define STRING1 STRING2 STRING3
void setup() {
  Serial.begin(9600); // инициируем СОМ порт
  lcd.init();                     
  lcd.backlight();// Включаем подсветку дисплея
  lcd.setCursor(6,1);
  //lcd.print(" KCB METP ");
  //lcd.createChar(0,symbol);
  delay(2000); 
  
 

}

void loop() {
  float U1=0;// U прямое
  float U2=0;// U обратное
  float U12=0;// Сумма U
  float U21=0;// Разность U
  float KSV=0;// Значение отношения (КСВ)
  float Ur1 = analogRead(A0); 
  float Ur2 = analogRead(A1); 
  delay(100); 
  float Ur3 = analogRead(A0); 
  float Ur4 = analogRead(A1); 
  delay(100);
  float Ur5 = analogRead(A0); 
  float Ur6 = analogRead(A1);
 
  U1=(Ur1+Ur3+Ur5)/3;
  U2=(Ur2+Ur4+Ur6)/3;
  U12=U1+U2; 
  U21=U1-U2; 
  KSV=U12/U21;
lcd.setCursor(0, 0);
  // Устанавливаем курсор на первую строку и нулевой символ.
  lcd.print("P:");
  lcd.print(U1); // U прямое
  lcd.println(" O:");
  lcd.print(U2);// U обратное
  lcd.setCursor(0, 1);
  lcd.print("KCB:");
  lcd.print(KSV);// Значение отношения (КСВ)
 delay(850); // задержка 500 мс
}

