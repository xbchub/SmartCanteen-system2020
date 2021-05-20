/************************************************************************************
						
*************************************************************************************/
#include "HX711.h"
#include "delay.h"

u32 SENSOR_Buffer[3];

u32 Weight_Maopi[3];

s32 Weight_Shiwu[3];
u8 Flag_Error = 0;

volatile unsigned long * PIN_SCK[3] = {&SENSOR0_SCK, &SENSOR1_SCK, &SENSOR2_SCK};
volatile unsigned long * PIN_DOUT[3] = {&SENSOR0_DOUT, &SENSOR1_DOUT, &SENSOR2_DOUT};


//校准参数
//因为不同的传感器特性曲线不是很一致，因此，每一个传感器需要矫正这里这个参数才能使测量值很准确。
//当发现测试出来的重量偏大时，增加该数值。
//如果测试出来的重量偏小时，减小改数值。
//该值可以为小数
float GapValue[3] = {106.5, 106.5, 106.5};


void Init_HX711pin(void)
{
		GPIO_InitTypeDef GPIO_InitStructure;
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB, ENABLE);	 //使能PORTB

		//SENSOR0_SCK
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;				 // 端口配置
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 		 //推挽输出
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		 //IO口速度为50MHz
		GPIO_Init(GPIOB, &GPIO_InitStructure);					 //根据设定参数初始化GPIOB
	
		//SENSOR0_DOUT
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;//输入上拉
    GPIO_Init(GPIOB, &GPIO_InitStructure);
	
		//SENSOR1_SCK
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;				 // 端口配置
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 		 //推挽输出
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		 //IO口速度为50MHz
		GPIO_Init(GPIOB, &GPIO_InitStructure);					 //根据设定参数初始化GPIOB
	
		//SENSOR1_DOUT
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;//输入上拉
    GPIO_Init(GPIOB, &GPIO_InitStructure);
		
		//SENSOR2_SCK
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_4;				 // 端口配置
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 		 //推挽输出
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		 //IO口速度为50MHz
		GPIO_Init(GPIOB, &GPIO_InitStructure);					 //根据设定参数初始化GPIOB
	
		//SENSOR2_DOUT
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;//输入上拉
    GPIO_Init(GPIOB, &GPIO_InitStructure); 
	
		GPIO_SetBits(GPIOB,GPIO_Pin_0);					//初始化设置为0
		GPIO_SetBits(GPIOB,GPIO_Pin_2);					//初始化设置为0
		GPIO_SetBits(GPIOB,GPIO_Pin_4);					//初始化设置为0
}



//****************************************************
//读取HX711
//****************************************************
u32 Sensor_Read(volatile unsigned long *SENSOR_SCK,
								volatile unsigned long *SENSOR_DOUT)
{
	unsigned long count; 
	unsigned char i;
  *SENSOR_DOUT=1; 
	delay_us(1);
  *SENSOR_SCK=0; 
  count=0; 
  while(*SENSOR_DOUT); 
  for(i=0;i<24;i++)
	{ 
	  *SENSOR_SCK=1; 
	  count=count<<1; 
		delay_us(1);
		*SENSOR_SCK=0; 
	  if(*SENSOR_DOUT)
			count++; 
		delay_us(1);
	} 
 	*SENSOR_SCK=1; 
  count=count^0x800000;//第25个脉冲下降沿来时，转换数据
	delay_us(1);
	*SENSOR_SCK=0;  
	return(count);
}


//****************************************************
//获取毛皮重量
//****************************************************
void Get_Maopi(void)
{
	u8 i;
	for (i=0; i<3; i++)
	{
		Weight_Maopi[i] = Sensor_Read(PIN_SCK[i], PIN_DOUT[i]);
	}
} 

//****************************************************
//称重
//****************************************************
void Get_Weight(void)
{
	u8 i;
	for (i=0; i<3; i++)
	{
		Weight_Maopi[i] = Sensor_Read(PIN_SCK[i], PIN_DOUT[i]);
		if (SENSOR_Buffer[i] > Weight_Maopi[i])
		{
			Weight_Shiwu[i] = SENSOR_Buffer[i];
			Weight_Shiwu[i] = Weight_Shiwu[i] - Weight_Maopi[i];				//获取实物的AD采样数值。
	
			Weight_Shiwu[i] = (s32)((float)Weight_Shiwu[i]/GapValue[i]); 	//计算实物的实际重量
																		//因为不同的传感器特性曲线不一样，因此，每一个传感器需要矫正这里的GapValue这个除数。
																		//当发现测试出来的重量偏大时，增加该数值。
																		//如果测试出来的重量偏小时，减小改数值。
		}
	}
}
