#include <Wire.h>
#include "SparkFun_Qwiic_Joystick_Arduino_Library.h" //Click here to get the library: http://librarymanager/All#SparkFun_joystick
JOYSTICK joystick; //Create instance of this object


const int sampleWindow = 150; // Sample window width in milliseconds
unsigned int shout;
int ledPin = 9;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);

  if(joystick.begin() == false)
  {
    Serial.println("Joystick does not appear to be connected. Please check wiring. Freezing...");
    while(1);
  }
}

void loop() {

 unsigned long start= millis();  // Start of sample window
 unsigned int peakToPeak = 0;   // peak-to-peak level
 unsigned int signalMax = 0;
 unsigned int signalMin = 1024;

  // collect data within sample window
 while (millis() - start < sampleWindow)
 {
   shout = analogRead(0);
      if (shout < 1024)  //This is the max of the 10-bit ADC so this loop will include all readings
      {
         if (shout > signalMax)
         {
           signalMax = shout;  // save just the max levels
         }
      else if (shout < signalMin)
        {
         signalMin = shout;  // save just the min levels
         }
     }
 }
 peakToPeak = signalMax - signalMin;  // max - min = peak-peak amplitude
 double volts = (peakToPeak * 3.3) / 1024;  // convert to volts


//Mic troubleshoot with LED
//Serial.println(volts);
  if (volts >=1.0 && joystick.getVertical() == 496 && joystick.getHorizontal() == 500){
  digitalWrite(ledPin, HIGH);
  Serial.write(1); //1 is attack
  Serial.flush();
  delay (20);
 }
 else
 {
 digitalWrite(ledPin, LOW);
 } 



 //Joystick Directional
 if (joystick.getVertical() == 1023 && volts >=1.0){
    Serial.println("Y: up ");
    Serial.write(2);
    Serial.flush();
    delay (20);
 }

 if (joystick.getVertical() < 400 && volts >=1.0){
    Serial.println("Y: down ");
    Serial.write(3);
    Serial.flush();
    delay (20);
 }

  if (joystick.getHorizontal() == 1023 ){
    Serial.println("X: block/grab "); //depedning on p1 or p2
    Serial.write(4);
    Serial.flush();
    delay (20);
 }

  if (joystick.getHorizontal() == 0 && volts >=1.0){
    Serial.println("X: grab/block ");
    Serial.write(5);
    Serial.flush();
    delay (20);
 }

}
