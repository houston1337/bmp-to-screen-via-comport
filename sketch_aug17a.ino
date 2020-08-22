#include <Adafruit_GFX.h>    // Core graphics library
#include <Adafruit_ST7789.h> // Hardware-specific library for ST7789
#include <SPI.h>             // Arduino SPI library
 
// ST7789 TFT module connections
#define TFT_CS     10
#define TFT_RST    8  // define reset pin, or set to -1 and connect to Arduino RESET pin
#define TFT_DC     9  // define data/command pin
uint16_t x;
int16_t y;
      
int16_t c;
// Initialize Adafruit ST7789 TFT library
Adafruit_ST7789 tft = Adafruit_ST7789(TFT_CS, TFT_DC, TFT_RST);
 
void setup(void) {
  Serial.begin(115200);
  Serial.print(F("Hello! ST7789 TFT Test"));
 
  // if the display has CS pin try with SPI_MODE0
  tft.init(240, 240, SPI_MODE2);    // Init ST7789 display 240x240 pixel
  // if the screen is flipped, remove this command
  tft.setRotation(2);
  Serial.println(F("Initialized"));
  uint16_t time = millis();
  tft.fillScreen(ST77XX_BLACK);
  time = millis() - time;
  delay(500);
  
  
}
 
void loop() {
       Serial.setTimeout(100500);
   x = Serial.parseInt();
  
    y = Serial.parseInt();
  
    c = Serial.parseInt();

    tft.drawPixel(x,y,c);
 
      
   
 
}
 

 
