// SFMT_dll.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#include "stdafx.h"
#include "SFMT.h"
#include "SFMT_dll.h"
sfmt_t sfmt;

	void sfmt_set_seed(uint32_t seed) {
		sfmt_init_gen_rand(&sfmt, seed);
	}

	uint64_t sfmt_next() {
		return sfmt_genrand_uint64(&sfmt);
	}