/**
  ******************************************************************************
  * @file   : System_Tasks.h
  * @brief  : Header for System_Tasks.cpp
  ****************************************************************************** 
  */
#ifndef _SYSTEM_TASKS_H_
#define _SYSTEM_TASKS_H_

#define Tiny_Stack_Size 64
#define Small_Stack_Size 128
#define Normal_Stack_Size 256
#define Large_Stack_Size 512
#define Huge_Stack_Size 1024

#define PriorityVeryLow 1
#define PriorityLow 2
#define PriorityBelowNormal 3
#define PriorityNormal 4
#define PriorityAboveNormal 5
#define PriorityHigh 6


#ifdef __cplusplus
extern "C"
{
#endif
	
	void System_Tasks_Init(void);

#ifdef __cplusplus
}
#endif

#endif
/************************ COPYRIGHT(C) SCUT-ROBOTLAB **************************/


