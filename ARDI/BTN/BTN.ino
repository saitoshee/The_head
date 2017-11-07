const int16_t BTN = 2;   
const int16_t LED =  13;     

void setup() {

  pinMode(LED, OUTPUT);
  pinMode(BTN, INPUT);
}

void loop() {

    digitalWrite(LED, ! digitalRead(BTN));

}
