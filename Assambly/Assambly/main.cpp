#include <stdio.h>
#include <iostream>

int doASM(int num, int power);

int main(void)
{
	int num1 = 3, num2 = 5;
	printf_s("%d plus %d is %d\n", num1, num2, doASM(3, 5));

	getchar();

	return 0;
}
int doASM(int a, int b)
{
	__asm
	{
		mov eax, dword ptr[a]
		mov ebx, dword ptr[b]
		add eax, ebx
		mov[a], eax
	};

	return a;
	// Return with result in EAX
}