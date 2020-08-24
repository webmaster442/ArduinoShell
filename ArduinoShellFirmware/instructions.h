//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#pragma once

#include "defines.h"
#include "baseinstructions.h"

void RunInstruction(uint8_t* buffer) {
    Serial.write(recieved);
    switch (buffer[0]) {
    case INSTRUCTION_DIGITAL_WRITE:
        DoDigitalWrite(buffer[1], buffer[2]);
        break;
    case INSTRUCTION_DIGITAL_READ:
        DoDigitalRead(buffer[1]);
        break;
    case INSTRUCTION_GET_VERSION:
        DoGetVersion();
        break;
    case INSTRUCTION_ANALOG_READ:
        DoAnalogRead(buffer[1]);
        break;
    case INSTRUCTION_ANALOG_WRITE:
        DoAnalogWrite(buffer[1], PackUint16(buffer[2], buffer[3]));
        break;
    default:
        Nop();
        break;
    }
}
