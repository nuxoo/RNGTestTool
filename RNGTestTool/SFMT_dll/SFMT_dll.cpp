// SFMT_dll.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#include "stdafx.h"
#include "SFMT.h"
#include "SFMT_dll.h"
sfmt_t sfmt;
sfmt_t sfmt2;

	void sfmt_set_seed(uint32_t seed) {
		sfmt_init_gen_rand(&sfmt, seed);
	}

	uint64_t sfmt_next() {
		return sfmt_genrand_uint64(&sfmt);
	}

	void sfmt_get_random(uint32_t seed, uint32_t min, uint64_t *random) {
		sfmt2 = sfmt_t();
		sfmt_init_gen_rand(&sfmt2, seed);

		for (uint32_t i = 0; i < min; i++)
			sfmt_genrand_uint64(&sfmt2);

		for (uint32_t i = 0; i < sizeof(random) / sizeof(uint64_t) - min; i++)
			random[i] = sfmt_genrand_uint64(&sfmt2);
	}

	void sfmt_get_random_t(uint64_t *random) {
		for (uint32_t i = 0; i < sizeof(random) / sizeof(uint64_t); i++)
			random[i] = sfmt_genrand_uint64(&sfmt2);
	}