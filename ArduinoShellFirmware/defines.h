//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#pragma once

//global program variables
uint8_t recieveBuffer[256] = { 0 };			//recieve buffer
uint8_t recieved = 0;						//recieved bytes

//global program defines
#define BUFFER_MAX 255						//Buffer maximum size
#define BAUDRATE 19200						//Com. port baud rate


//Instruction codes for decoding
#define INSTRUCTION_DIGITAL_WRITE			0x10
#define INSTRUCTION_DIGITAL_READ			0x11
#define INSTRUCTION_GET_VERSION				0xfe