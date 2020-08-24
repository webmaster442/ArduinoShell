//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#pragma once

void Nop() {
	asm("nop");
}

void DoGetVersion() {
	Serial.write(3);
	Serial.write(VERSION_MAYOR);
	Serial.write(VERSION_MINOR);
	Serial.write(VERSION_BUILD);
}

void DoDigitalWrite(uint8_t port, uint8_t value) {
	pinMode(port, OUTPUT);
	digitalWrite(port, value);
}

void DoDigitalRead(uint8_t port) {
	pinMode(port, INPUT);
	uint8_t value = digitalRead(port);
	Serial.write(1);
	Serial.write(value);
}

void DoAnalogWrite(uint8_t port, uint16_t value) {
	pinMode(port, OUTPUT);
	digitalWrite(port, 0);
	analogWrite(port, value);
}

void DoAnalogRead(uint8_t port) {
	uint32package_t package;
	package.int32 = analogRead(port);
	Serial.write(4);
	Serial.write(package.bytes, 4);
}

void DoAnalogReadResolution(uint8_t precision) {
//analogReadResolution is only avaliable on ARM boards
#if defined(__arm__) 
	analogReadResolution(precision);
#elif defined(__AVR__)
	asm("nop");
#endif
}

void DoAnalogReference(uint8_t type) {
	if (type == 0) {
		analogReference(DEFAULT);
	}
	else {
		analogReference(EXTERNAL);
	}
}