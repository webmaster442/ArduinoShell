//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

#define INSTRUCTION_DIGITAL_WRITE 0x10
#define INSTRUCTION_DIGITAL_READ 0x11
#define INSTRUCTION_GET_VERSION 0xfe

void Nop();
void DoDigitalWrite(uint8_t port, uint8_t value);
void DoDigitalRead(uint8_t port);

void runInstruction(uint8_t *buffer) {
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
    default:
      Nop();
      break;
  }
}
