
int RValue;
int GValue;
int BValue;
bool serialActive = false;
String input = "";


void setup() {
  // put your setup code here, to run once:

  Serial.begin(115200);

  pinMode(7, OUTPUT);
}

void loop() {
  
    if (Serial.available() > 0)
    {
      input = Serial.readString();
      
      Serial.println(input);
      
      int ind1 = input.indexOf(';');  
      RValue = input.substring(0, ind1).toInt();   
      int ind2 = input.indexOf(';', ind1+1 );  
      GValue = input.substring(ind1+1, ind2+1).toInt();   

   if(RValue == 1){
digitalWrite(7, HIGH);
      
    }

    else
    {
      digitalWrite(7, LOW);
    }
    }

 

  }
