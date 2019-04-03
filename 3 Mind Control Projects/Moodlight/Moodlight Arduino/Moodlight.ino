int RValue;
int GValue;
int BValue;
bool serialActive = false;



void setup() {
  // put your setup code here, to run once:

  Serial.begin(115200);

  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(4, OUTPUT);

  digitalWrite(4,LOW);

}

void loop() {
  // put your main code here, to run repeatedly:
  serialActive =  true;
/*
  while (serialActive == false)
  {
    digitalWrite(8, LOW);
    if (Serial.readString() == "remote") {
      serialActive = true;
      Serial.println("Hi");
    }
  }
  */
while(serialActive == true){
   digitalWrite(8, HIGH);

  while (Serial.available() > 0) {
   
    
    if (Serial.available() > 0)
    {
      String input = Serial.readString();

      int ind1 = input.indexOf(';');  
      RValue = input.substring(0, ind1).toInt();   
      int ind2 = input.indexOf(';', ind1+1 );  
      GValue = input.substring(ind1+1, ind2+1).toInt();   
      int ind3 = input.indexOf(';', ind2+1 );
      BValue = input.substring(ind2+1, ind3+1).toInt();

      

    }

    analogWrite(9,RValue);
    analogWrite(11,GValue);
    analogWrite(12,BValue);

  }
}


}
