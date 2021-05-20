/**
  ******************************************************************************
  * @file   Uart.h
  * @brief  The driver of the Uart.
  ******************************************************************************
  */
	
#ifndef _USART_H_
#define _USART_H_

#ifdef  __cplusplus
extern "C"{
#endif
	
#include "stm32f1xx.h"


extern uint8_t rx_buffer[100];//接收数组
extern volatile uint8_t rx_len ; //接收到的数据长度
extern volatile uint8_t recv_end_flag ; //接收结束标志位

void MY_UART_Init(void);
void My_printf1(char* fmt,...);
void My_printf2(char* fmt,...);

	#ifdef  __cplusplus
}
#endif
#endif



