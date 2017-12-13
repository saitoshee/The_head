// KCB METP
#include <Wire.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2); // Устанавливаем дисплей

void setup() {
  Serial.begin(9600); // инициируем СОМ порт
  lcd.init();
  lcd.backlight();// Включаем подсветку дисплея
  lcd.setCursor(0,3);
  lcd.print("KCB METP");
  delay(1000); // задержка 2000 мс
}

void loop() {
  float SWR = 0.0F; // Значение отношения (КСВ)
  float Ur_a0[2];
  float Ur_a1[2];
  float sum0 = 0;
  float sum1 = 0;
  for(int i = 0; i < 3; i++)
  {
    Ur_a0[i] = analogRead(A0);
    Ur_a1[i] = analogRead(A1);
    sum0 += Ur_a0[i];
    sum1 += Ur_a1[i];  
  }
  
  SWR = (sum0 / 3) + (sum1 / 3) / (sum0 / 3) - (sum1 / 3);
  lcd.setCursor(0, 0);
  // Устанавливаем курсор на первую строку и нулевой символ.
  lcd.print("P ");
  lcd.print(sum0); // U прямое
  lcd.print("  O ");
  lcd.print(sum1);// U обратное
  lcd.setCursor(1, 0);
  lcd.print("KCB: ");
  lcd.print(SWR);// Значение отношения (КСВ)
  delay(3000); // задержка 500 мс
}



