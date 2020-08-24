//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#include "defines.h"
#include "version.h"
#include "instructions.h"

void setup() {
    Serial.begin(BAUDRATE);
    while (!Serial) {
        ;
        //wait for serial connect.
        //required for usb
    }
}

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
                recieveBuffer[256] = { 0 };
                recieved = 0;
            }
        }
        if (recieved > 0) {
            runInstruction(recieveBuffer);
            delay(50);
        }
    }
}
