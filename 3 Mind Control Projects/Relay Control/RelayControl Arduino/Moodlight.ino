
void setup() {
  // put your setup code here, to run once:

  Serial.begin(115200);

  pinMode(7, OUTPUT);


}

void loop() {

  if (Serial.available() > 0)
  {

    if(Serial.readString() == "Aan") {

    digitalWrite(7, HIGH);

    }

    else {

      digitalWrite(7, LOW);

    }

  }

}




