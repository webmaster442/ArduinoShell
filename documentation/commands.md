# Avaliable commands

## analogRead

```
analogRead [uint8_t]<pin>
retrun value: uint32_t
```

Reads the value from the specified analog pin. Return value is 32 bit integer. If you don't call analogReadResolution, then the output value will be 10 bits. analogReadResolution has only effect if you flash the firmware to Due, Zero and MKR Family boards.

## digitalRead

```
digitalRead [uint8_t]<pin>
return type: boolean
```

Reads the value from a specified digital pin. Return value is true or false.

## digitalWrite

```
digitalWrite [uint8_t]<pin> [uint8_t]<value>
return type: none
```

Writes a digital value to the specfied pin. Internally changes the port state to output befrore writng value.

## getVersion

```
getVersion
return type: none
```

Outputs the current firmware version flashed to the board.