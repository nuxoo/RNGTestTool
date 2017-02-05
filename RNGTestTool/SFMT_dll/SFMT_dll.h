// SFMT_dll.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#include "stdafx.h"

#define TESTFUNCDLL_API __declspec(dllexport) 

extern "C" {
	TESTFUNCDLL_API void sfmt_set_seed(uint32_t seed);
	TESTFUNCDLL_API uint64_t sfmt_next();
}