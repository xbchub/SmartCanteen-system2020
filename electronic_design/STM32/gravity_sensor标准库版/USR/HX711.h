#ifndef __HX711_H
#define __HX711_H

#include "sys.h"

#define SENSOR0_SCK PBout(0)// PB0
#define SENSOR0_DOUT PBin(1)// PB1
#define SENSOR1_SCK PBout(4)// PB2
#define SENSOR1_DOUT PBin(5)// PB3
#define SENSOR2_SCK PBout(6)// PB6
#define SENSOR2_DOUT PBin(7)// PB7

extern void Init_HX711pin(void);
extern u32 Sensor_Read(volatile unsigned long *, volatile unsigned long *);
extern void Get_Maopi(void);
extern void Get_Weight(void);

extern u32 SENSOR_Buffer[3]; 
extern u32 Weight_Maopi[3];
extern s32 Weight_Shiwu[3];
extern u8 Flag_Error;

#endif

