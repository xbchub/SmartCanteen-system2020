/**
  ******************************************************************************
  * @file   System_Tasks.cpp
  * @brief  All tasks should be created here.
  ******************************************************************************
  */
	
/* Includes ------------------------------------------------------------------*/
#include "System_task.h"

#include <FreeRTOS.h>
#include <task.h>
#include <queue.h>
#include <stm32f1xx.h>

#include "Uart.h"
#include "HX711AD.h"

/* Private variables ---------------------------------------------------------*/
TaskHandle_t Pressure_receive_Handle;
TaskHandle_t Bluetooth_sent_Handle;


/* Private function prototypes -----------------------------------------------*/
void Pressure_receive(void*arg);
void Bluetooth_sent(void*arg);


/* Function Init -------------------------------------------------------------*/
void System_Tasks_Init(void)
{
  vTaskSuspendAll();
	
	/*压力数据采集*/
	xTaskCreate(Pressure_receive,"Pressure_receive",Normal_Stack_Size,NULL,PriorityHigh,&Pressure_receive_Handle);
	/*蓝牙数据发送*/
	xTaskCreate(Bluetooth_sent,"Bluetooth_sent",Normal_Stack_Size,NULL,PriorityHigh,&Bluetooth_sent_Handle);

  if (!xTaskResumeAll())
    taskYIELD();
}


/* Function Task -------------------------------------------------------------*/

/*1.压力传感采集数据采集（USART1）*/
void Pressure_receive(void*arg)
{
  static TickType_t _xPreviousWakeTime = xTaskGetTickCount();
  static TickType_t _xTimeIncrement = pdMS_TO_TICKS(20);
  for (;;)
  { 
		Get_Weight_1();
		Get_Weight_2();
		Get_Weight_3();
		Weight_real_1=Weight_Shiwu_1-19176-93;
		Weight_real_2=Weight_Shiwu_2-19124-91;
		Weight_real_3=Weight_Shiwu_3-19827-91;
		My_printf2("%d_%d_%d\r\n",Weight_real_1,Weight_real_2,Weight_real_3);
		vTaskDelayUntil(&_xPreviousWakeTime, _xTimeIncrement);
  }
}


/*1.蓝牙数据发送（USART2）*/
void Bluetooth_sent(void*arg)
{
  static TickType_t _xPreviousWakeTime = xTaskGetTickCount();
  static TickType_t _xTimeIncrement = pdMS_TO_TICKS(200);
  for (;;)
  { 

		vTaskDelayUntil(&_xPreviousWakeTime, _xTimeIncrement);
  }
}




