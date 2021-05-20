/**
  ******************************************************************************
  * @file   Uart.cpp
  * @brief  The driver of the Uart.
  ******************************************************************************
  */
	
/* Includes ------------------------------------------------------------------*/
#include "Uart.h"
	
#include <string.h>
#include <stdarg.h>
#include <stdio.h>
	

extern UART_HandleTypeDef huart1;
extern UART_HandleTypeDef huart2;

uint8_t rx_buffer[100];//接收数组
volatile uint8_t rx_len = 0; //接收到的数据长度
volatile uint8_t recv_end_flag = 0; //接收结束标志位


/*自定义串口一打印函数，用法与printf类似*/
void My_printf1(char* fmt,...)
{ 
  static __align(8) uint8_t USART1_buffer[128];
  va_list ap;
  va_start(ap,fmt);
  vsnprintf((char*)USART1_buffer,2000,fmt,ap);
  va_end(ap);
  HAL_UART_Transmit(&huart1 , USART1_buffer, strlen((const char*)USART1_buffer), 0xFFFF);
}

/*自定义串口二打印函数，用法与printf类似*/
void My_printf2(char* fmt,...)
{ 
  static __align(8) uint8_t USART1_buffer[128];
  va_list ap;
  va_start(ap,fmt);
  vsnprintf((char*)USART1_buffer,2000,fmt,ap);
  va_end(ap);
  HAL_UART_Transmit(&huart2 , USART1_buffer, strlen((const char*)USART1_buffer), 0xFFFF);
}


//串口初始化
void MY_UART_Init()
{
	__HAL_UART_ENABLE_IT(&huart1, UART_IT_IDLE);    
	HAL_UART_Receive_DMA(&huart1,rx_buffer,100);
}


//串口回调函数
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	if(huart->Instance == USART1)
	{
		;//将数据送入队列
	}
	if(huart->Instance == USART2)
	{
		;
	}
}




