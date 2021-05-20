
// 对传入数组进行排序，去最大值、最小值后求取平均值 

#include <stdio.h>

void swap(float *left, float *right)
{
    float temp = *left;
    *left = *right;
    *right = temp;
}

void SelectSort(float arr[], int num)
{
    int i, j, Mindex;
    for (i = 0; i < num; i++)
    {
        Mindex = i;
        for (j = i + 1; j < num; j++)
        {
            if (arr[j] < arr[Mindex])
                Mindex = j;
        }

        swap(&arr[i], &arr[Mindex]);
    }
}

float Filter(float arr[],int num)
{
	float sum = 0;
	int i = 0;
	SelectSort(arr,num);
	for(i=1;i<num-1;i++)
	{
		sum +=arr[i];
	}
	return sum/(num-2); 
}

//int main(void)
//{
//	double avg;
//	float array[10]={12.5,234.4,34.54,34.34,34.0,45.34,6.23,4.9,34.454,656.454};
//	avg = Filter(array,10);
//	printf("The avg is %.4f",avg);
//}
