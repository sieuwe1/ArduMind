// ledstrip pins

#include <FastLED.h>

#define LED_PIN     3

// Information about the LED strip itself
#define NUM_LEDS    60
#define CHIPSET     WS2811
#define COLOR_ORDER GRB
CRGB leds[NUM_LEDS];

#define BRIGHTNESS  128

//Serial pins

String input = "";
int Value;
int R = 0;
int Lv = 0;
int G = 255;

int numLedsToLight;

void setup() {

  Serial.begin(115200);

  delay( 3000 ); // power-up safety delay
  FastLED.addLeds<CHIPSET, LED_PIN, COLOR_ORDER>(leds, NUM_LEDS).setCorrection( TypicalSMD5050 );
  FastLED.setBrightness( BRIGHTNESS );

}

void loop() {

  //FastLED.clear();

  if (Serial.available() > 0)
  {
FastLED.clear();
    
    input = Serial.readString();
    Serial.println(input);

    int ind1 = input.indexOf(';');
    Value = input.substring(0, ind1).toInt();

    numLedsToLight = map(Value, 0, 100, 0, NUM_LEDS);

    R =  map(Value, 0, 100, 0, 255);

    for (int led = 0; led < numLedsToLight; led++) {

      if (Lv <= R)
      {
        G = G - abs(R - Lv);
        Lv = R;

      }

      if (Lv > R)
      {
        G = G + abs(Lv - R);
        Lv = R;

      }

      leds[led].setRGB(R, G,0);
      delay(5);
      FastLED.show();
    }


  }



}




