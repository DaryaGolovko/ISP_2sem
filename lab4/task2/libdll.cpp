#include "pch.h"
#include "libdll.h"

extern "C" int __declspec(dllexport) recursion(int number, int value)
{
	if (number > 1)
	{
		value *= number;
		number--;
		return recursion(number,value);
	}
	else
	{
		return value;
	}
}