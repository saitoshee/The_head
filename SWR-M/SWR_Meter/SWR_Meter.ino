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
  delay(2000); // задержка 2000 мс
}

void loop() {
  float U12 = 0.0F, U21 = 0.0F, SWR = 0.0F; // Сумма, разность и КСВ
  int16_t N = 2; // Кол-во измерений N +1
  float *Ur_a0  = new float[N];
  float U1 = 0.0F, U2 = 0.0F;
  float *Ur_a1  = new float[N];
  for (int16_t i = 0; i < (N + 1); i++)
    {
        Ur_a0[i] = analogRead(A0);
        delay(50);
        Ur_a1[i] = analogRead(A1);
        delay(50);
        U1 += Ur_a1[i];
        U2 += Ur_a0[i];
    }
 
  U12 = (U1 / (N+1)) + (U2 / (N+1)); // вычисляем сумму
  U21 = (U1 / (N+1)) - (U2 / (N+1)); // вычисляем разность
  SWR = U12 / U21; // вычисляем отношение
  lcd.setCursor(0, 0);
  // Устанавливаем курсор на первую строку и нулевой символ.
  lcd.print("P ");
  lcd.print(U1); // U прямое
  lcd.print("   ");
  lcd.print("O ");
  lcd.print(U2);// U обратное
  lcd.setCursor(1, 0);
  lcd.print("KCB ");
  lcd.print(SWR);// Значение отношения (КСВ)
  delay(500); // задержка 500 мс
}



