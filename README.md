Print random ascii cat

### Map
- target device: 0x9
- functions:
  - print random cat: 0xB
  - print cat by index: 0xA

### Syntax

```asm
.mva &(device) &(function) <| $(index)
.mva &(0x9) &(0xA) <| $(0x0)
```

### Install
`rune install kitty`


### Usage

![image](https://user-images.githubusercontent.com/13326808/80649956-a27e0600-8a7b-11ea-8c2d-9ee96f29ba3e.png)
