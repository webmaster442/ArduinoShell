//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

void Nop() {
	//nop
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
