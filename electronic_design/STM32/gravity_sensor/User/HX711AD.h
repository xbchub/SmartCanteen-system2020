/**
  ******************************************************************************
  * @file   XH711AD.h
  * @brief  The driver of the XH711AD.
  ******************************************************************************
  */
	
/* Includes ------------------------------------------------------------------*/
#ifndef _XH711AD_H_
#define _XH711AD_H_

#ifdef  __cplusplus
extern "C"{
#endif
	
#include "stm32f1xx.h"

extern unsigned long Weight_Shiwu_1 ;
extern uint8_t data_1[3];
extern long Weight_real_1;
	
extern unsigned long Weight_Shiwu_2 ;
extern uint8_t data_2[3];
extern long Weight_real_2;
	
extern unsigned long Weight_Shiwu_3 ;
extern uint8_t data_3[3];
extern long Weight_real_3;
	
unsigned long HX711_Read_1(void);
unsigned long HX711_Read_2(void);
unsigned long HX711_Read_3(void);
void Get_Weight_1(void);
void Get_Weight_2(void);
void Get_Weight_3(void);
void delay_us(uint8_t value);
	#ifdef  __cplusplus
}
#endif
#endif






