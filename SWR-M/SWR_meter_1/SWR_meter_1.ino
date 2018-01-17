#include <Wire.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,16,2);  // Устанавливаем дисплей
//31,17,17,17,17,17,17
byte symbol[8] = {B11111,B10001,B10001,B10001,B10001,B10001,B10001,B10001}; // буква П
#define STRING1 STRING2 STRING3
void setup() {
  Serial.begin(9600); // инициируем СОМ порт
  lcd.init();                     
  lcd.backlight();// Включаем подсветку дисплея
  lcd.setCursor(6,1);
  lcd.print(" KCB METP ");
  lcd.createChar(0,symbol);
  delay(3000); // задержка 3с
  
 

}

void loop() {
  int U1=0;// U прямое
  int U2=0;// U обратное
  int U12=0;// Сумма U
  float U21=0;// Разность U
  float KSV=0;// Значение отношения (КСВ)
  int Ur1 = analogRead(A0); // считываем значение U с аналогового входа 0
  int Ur2 = analogRead(A1); // считываем значение U с аналогового входа 1
  delay(50); // задержка 50 мс
  int Ur3 = analogRead(A0); // считываем значение U с аналогового входа 0
  int Ur4 = analogRead(A1); // считываем значение U с аналогового входа 1
  delay(50); // задержка 50 мс
  int Ur5 = analogRead(A0); // считываем значение U с аналогового входа 0
  int Ur6 = analogRead(A1); // считываем значение U с аналогового входа 1
 
  U1=(Ur1+Ur3+Ur5)/3; // присваиваем значение переменной
  U2=(Ur2+Ur4+Ur6)/3;// присваиваем значение переменной
  U12=U1+U2; // вычисляем сумму
  U21=U1-U2; // вычисляем разность
  KSV=U12/U21;// вычисляем отношение
lcd.setCursor(0, 0);
  // Устанавливаем курсор на первую строку и нулевой символ.
  lcd.write(byte(0));
  lcd.print(": ");
  lcd.print(U1); // U прямое
  lcd.println(" O: ");
  lcd.print(U2);// U обратное
  lcd.print("   ");
  lcd.setCursor(0, 1);
  lcd.print("KCB: ");
  lcd.print(KSV);// Значение отношения (КСВ)
  lcd.print(" ");
 delay(500); // задержка 500 мс
}

