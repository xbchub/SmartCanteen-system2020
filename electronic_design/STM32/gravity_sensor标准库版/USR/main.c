#include "mydefine.h"
#include "BT05.h"
#include "usart.h"
#include "usart2.h"
#include "HX711.h"
#include "filter.h"

#include "delay.h"
#include "sys.h"
#include "string.h"
#include "stm32f10x.h"
#include "stm32f10x_it.h"
#include "misc.h"
#include "stm32f10x_usart.h"
#include "stdio.h"
#include "stm32f10x_spi.h"
#include "math.h"

void RCC_Configuration(void);
void GPIO_Configuration(void);
void NVIC_Configuration(void);
void USART_Configuration(void);

int main(void)
{
	extern double temp,pressure;
	u8 i, j = 0;
	u8 key;
	u8 sendmask=0;
	u8 sendcnt=0;
	u8 sendbuf[20];	  
	u8 reclen=0;  
	u32 ADCon_InitVal[3], ADCon_CurrentVal[3];
	float Weight[3], GapValue[3], Adjust[3];
	float Weight_Array[3][10];
	volatile unsigned long * PIN_SCK[3] = {&SENSOR0_SCK, &SENSOR1_SCK, &SENSOR2_SCK};
	volatile unsigned long * PIN_DOUT[3] = {&SENSOR0_DOUT, &SENSOR1_DOUT, &SENSOR2_DOUT};


	delay_init();	    	 //延时函数初始化
	uart_init(9600);	 	//串口初始化为9600
	RCC_Configuration();	//系统时钟初始化
	GPIO_Configuration();//端口初始化
	NVIC_Configuration();
	USART_Configuration();
	delay_init();
	Init_HX711pin();
	while(BT05_Init()) 		//初始化BT05模块
	{
		printf("BT05 Error, please check.");
		delay_ms(100);
	}
	BT05_Role_Print();
	
	for (i=0; i<3; i++)
	{
		ADCon_InitVal[i] = (Sensor_Read(PIN_SCK[i], PIN_DOUT[i]) / 1000) * 1000;
		ADCon_CurrentVal[i] = (Sensor_Read(PIN_SCK[i], PIN_DOUT[i]) / 1000) * 1000;
		while (ADCon_InitVal[i] != ADCon_CurrentVal[i]) 
		{
			ADCon_InitVal[i] = (Sensor_Read(PIN_SCK[i], PIN_DOUT[i]) / 1000) * 1000;
			ADCon_CurrentVal[i] = (Sensor_Read(PIN_SCK[i], PIN_DOUT[i]) / 1000) * 1000;
			printf("ADCon_CurrentVal[%d] = %d \r\n", i, ADCon_CurrentVal[i]);
			printf("ADCon_InitVal[%d] = %d \r\n", i, ADCon_InitVal[i]);
		}
	printf("ADCon_CurrentVal[%d] = %d \r\n", i, ADCon_CurrentVal[i]);
	printf("ADCon_InitVal[%d] = %d \r\n", i, ADCon_InitVal[i]);
	}
	
	GapValue[0] = 520;
	GapValue[1] = 520;
	GapValue[2] = 520;
	
	while (1)
	{
		for (j=0; j<10; j++)
		{
			for(i=0; i<3; i++)
			{
				ADCon_CurrentVal[i] = (Sensor_Read(PIN_SCK[i], PIN_DOUT[i]) / 1000) * 1000;
			
			 //获取实物的AD采样数值。由于在没有任何重量的情况下，
			 //转换值最后三位为非0，所以将转换值的最后3位忽略不计
			 ADCon_CurrentVal[i] = ADCon_CurrentVal[i] - ADCon_InitVal[i];

			 Weight_Array[i][j] = (float)ADCon_CurrentVal[i] / GapValue[i];
			}
		}
		
		//滤波
		for (i=0; i<3; i++)
			Weight[i] = Filter(Weight_Array[i],10);

		u2_printf("%d_%d_%d\r\n", Weight[0], Weight[1], Weight[2]);
		//BT05_Sta_Print();
		delay_ms(15);
	}
}

void RCC_Configuration(void)
{
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA,ENABLE);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1,ENABLE);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_AFIO,ENABLE);

}

void GPIO_Configuration(void)
{
  GPIO_InitTypeDef GPIO_InitStructure;	
	//TX
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_9;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_AF_PP;
	GPIO_Init(GPIOA,&GPIO_InitStructure);
	
	//RX
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_10;
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_IN_FLOATING;
	GPIO_Init(GPIOA,&GPIO_InitStructure);
}

void NVIC_Configuration(void)
{
  NVIC_InitTypeDef NVIC_InitStructure; 
	
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_1);
	
	NVIC_InitStructure.NVIC_IRQChannel=USART1_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority=0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority=1;
	NVIC_InitStructure.NVIC_IRQChannelCmd=ENABLE;
	NVIC_Init(&NVIC_InitStructure);
}

void USART_Configuration(void)
{
	USART_InitTypeDef USART_InitStructure;
	
	USART_InitStructure.USART_BaudRate=9600;
	USART_InitStructure.USART_WordLength=USART_WordLength_8b;
	USART_InitStructure.USART_StopBits=USART_StopBits_1;
	USART_InitStructure.USART_Parity=USART_Parity_No;
	USART_InitStructure.USART_HardwareFlowControl=USART_HardwareFlowControl_None;
	USART_InitStructure.USART_Mode=USART_Mode_Rx|USART_Mode_Tx;
	
	USART_Init(USART1,&USART_InitStructure);
	USART_ITConfig(USART1,USART_IT_RXNE,ENABLE);
	USART_Cmd(USART1,ENABLE);
	USART_ClearFlag(USART1,USART_FLAG_TC);
}
