//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#define BUFFER_MAX 255
#define BAUDRATE 19200

#define VERSION_MAYOR 20
#define VERSION_MINOR 8
#define VERSION_BUILD 23

void setup() {
  Serial.begin(19200);
  while (!Serial) {
    ;
    //wait for serial connect.
    //required for usb
  }
}

uint8_t recieveBuffer[256] = {0};
uint8_t recieved = 0;

void runInstruction(uint8_t *buffer);

void loop() {
  if (Serial.available()) {
    recieved = 0;
    while (Serial.available()) {
      if (recieved + 1 < BUFFER_MAX) {
        recieveBuffer[recieved] = Serial.read();
        ++recieved;
      }
      else {
        Serial.read();
        recieveBuffer[256] = {0};
        recieved = 0;
      }
    }
    if (recieved > 0) {
      runInstruction(recieveBuffer);
      delay(50);
    }
  }
}
