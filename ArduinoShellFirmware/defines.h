//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#pragma once

//global program variables
uint8_t recieveBuffer[256] = { 0 };			//recieve buffer
uint8_t recieved = 0;						//recieved bytes

//types for communication
typedef union {
	uint32_t int32;
	uint8_t bytes[4];
} uint32package_t;

//helper functions
uint16_t PackUint16(uint8_t high, uint8_t low) {
	uint16_t result = high << 8;
	result |= low;
	return result;
}

//global program defines
#define BUFFER_MAX 255						//Buffer maximum size
#define BAUDRATE 19200						//Com. port baud rate

//Instruction codes for decoding
#define INSTRUCTION_DIGITAL_WRITE			0x10
#define INSTRUCTION_DIGITAL_READ			0x11
#define INSTRUCTION_ANALOG_READ				0x12
#define INSTRUCTION_ANALOG_WRITE			0x13
#define INSTRUCTION_ANALOG_RESOULUTION		0x14
#define INSTRUCTION_ANALOG_REFERENCE		0x15
#define INSTRUCTION_GET_VERSION				0xfe	
